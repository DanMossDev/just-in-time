using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerPool : MonoBehaviour
{
    [SerializeField] GameObject[] customerPrefabs;
    [SerializeField] int totalCustomersInPool;
    [HideInInspector] public List<GameObject> customers = new List<GameObject>();
    public static CustomerPool Instance {get; private set;}


    void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this); 
        else Instance = this;
    }

    void Start()
    {
        for (int i = 0; i < totalCustomersInPool; i++)
        {
            GameObject newCustomer = Instantiate(customerPrefabs[Random.Range(0, customerPrefabs.Length - 1)], transform);
            newCustomer.SetActive(false);
            customers.Add(newCustomer);
        }
    }
}
