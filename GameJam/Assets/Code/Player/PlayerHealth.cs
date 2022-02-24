using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private UnityEvent     _updateHealthElement;                   // Event triggered whenever the health gets updated.
    [SerializeField] private UnityEvent     _playerDeath;                           // Event triggered upon death.

    public static int    s_Health           = 100;                                  // Current health the player has.
    private int          _maxHealth         = 100;                                  // Maximum amount of health the player can have.
    private bool         _Invincible        = false;                                // When true the player can't take damage.




    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<DoDamage>())
        {
            var healthScript = other.GetComponent<DoDamage>();

            if (_Invincible == false)
            {
                _Invincible = true;
                StartCoroutine(ChangeHealth(healthScript.DamageAmount, healthScript.DamageInterval));
            }
        }

        if (other.GetComponent<HealthPickup>())
        {
            if (s_Health < 100)
            {
                var healthScript = other.GetComponent<HealthPickup>();
                StartCoroutine(ChangeHealth(healthScript.HealAmount, 0f));

                Destroy(other.gameObject);
            }
        }
    }

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


    public void CheckHealth()
    {
        if (s_Health <= 0)
        {
            _playerDeath.Invoke();
        }
    }
}
