using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingArea : MonoBehaviour
{
    public static Transform waitingArea;

    private void Awake() {
        waitingArea = transform;
    }
}