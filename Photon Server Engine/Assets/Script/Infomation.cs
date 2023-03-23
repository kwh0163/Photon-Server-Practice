using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Infomation : MonoBehaviourPunCallbacks
{
    public Text roomData;
    private string roomName;

    public void OnClickJoinRoom()
    {
        PhotonNetwork.JoinRoom(roomName);
    }
    public void SetInfo(string name, int current, int max)
    {
        roomName = name;
        roomData.text = name + " ( " + current + " / " + max + ")";
    }
}
