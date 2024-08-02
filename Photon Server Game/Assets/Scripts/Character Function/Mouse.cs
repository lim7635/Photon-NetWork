using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Mouse : MonoBehaviourPunCallbacks
{
    [SerializeField] Ray ray;

    [SerializeField] LayerMask layerMask;

    [SerializeField] RaycastHit rayCastHit;

    [SerializeField] Vector3 direction;

    [SerializeField] Transform rayPosition;

    void Start()
    {
        ActiveMouse(false, CursorLockMode.Locked);
    }

    public static void ActiveMouse(bool state, CursorLockMode mode)
    {
        Cursor.visible = state;
        Cursor.lockState = mode;
    }

    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            direction = Camera.main.ScreenPointToRay(Input.mousePosition).direction;

            ray = new Ray(rayPosition.position, direction);

            if(Physics.Raycast(ray, out rayCastHit, Mathf.Infinity, layerMask))
            {
                PhotonView photonObject = rayCastHit.collider.gameObject.GetComponent<PhotonView>();

                if(photonObject.IsMine)
                {
                    photonObject.GetComponent<Unit>().Damage(50.0f);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawRay(rayPosition.position, direction * 100);
    }
}