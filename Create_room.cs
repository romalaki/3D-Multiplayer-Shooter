
using Photon.Pun;
using UnityEngine;
using UnityEngine.UIElements;

public class Create_room : MonoBehaviourPunCallbacks
{
    private Button _create_room;
    private TextField _room_name;
    public GameObject loading ;

    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        _create_room = root.Q<Button>("create_room");
        _create_room.clicked += CreateRoom;

        _room_name = root.Q<TextField>("text_field");
    }

    private void CreateRoom()
    {
        string roomName = _room_name.text;
        if(string.IsNullOrEmpty(roomName))
        {
            return;
        }
        PhotonNetwork.CreateRoom(roomName);
        gameObject.SetActive(false);
        loading.SetActive(true);
    }
}
