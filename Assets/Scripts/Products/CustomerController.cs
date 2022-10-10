using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerController : MonoBehaviour
{
    void OnEnable() 
    {
        //Go and place order
    }
    public void Leave()
    {
        //Increase score, walk away, disable self until reenabling in pool
        print(GetComponent<CustomerOrder>().arriveTime);
    }
}
