using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] Vector3 direction;

    [SerializeField] float speed = 200.0f;

    public void OnRotate(float x, float y, float z)
    {
        direction.x = x;
        direction.y = y;
        direction.z = z;

        direction.Normalize();

        transform.eulerAngles += direction * speed * Time.deltaTime;
    }
}