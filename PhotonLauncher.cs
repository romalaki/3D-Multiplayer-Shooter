using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonLauncher : MonoBehaviourPunCallbacks
{
    public static List<string> list = new List<string>();

    public GameObject loadingScreen, menu, room, join;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    
    public override void OnJoinedLobby()
    {
        loadingScreen.SetActive(false);
        menu.SetActive(true);
        Debug.Log("Joined Lobby");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room");
        menu.SetActive(false);
        room.SetActive(true);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogError("Create Room Failed: " + message);
    }

    public override void OnRoomListUpdate(System.Collections.Generic.List<Photon.Realtime.RoomInfo> roomList)
    {
        list.Clear();
        foreach (var room in roomList)
        {
            list.Add(room.Name);
        }

        join.GetComponent<List_rooms>().ChangeRooms();
    }
}
