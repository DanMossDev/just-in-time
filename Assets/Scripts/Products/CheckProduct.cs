using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckProduct : MonoBehaviour
{
    [SerializeField] AudioClip[] correctOrder;
    [SerializeField] AudioClip[] wrongOrder;
    public List<CustomerOrder> orders = new List<CustomerOrder>();

    public static CheckProduct Instance {get; private set;}

    private void Awake() 
    {
        if (Instance != null && Instance != this) Destroy(this); 
        else Instance = this; 
    }

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
                if (PlayerStats.Instance.hasTablet) ShowOrders.Instance.CheckOrders();
                SFXController.Instance.PlaySFX(correctOrder);
                return;
            }
        }
        SFXController.Instance.PlaySFX(wrongOrder);
    }
}
