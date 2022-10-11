using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerEnteringState : CustomerState
{
    public override void EnterState(CustomerController customer, CustomerOrder order)
    {
        customer.GetComponentInChildren<Canvas>().enabled = false;
    }
    public override void UpdateState(CustomerController customer, CustomerOrder order)
    {
        //Walk towards the waiting area
    }
    public override void OnTriggerEnter(CustomerController customer, Collider other)
    {
        if (other.tag == "WaitingArea") customer.SwitchState(customer.WaitState);
    }
}
