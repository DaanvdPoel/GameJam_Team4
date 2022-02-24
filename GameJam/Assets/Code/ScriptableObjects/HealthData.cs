using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HealthData", menuName = "ScriptableObject/Data/Health", order = 1)]
public class HealthData : ScriptableObject
{
    public int      HealthChangeAmount;
    public float    ChangeInterval;
}
