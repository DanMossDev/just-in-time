using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [Space]
    [Header("Game Feel")]
    [SerializeField] Vector3 dropForce;

    [Space]
    [Header("Transforms and Prefabs")]
    [SerializeField] Transform itemHolder;
    [SerializeField] LayerMask hitLayer;
    Rigidbody rigidBody;
    GameObject target;
    GameObject held;

    void Start() 
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update() 
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, PlayerStats.pickupRange, hitLayer, QueryTriggerInteraction.Ignore))
            target = hit.collider.gameObject;
        else target = null;
    }

    void OnInteract()
    {
        if (held != null) Drop();
        else if (target != null) Pickup();
    }

    void Pickup()
    {
        target.GetComponent<Rigidbody>().isKinematic = true;
        target.layer = LayerMask.NameToLayer("HeldItem");
        target.transform.parent = itemHolder;
        target.transform.localPosition = Vector3.zero;
        held = target;
    }

    void Drop()
    {
        Rigidbody heldRB = held.GetComponent<Rigidbody>();
        heldRB.isKinematic = false;
        held.layer = LayerMask.NameToLayer("Interactable");
        heldRB.AddForce(Camera.main.transform.TransformDirection(dropForce), ForceMode.Impulse);
        held.transform.parent = null;
        held = null;
    }
}
