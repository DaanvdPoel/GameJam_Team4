using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    private void Update()
    {
        // If the corresponding key is pressed, close down the settings menu.
        if (InputManager.Instance.inputActions.Player.Pause.triggered || InputManager.Instance.inputActions.UI.Cancel.triggered)
        {
            CloseSettingsMenu();
        }    
    }


    // Unload the settings interface.
    private void CloseSettingsMenu()
    {
        this.gameObject.SetActive(false);
    }
}
