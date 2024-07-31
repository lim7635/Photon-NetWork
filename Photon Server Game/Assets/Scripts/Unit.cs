using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    RUN,
    ATTACK,
    DIE
}

public class Unit : MonoBehaviour
{
    [SerializeField] State state;

    [SerializeField] float speed = 5.0f;

    [SerializeField] Animator animator;

    [SerializeField] GameObject tower;

    void Start()
    {
        state = State.RUN;

        animator = GetComponent<Animator>();

        tower = GameObject.Find("Tower");

        transform.LookAt(tower.transform.position);
    }

    void Update()
    {
        switch(state)
        {
            case State.RUN: Run();
                break;

            case State.ATTACK: Attack();
                break;

            case State.DIE: Die();
                break;
        }
    }

    public void Run()
    {
        transform.position = Vector3.MoveTowards(transform.position, tower.transform.position, speed * Time.deltaTime);
    }

    public void Attack()
    {
        animator.SetTrigger("Attack");
    }

    public void Die()
    {
        animator.SetTrigger("Die");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Tower"))
        {
            state = State.ATTACK;
        }
    }
}