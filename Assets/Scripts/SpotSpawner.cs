using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] items;
    void OnEnable()
    {
        ObjectPool.OnRestock += SpawnItem;
    }

    // Update is called once per frame
    void OnDisable()
    {
        ObjectPool.OnRestock -= SpawnItem;
    }

    void SpawnItem()
    {
        if (Random.value > 0.92f) 
        {
            GameObject item = ObjectPool.Instance.itemList[Random.Range(0, ObjectPool.Instance.itemList.Count)];
            item.transform.position = transform.position;
            item.transform.rotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
            item.gameObject.SetActive(true);
            ObjectPool.Instance.itemList.Remove(item);
        }
    }
}
