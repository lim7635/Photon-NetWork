using UnityEngine;
using Photon.Pun;
using TMPro;
using PlayFab.EventsModels;
using Photon.Realtime;

[RequireComponent(typeof(Move))]
[RequireComponent(typeof(Rotate))]
public class Controller : MonoBehaviourPunCallbacks
{
    [SerializeField] Move move;

    [SerializeField] Rotate rotate;

    [SerializeField] Camera temporaryCamera;

    private void Awake()
    {
        move = GetComponent<Move>();

        rotate = GetComponent<Rotate>();
    }

    void Start()
    {
        // 현재 플레이어가 본인일 경우
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
        if (photonView.IsMine)
        {
            move.OnMove(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

            rotate.OnRotate(0, Input.GetAxisRaw("Mouse X"), 0);
        }
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        PhotonNetwork.SetMasterClient(PhotonNetwork.PlayerList[0]);
    }
}