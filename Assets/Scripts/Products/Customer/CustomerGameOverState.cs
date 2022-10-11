using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerGameOverState : CustomerState
{
    public override void EnterState(CustomerController customer, CustomerOrder order)
    {
        //Go to a game over screen
    }
    public override void UpdateState(CustomerController customer, CustomerOrder order)
    {

    }
    public override void OnTriggerEnter(CustomerController customer, Collider other)
    {
        
    }
}
