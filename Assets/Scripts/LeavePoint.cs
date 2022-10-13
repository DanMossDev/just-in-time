using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavePoint : MonoBehaviour
{
    public static Transform leavePoint;

    private void Awake() {
        leavePoint = transform;
    }
}
