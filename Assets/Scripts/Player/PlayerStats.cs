using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float moveSpeed = 8;
    public float jumpHeight = 3;
    public float pickupRange = 3;
    public bool hasCrouch = false;
    public bool hasTwoHands = false;
    public bool hasTablet = false;
    public bool hasSprint = false;

    public static PlayerStats Instance {get; private set;}

    void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this); 
        else Instance = this; 
    }
}
