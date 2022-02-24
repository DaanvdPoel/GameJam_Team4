using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DeathSequence : MonoBehaviour
{
    private GameObject                      _player;                            // Player GameObject.
    [SerializeField] private float          _intervalDeathFreeze;               // Time between starting the death particles and opening the menu.
    [SerializeField] private UnityEvent     _enableDeathScreen;                 // Event invoked when it is time to show the DeathScreen.




    private void Start()
    {
        // Get the player object for further actions.
        _player = GameObject.Find("Player");
    }




    public void TriggerSequence()
    {
        StartCoroutine(DeathAnimation());
    }


    private IEnumerator DeathAnimation()
    {
        // Disable the player and place particles instead.
        _player.SetActive(false);

        yield return new WaitForSeconds(_intervalDeathFreeze);
        
        // Freeze the game and show the DeathScreen.
        Time.timeScale = 0;
        _enableDeathScreen.Invoke();
    }
}
