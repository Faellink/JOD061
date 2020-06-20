using System.Collections;
using System.Collections.Generic;

using Mirror;

using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    public float _moveSpeed = 0.1f;
    public float _moveRotation = 1f;
    public GameObject projetilPrefab;
    public Transform arma;

    private void Start()
    {
        Material material = GetComponent<Renderer>().material;
        material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    private void Update()
    {
        if (!isLocalPlayer)
            return;

        transform.Translate(0, 0, Input.GetAxis("Vertical") * _moveSpeed);
        transform.Rotate(0, Input.GetAxis("Horizontal") * _moveRotation, 0f);

        if (Input.GetKeyDown(KeyCode.Space))
            CmdAtirar();
    }

    [Command]
    private void CmdAtirar()
    {
        GameObject projectile = Instantiate(projetilPrefab, arma.position, this.transform.rotation);
        NetworkServer.Spawn(projectile);
    }
}