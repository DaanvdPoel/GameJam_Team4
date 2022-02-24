using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI    _healthElement;             // UI element displaying the player's current health.
    [SerializeField] private Image              _currentKey;
    [SerializeField] private GameObject[]       _keys;
    
    
    public void UpdateCurrentKey()
    {
        if (keyController.s_savedKey >= 0)
        {
            if (!_currentKey.gameObject.activeInHierarchy)
            {
                _currentKey.gameObject.SetActive(true);
            }
            
            _currentKey.sprite = _keys[keyController.s_savedKey].GetComponent<SpriteRenderer>().sprite;
        }
        else
        {
            _currentKey.sprite = null;
            _currentKey.gameObject.SetActive(false);
        }
    }
    
    public void UpdateHealth()
    {
        int shownHealth;

        if (PlayerHealth.s_Health > 0)
        {
            shownHealth = PlayerHealth.s_Health;
        }
        else
        {
            shownHealth = 0;
        }

        _healthElement.text = "Health: " + shownHealth;
    }


}
