using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public Button roomCreate;
    public InputField roomName;
    public InputField roomPerson;
    public Transform roomContent;
    

    Dictionary<string, RoomInfo> roomCatalog = new Dictionary<string, RoomInfo>();
    private void Update()
    {
        if (roomName.text.Length > 0 && roomPerson.text.Length > 0)
            roomCreate.interactable = true;
        else
            roomCreate.interactable = false;
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Photon Game");
    }
    public void CreateRoomObject()
    {
        foreach(RoomInfo info in roomCatalog.Values)
        {
            GameObject room = Instantiate(Resources.Load<GameObject>("Room"));

            room.transform.SetParent(roomContent);

            room.GetComponent<Infomation>().SetInfo(info.Name, info.PlayerCount, info.MaxPlayers);
        }
    }
    public void OnClickCreateRoom()
    {
        RoomOptions Room = new RoomOptions();
        Room.MaxPlayers = byte.Parse(roomPerson.text);
        Room.IsOpen = true;
        Room.IsVisible = true;
        PhotonNetwork.CreateRoom(roomName.text, Room);
    }
    public void AllDeleteRoom()
    {
        foreach(Transform trans in roomContent)
        {
            Destroy(trans.gameObject);
        }
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        AllDeleteRoom();
        UpdateRoom(roomList);
        CreateRoomObject();
    }
    void UpdateRoom(List<RoomInfo> roomList)
    {
        for(int i = 0; i < roomList.Count; i++)
        {
            if (roomCatalog.ContainsKey(roomList[i].Name) && roomList[i].RemovedFromList)
            {
                roomCatalog.Remove(roomList[i].Name);
                continue;
            }
            roomCatalog[roomList[i].Name] = roomList[i];
        }
    }





}
