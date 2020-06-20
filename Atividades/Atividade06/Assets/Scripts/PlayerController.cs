using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{

    float moveSpeed = 0.2f;
    float moveRotation = 20f;
    public PhotonView photonView;

    void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine)
            return;
        transform.Translate(0, 0, Input.GetAxis("Vertical") * moveSpeed);
        transform.Rotate(0, Input.GetAxis("Horizontal") * moveRotation, 0);
    }
}
