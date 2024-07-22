using UnityEngine;
using Photon.Pun;
using TMPro;
using PlayFab.EventsModels;

public class Controller : MonoBehaviourPun
{
    [SerializeField] float mouseX;

    [SerializeField] float speed;

    [SerializeField] Vector3 direction;

    [SerializeField] Camera temporaryCamera;

    void Start()
    {
        // ���� �÷��̾ ������ ���
        if (photonView.IsMine)
        {
            Camera.main.gameObject.SetActive(false);
        }
        else
        {
            temporaryCamera.enabled = false;
            GetComponentInChildren<AudioListener>().enabled = false;
        }
    }

    void Update()
    {
        
    }
}