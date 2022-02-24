using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : MonoBehaviour
{
    public int DamageAmount;
    public float DamageInterval;

    [SerializeField] private HealthData Data;

    public void Start()
    {
        DamageAmount = -Data.HealthChangeAmount;
        DamageInterval = Data.ChangeInterval;
    }
}
