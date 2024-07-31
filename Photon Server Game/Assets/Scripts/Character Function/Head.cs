using Photon.Pun;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[RequireComponent(typeof(Rotate))]
public class Head : MonoBehaviourPunCallbacks
{
    [SerializeField] Rotate rotate;

    [SerializeField] float x;

    [SerializeField] float speed = 200.0f;

    void Update()
    {
        if (photonView.IsMine == false) return;

        x = -Input.GetAxis("Mouse Y") * speed * Time.deltaTime;

        x = Mathf.Clamp(x, -90, 90);

        transform.eulerAngles = new Vector3(x, 0, 0);
    }
}