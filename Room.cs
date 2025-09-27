using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Room : MonoBehaviour
{
    private Button b;

    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        Label l = root.Q<Label>("name_room");
        b = root.Q<Button>("start");
        b.clicked += Game;
        l.text = "Комната создана: " + PhotonNetwork.CurrentRoom.Name;

        if(!PhotonNetwork.IsMasterClient) b.SetEnabled(false);

    }

    private void Game()
    {
        PhotonNetwork.LoadLevel(1);
    }
}
