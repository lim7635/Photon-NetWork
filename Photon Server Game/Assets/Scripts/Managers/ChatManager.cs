using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Chat;

public class ChatManager : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField inputField;

    [SerializeField] Transform createTransform;

    void Update()
    {
        // 캐릭터가 움직일 경우
        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            inputField.readOnly = true;
        }
        else
        {
            inputField.readOnly = false;
        }

        // 엔터를 입력했을 경우
        if(Input.GetKeyDown(KeyCode.Return))
        {
            inputField.ActivateInputField();

            if (inputField.text.Length == 0) return;

            string dialog = PhotonNetwork.NickName + " : " + inputField.text;

            photonView.RPC("Chatting", RpcTarget.All, dialog);
        }
    }

    [PunRPC]
    public void Chatting(string message)
    {
        // ChatPrefab을 하나 만들어서 text에 값을 설정합니다.
        GameObject dialog = Instantiate(Resources.Load<GameObject>("String"));
        dialog.GetComponent<Text>().text = message;

        // 스크롤 뷰 = content에 자식으로 등록합니다.
        dialog.transform.SetParent(createTransform);

        // 채팅을 입력한 후에서 이이서 입력할 수 있도록 설정합니다.
        inputField.ActivateInputField();

        // input 텍스트를 초기화합니다.
        inputField.text = "";
    }
}