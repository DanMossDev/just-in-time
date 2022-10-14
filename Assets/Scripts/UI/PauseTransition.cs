using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseTransition : MonoBehaviour
{
    RectTransform UItransform;
    void Awake()
    {
        UItransform = GetComponent<RectTransform>();
    }

    void OnEnable()
    {
        UItransform.transform.localPosition = new Vector3(0, -1350, 0);
        StartCoroutine(FlyUp());
    }

    IEnumerator FlyUp()
    {
        while (UItransform.transform.localPosition.y * 0.9f < -250) 
        {
            UItransform.transform.localPosition *= 0.9f;
            yield return new WaitForSecondsRealtime(0.02f);
        }
        UItransform.transform.localPosition = new Vector3(0, -250, 0);
    }
}
