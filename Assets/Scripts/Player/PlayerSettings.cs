using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : MonoBehaviour
{
    public static float mouseSensitivity = 0.1f;
    public static int targetFrameRate = 144;

    void Start()
    {
        Application.targetFrameRate = targetFrameRate;
    }
}
