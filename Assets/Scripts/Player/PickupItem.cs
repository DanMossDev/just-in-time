using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [Space]
    [Header("Game Feel")]
    [SerializeField] Vector2 dropForce;

    [Space]
    [Header("Transforms and Prefabs")]
    [SerializeField] Transform itemHolder;
    [SerializeField] LayerMask hitLayer;
    Rigidbody rigidBody;

    GameObject target;
    GameObject held;
    
    bool hasItem;

    void Update() 
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, PlayerStats.pickupRange, hitLayer, QueryTriggerInteraction.Ignore))
        {
            target = hit.collider.gameObject;
        }
    }

    void OnDrop()
    {
        
    }

    void OnInteract()
    {
        if (hasItem){} //Drop();
        else if (target != null) Pickup();
    }

    void Pickup()
    {
        target.GetComponent<Rigidbody>().isKinematic = true;
        target.GetComponent<Rigidbody>().detectCollisions = false;
        target.transform.parent = itemHolder;
        target.transform.localPosition = Vector3.zero;
    }
}
