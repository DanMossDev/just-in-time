using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckProduct : MonoBehaviour
{
    public static List<CustomerOrder> orders = new List<CustomerOrder>();

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Interactable") || other.gameObject.layer == LayerMask.NameToLayer("HeldItem")) CheckForCustomer(other.gameObject.GetComponent<Interactable>());
    }

    void CheckForCustomer(Interactable item)
    {
        foreach (CustomerOrder order in orders)
        {
            if (order.order.ToString() == item.item.ToString())
            {
                order.gameObject.GetComponent<CustomerController>().Leave();
                orders.Remove(order);
                item.gameObject.SetActive(false);
                ObjectPool.Instance.itemList.Add(item.gameObject);
                break;
            }
        }
    }
}
