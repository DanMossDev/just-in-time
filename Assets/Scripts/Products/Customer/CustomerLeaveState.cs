using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerLeaveState : CustomerState
{
    public override void EnterState(CustomerController customer)
    {
        Debug.Log("Leave state");
    }
    public override void UpdateState(CustomerController customer, CustomerOrder order)
    {

    }
    public override void OnTriggerEnter(CustomerController customer, Collider other)
    {
        
    }
}
