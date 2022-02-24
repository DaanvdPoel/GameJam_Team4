using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyController : MonoBehaviour
{
    [SerializeField] private GameObject[] _keys;
    private int _keyAmount;
    [SerializeField] private GameObject[] _Doors;

    private void Start()
    {
        _keyAmount = _keys.Length;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<KeyPickup>())
        {
            
        }
    }
}
