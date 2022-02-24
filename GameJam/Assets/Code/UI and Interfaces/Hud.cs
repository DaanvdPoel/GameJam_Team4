using UnityEngine;
using TMPro;

public class Hud : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI    _healthElement;             // UI element displaying the player's current health.
    
    
    
    
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
