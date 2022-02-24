using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private UnityEvent     _updateHealthElement;                   // Event triggered whenever the health gets updated.
    [SerializeField] private UnityEvent     _playerDeath;                           // Event triggered upon death.
    [SerializeField] private UnityEvent     _damageTaken;               // Event triggered upon death.
    [SerializeField] private UnityEvent     _healthRecieved;                           // Event triggered upon death.


    public static int    s_Health           = 100;                                  // Current health the player has.
    private int          _maxHealth         = 100;                                  // Maximum amount of health the player can have.
    private bool         _Invincible        = false;                                // When true the player can't take damage.




    private void Start()
    {
        s_Health = 100;
        _updateHealthElement.Invoke();
    }


    // When entering a trigger, check if this is a health pick up or damaging object. To later act accordingly.
    private void OnTriggerStay2D(Collider2D other)
    {
        // When hitting a DamageObject.
        if (other.GetComponent<DoDamage>())
        {
            var healthScript = other.GetComponent<DoDamage>();

            if (_Invincible == false)
            {
                _Invincible = true;
                StartCoroutine(ChangeHealth(healthScript.DamageAmount, healthScript.DamageInterval));
                
                _damageTaken.Invoke();
            }


        }

        // When hitting a HealthPickup
        if (other.GetComponent<HealthPickup>())
        {
            if (s_Health < 100)
            {
                var healthScript = other.GetComponent<HealthPickup>();
                StartCoroutine(ChangeHealth(healthScript.HealAmount, 0f));

                _healthRecieved.Invoke();
                Destroy(other.gameObject);
            }
        }
    }


    // Add or subtract the given amount of HealthPoints from the player's Health.
    public IEnumerator ChangeHealth(int amount, float time)
    {
        if ((s_Health  + amount) < _maxHealth)
        {
             s_Health += amount;
        }
        else
        {
             s_Health  = _maxHealth;
        }

        _updateHealthElement.Invoke();
        CheckHealth();

        yield return new WaitForSeconds(time);
        _Invincible = false;
    }


    // Check if the player has died or not.
    public void CheckHealth()
    {
        if (s_Health <= 0)
        {
            _playerDeath.Invoke();
        }
    }
}
