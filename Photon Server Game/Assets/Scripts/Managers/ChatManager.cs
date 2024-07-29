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
        // ĳ���Ͱ� ������ ���
        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            inputField.readOnly = true;
        }
        else
        {
            inputField.readOnly = false;
        }

        // ���͸� �Է����� ���
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
        // ChatPrefab�� �ϳ� ���� text�� ���� �����մϴ�.
        GameObject dialog = Instantiate(Resources.Load<GameObject>("String"));
        dialog.GetComponent<Text>().text = message;

        // ��ũ�� �� = content�� �ڽ����� ����մϴ�.
        dialog.transform.SetParent(createTransform);

        // ä���� �Է��� �Ŀ��� ���̼� �Է��� �� �ֵ��� �����մϴ�.
        inputField.ActivateInputField();

        // input �ؽ�Ʈ�� �ʱ�ȭ�մϴ�.
        inputField.text = "";
    }
}