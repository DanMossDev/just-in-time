using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerLeaveState : CustomerState
{
    public delegate void CustomerServed();
    public static event CustomerServed OnCustomerServed;
    public override void EnterState(CustomerController customer, CustomerOrder order)
    {
        customer.GetComponentInChildren<Canvas>().enabled = false;
        OnCustomerServed();
    }
    public override void UpdateState(CustomerController customer, CustomerOrder order)
    {

    }
    public override void OnTriggerEnter(CustomerController customer, Collider other)
    {
        
    }
}
