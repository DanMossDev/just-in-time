using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateWaitTime : MonoBehaviour
{
    float startWidth;
    float height;
    public float ratio = 1;
    RectTransform bar;
    void Start()
    {
        bar = GetComponent<RectTransform>();
        startWidth = bar.sizeDelta.x;
        height = bar.sizeDelta.y;
    }
    void Update()
    {
        bar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, startWidth * ratio);
    }
}
