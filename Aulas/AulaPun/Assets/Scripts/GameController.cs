using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameController : MonoBehaviourPunCallbacks
{
    public GameObject prefabPlayer;

    // Start is called before the first frame update
    void Start()    
    {
        if (!PhotonNetwork.IsConnected) {
            PhotonNetwork.LoadLevel("LobbyScene");
            return;   
        }

        PhotonNetwork.Instantiate(prefabPlayer.name, new Vector3(Random.Range(-5f, 5f), 0f, 0f), Quaternion.identity, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickSair() {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom() {
        Debug.Log(PhotonNetwork.NickName + " saiu da sala ");
        PhotonNetwork.Disconnect();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Desconactado!");
        PhotonNetwork.LoadLevel("LobbyScene");
    }

}
