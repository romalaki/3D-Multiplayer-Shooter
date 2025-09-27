
using Photon.Pun;
using UnityEngine;
using UnityEngine.UIElements;


public class List_rooms : MonoBehaviourPunCallbacks
{
    private VisualElement _list;
    public GameObject wait;

    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        _list = root.Q<VisualElement>("list");
        ChangeRooms();
    }

    public void ChangeRooms()
    {
        if (_list == null) return;

        _list.Clear();
        
        foreach (var roomName in PhotonLauncher.list)
        {
            Button button = new Button();
            button.text = roomName;
            button.clicked += () => JoinRoom(roomName);
            _list.Add(button);

        }
    } 

    public void JoinRoom(string s)
    {
        PhotonNetwork.JoinRoom(s);
        wait.SetActive(true);
        gameObject.SetActive(false); 
    }
}
