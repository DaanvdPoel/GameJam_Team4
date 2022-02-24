using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    // Switch the scene to the Starting screen of the game.
    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }


    // Switch the first playable world of the game.
    public void ToLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
        Time.timeScale = 1;
    }


    // Reload the current scene.
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }


    // Shut down this instance of the game.
    public void QuitGame()
    {
        Application.Quit();
    }
}
