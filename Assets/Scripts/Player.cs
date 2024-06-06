using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    PhotonView pv;
    private void Start()
    {
        pv = PhotonManager.Instance.pv;
    }
    private void Update()
    {
        if(pv.IsMine)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * Time.deltaTime * 7, 0, 0));
        }
    }
}
