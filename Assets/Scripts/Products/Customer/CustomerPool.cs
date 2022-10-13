using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerPool : MonoBehaviour
{
    [SerializeField] GameObject[] customerPrefabs;
    [SerializeField] int numOfCustomers;

    public static List<GameObject> customers = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < numOfCustomers; i++)
        {
            GameObject newCustomer = Instantiate(customerPrefabs[Random.Range(0, customerPrefabs.Length - 1)], transform);
            newCustomer.SetActive(false);
            customers.Add(newCustomer);
        }
    }
}
