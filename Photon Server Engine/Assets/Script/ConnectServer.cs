using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectServer : MonoBehaviourPunCallbacks
{
    private string serverName;

    public void SelectServer(string text)
    {
        serverName = text;

        PhotonNetwork.ConnectUsingSettings();
    }
    
    
    public override void OnJoinedLobby()
    {
        PhotonNetwork.LoadLevel("Photon Room");
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(new TypedLobby(serverName, LobbyType.Default));
    }


}
