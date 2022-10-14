using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustomerWaitState : CustomerState
{
    public override void EnterState(CustomerController customer, CustomerOrder order)
    {
        order.arriveTime = Time.time;
        order.leaveTime = order.arriveTime + GameManager.Instance.patience;
        CheckProduct.Instance.orders.Add(order);
        if (PlayerStats.Instance.hasTablet) ShowOrders.Instance.CheckOrders();
        customer.GetComponentInChildren<UpdateWaitTime>().ratio = 1;
        customer.GetComponentInChildren<TextMeshProUGUI>().text = order.order.ToString();
        customer.GetComponentInChildren<Canvas>().enabled = true;
    }
    public override void UpdateState(CustomerController customer, CustomerOrder order)
    {
        float timeRemaining = order.leaveTime - Time.time;
        if (timeRemaining <= 0) {
            customer.GetComponentInChildren<UpdateWaitTime>().ratio = 0;
            customer.SwitchState(customer.GameOver);
        } else customer.GetComponentInChildren<UpdateWaitTime>().ratio = timeRemaining / GameManager.Instance.patience;
    }
    public override void OnTriggerEnter(CustomerController customer, Collider other)
    {
        
    }

    public void Leave(CustomerController customer)
    {
        customer.SwitchState(customer.LeaveState);
    }
}
