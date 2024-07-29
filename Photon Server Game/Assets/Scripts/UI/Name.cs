using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class Name : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField inputField;

    [SerializeField] string nickName;

    [SerializeField] Button nickNameSetButton;

    public void Set()
    {
        nickName = inputField.text;

        PhotonNetwork.NickName = nickName;

        PlayerPrefs.SetString("Nickname", PhotonNetwork.NickName);

        Destroy(gameObject);
    }

    public void Update()
    {
        if(inputField.text.Length == 0)
        {
            nickNameSetButton.interactable = false;
        }
        else
        {
            nickNameSetButton.interactable = true;
        }
    }
}