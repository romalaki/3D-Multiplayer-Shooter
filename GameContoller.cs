using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameContoller : MonoBehaviourPunCallbacks
{
    private static GameContoller instance;

    void Start()
    {
        if(instance != null)
            Destroy(gameObject);

        DontDestroyOnLoad(this);
        instance = this;
    }

    public override void OnEnable()
    {
        base.OnEnable();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode i)
    {

        Debug.Log("OnSceneLoaded: " + scene.name);
        if (scene.name == "game") 
        {
            PhotonNetwork.Instantiate("PlayerManager", new Vector3(10, -3, 10), Quaternion.identity);
        }
    }
}
