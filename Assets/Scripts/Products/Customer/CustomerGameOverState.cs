using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerGameOverState : CustomerState
{
    public override void EnterState(CustomerController customer, CustomerOrder order)
    {
        GameManager.Instance.ChangeState(GameManager.Instance.gameOver);
    }
    public override void UpdateState(CustomerController customer, CustomerOrder order)
    {

    }
    public override void OnTriggerEnter(CustomerController customer, Collider other)
    {
        
    }
}
