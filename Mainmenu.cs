using UnityEngine;
using UnityEngine.UIElements;

public class Mainmenu : MonoBehaviour
{
    private Button _create_room;
    private Button _join;
    public GameObject create_room, _join_room;

    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        _create_room = root.Q<Button>("Create-room");
        _create_room.clicked += CreateRoom;
        _join = root.Q<Button>("join_room");
        _join.clicked += Join;
    }

    private void CreateRoom()
    {
        gameObject.SetActive(false);
        create_room.SetActive(true);
    }

    private void Join()
    {
        gameObject.SetActive(false);
        _join_room.SetActive(true);
    }
}
