using UnityEngine;
using UnityEngine.Events;


public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject     _pauseMenu;                 // Pause screen.         
    [SerializeField] private GameObject     _settingsMenu;              // Settings interface.
    [SerializeField] private UnityEvent     _pauseButtonPress;

    private bool    _paused             = false;                        // Is the game currently paused.




    private void Update()
    {
        // Switch on or off the pause menu when the settings aren't open.
        if (InputManager.Instance.inputActions.Player.Pause.triggered)
        {

            if (!_settingsMenu.activeInHierarchy)
            {
                _pauseButtonPress.Invoke();
            }
        }
    }


    public void TogglePause()
    {
        if (!_paused)
        {
            PauseGame();
        }
        else
        {
            UnPauseGame();
        }
    }


    // Freeze the game and load the menu interface.
    public void PauseGame()
    {
        _pauseMenu.SetActive(true);
        Time.timeScale  = 0;
        _paused         = true;
    }


    // Unfreeze the game and unload the menu interface.
    public void UnPauseGame()
    {
        _pauseMenu.SetActive(false);
        Time.timeScale  = 1;
        _paused         = false;
    }
}
