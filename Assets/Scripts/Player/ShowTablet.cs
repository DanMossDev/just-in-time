using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTablet : MonoBehaviour
{
    [SerializeField] GameObject tablet;
    void OnTab()
    {
        if (!PlayerStats.Instance.hasTablet) return;

        tablet.SetActive(!tablet.activeSelf);
    }
}
