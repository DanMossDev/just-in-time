using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject[] items;
    [SerializeField] int[] itemCounts;

    public List<GameObject> itemList = new List<GameObject>();

    public delegate void Restock();
    public static event Restock OnRestock;

    public static ObjectPool Instance {get; private set;}

    void Awake() {
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    void Start()
    {
        SpawnItems();
    }

    void SpawnItems()
    {
        for (int i = 0; i < items.Length; i++)
        {
            for (int j = 0; j < itemCounts[i]; j++)
            {
                GameObject newItem = Instantiate(items[i], transform);
                newItem.SetActive(false);
                itemList.Add(newItem);
            }
        }
        BeginRestock();
    }

    public void BeginRestock()
    {
        OnRestock();
    }
}
