using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PhotonConnection : MonoBehaviourPunCallbacks
{
    public InputField inputField;

    public Button button;

    public byte maxPlayers = 20;

    void Start()
    {
    }

    public void OnClickConectar()
    {
        inputField.interactable = false;
        button.interactable = false;

        if (!PhotonNetwork.IsConnected)
        {
            Debug.Log("Conectando ao servidor...");
            PhotonNetwork.GameVersion = "0.0.0";
            PhotonNetwork.NickName = inputField.text;
            PhotonNetwork.ConnectUsingSettings();
            return;
        }

        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Conectado!");
        button.GetComponentInChildren<Text>().text = "Iniciar";
        button.interactable = true;
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = this.maxPlayers;
        PhotonNetwork.JoinOrCreateRoom("JOD061", options, TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Sala JOD061 criada!");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log(PhotonNetwork.NickName + " entrou na sala ");
        Debug.Log("Total de jogadores na sala " + PhotonNetwork.CurrentRoom.PlayerCount);
        PhotonNetwork.LoadLevel("GameScene");
    }

}
