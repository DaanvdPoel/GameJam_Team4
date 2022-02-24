using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    private static SaveManager _instance;
    public static SaveManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveGame(GameObject player, Scene level)
    {
        PlayerPrefs.SetFloat("PlayerPosX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerPosY", player.transform.position.y);

        PlayerPrefs.SetString("Level", level.name);
        // TODO: Add additional stats to save
    }

    public Tuple<GameObject, String> LoadGame(GameObject player)
    {
        Vector2 position = new Vector2();

        position.x = PlayerPrefs.GetFloat("PlayerPosX");
        position.y = PlayerPrefs.GetFloat("PlayerPosY");

        player.transform.position = position;

        string levelName = PlayerPrefs.GetString("Level");

        return Tuple.Create(player, levelName);
    }
}
