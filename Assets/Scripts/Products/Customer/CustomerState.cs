using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CustomerState
{
    public abstract void EnterState(CustomerController customer, CustomerOrder order);
    public abstract void UpdateState(CustomerController customer, CustomerOrder order);
    public abstract void OnTriggerEnter(CustomerController customer, Collider other);
}
