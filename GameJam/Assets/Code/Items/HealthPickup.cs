using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int HealAmount;

    [SerializeField] private HealthData Data;

    public void Start()
    {
        HealAmount = Data.HealthChangeAmount;
    }
}
