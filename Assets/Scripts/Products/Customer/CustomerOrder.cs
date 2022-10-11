using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerOrder : MonoBehaviour
{
    [HideInInspector] public Items order;

    [HideInInspector] public float arriveTime;
    [HideInInspector] public float leaveTime;

    void OnEnable() 
    {
        var values = System.Enum.GetValues(typeof(Items));
        order = (Items)Random.Range(0, values.Length);
    }
}