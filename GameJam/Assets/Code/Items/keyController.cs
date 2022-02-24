using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class keyController : MonoBehaviour
{
    [SerializeField] private GameObject[]   _Door;
    [SerializeField] private UnityEvent     _keyPickedUp;
    private GameObject                      _savedKeyObject;
    public static int                       s_savedKey;

    private void Start()
    {
        s_savedKey = -1;
        _savedKeyObject = null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<KeyPickup>())
        {
            if (_savedKeyObject != null)
            {
                _savedKeyObject.SetActive(true);
            }

            s_savedKey = other.gameObject.GetComponent<KeyPickup>().DoorToOpen - 1;
            _savedKeyObject = other.gameObject;
            _savedKeyObject.SetActive(false);

            _keyPickedUp.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (s_savedKey >= 0)
        {
            if (other.gameObject == _Door[s_savedKey])
            {
                other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                _savedKeyObject = null;
                s_savedKey = -1;
                _keyPickedUp.Invoke();
            }
        }
    }
}
