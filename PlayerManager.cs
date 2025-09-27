using Photon.Pun;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Точки спавна
    private Vector3[] spawnPositions = new Vector3[]
    {
        new Vector3(5, 0, -11),
        new Vector3(-1, 0, -11),
        new Vector3(5, 0, -11),
        new Vector3(-3, 0, -5)
    };

    private PhotonView PV;

    void Start()
    {
        PV = GetComponent<PhotonView>();

        if (PV.IsMine)
            SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        int index = Random.Range(0, spawnPositions.Length);
        Vector3 spawnPos = spawnPositions[index];

        PhotonNetwork.Instantiate("Player", spawnPos, Quaternion.identity);
    }
}
