using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerWaitState : CustomerState
{
    public override void EnterState(CustomerController customer)
    {
        Debug.Log("Wait state");
        //Spawn a waiting bar over their head
    }
    public override void UpdateState(CustomerController customer, CustomerOrder order)
    {
        float timeRemaining = order.leaveTime - Time.time;
        if (timeRemaining < 0) customer.SwitchState(customer.GameOver);
        //Update waiting bar to be a ratio of time remaining divided by patience
    }
    public override void OnTriggerEnter(CustomerController customer, Collider other)
    {
        
    }

    public void Leave(CustomerController customer)
    {
        customer.SwitchState(customer.LeaveState);
    }
}
