using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ProjetilController : NetworkBehaviour
{
    public float _moveSpeed = 20f;
    
    private void Start()
    {
        Destroy(this.gameObject, 1f);
    }

    private void Update()
    {
        transform.Translate(0, 0, Time.deltaTime * _moveSpeed);
    }

    [ServerCallback]
    private void OnTriggerEnter(Collider other)
    {
        NetworkServer.Destroy(gameObject);
        NetworkServer.Destroy(other.gameObject);
    }
}
