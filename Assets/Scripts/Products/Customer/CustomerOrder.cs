using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerOrder : MonoBehaviour
{
    [Tooltip("Amount of time the customer is willing to wait for their order")]
    [SerializeField] float patience;
    [HideInInspector] public Items order;

    [HideInInspector] public float arriveTime;
    [HideInInspector] public float leaveTime;

    void OnEnable() 
    {
        var values = System.Enum.GetValues(typeof(Items));
        order = (Items)Random.Range(0, values.Length);
        order = Items.TV;
        print(order);
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "WaitingArea") 
        {
            CheckProduct.orders.Add(this);
            arriveTime = Time.time;
            leaveTime = arriveTime + patience;
        }
    }
}