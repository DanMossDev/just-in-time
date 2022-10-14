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
    [SerializeField] Transform rightHand;
    [SerializeField] Transform leftHand;
    [SerializeField] LayerMask hitLayer;
    Rigidbody rigidBody;
    GameObject target;
    GameObject heldRightHand;
    GameObject heldLeftHand;

    void Start() 
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update() 
    {
        RaycastHit hit;
        if (Physics.SphereCast(Camera.main.transform.position, 0.5f, Camera.main.transform.forward, out hit, PlayerStats.Instance.pickupRange, hitLayer, QueryTriggerInteraction.Ignore))
            target = hit.collider.gameObject;
        else target = null;
    }

    void OnInteract()
    {
        if (PlayerStats.Instance.hasTwoHands)
        {
            if (heldRightHand != null && heldLeftHand != null) Drop(true);
            else if (target != null) Pickup();
            else if (heldRightHand != null) Drop(false);
        } else
        {
            if (heldRightHand != null) Drop(false);
            else if (target != null) Pickup();
        }
    }

    void Pickup()
    {
        target.GetComponent<Rigidbody>().isKinematic = true;
        target.layer = LayerMask.NameToLayer("HeldItem");
        if (heldRightHand == null) 
        {
            target.transform.parent = rightHand;
            heldRightHand = target;
        } else
        {
            target.transform.parent = leftHand;
            heldLeftHand = target;
        }

        target.transform.localPosition = Vector3.zero;
    }

    void Drop(bool leftHandUsed)
    {
        Rigidbody heldRB = heldRightHand.GetComponent<Rigidbody>();
        heldRB.isKinematic = false;
        heldRightHand.layer = LayerMask.NameToLayer("Interactable");
        heldRB.AddForce(Camera.main.transform.TransformDirection(dropForce), ForceMode.Impulse);
        heldRightHand.transform.parent = null;
        heldRightHand = null;

        if (!leftHandUsed) return;

        heldRB = heldLeftHand.GetComponent<Rigidbody>();
        heldRB.isKinematic = false;
        heldLeftHand.layer = LayerMask.NameToLayer("Interactable");
        heldRB.AddForce(Camera.main.transform.TransformDirection(dropForce), ForceMode.Impulse);
        heldLeftHand.transform.parent = null;
        heldLeftHand = null;
    }
}
