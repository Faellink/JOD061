using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{

    private PhotonView photonView;

    public float moveSpeed = 0.2f;

    public float moveRotation = 20f;

    public GameObject bulletPrefab;

    public Transform gun;


    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        Material material = GetComponent<Renderer>().material;
        material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            transform.Translate(0, 0, Input.GetAxis("Vertical") * moveSpeed);
            transform.Rotate(0, Input.GetAxis("Horizontal") * moveRotation, 0);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                photonView.RPC("CmdAtirar", RpcTarget.AllBuffered, 10);
            }
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            if (photonView.IsMine)
            {
                PhotonNetwork.Destroy(gameObject);
            }
        }
    }

    [PunRPC]
    public void CmdAtirar(int valor)
    {
        Instantiate(bulletPrefab, gun.position, transform.rotation);
    }
}
