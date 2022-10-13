using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject main;
    [SerializeField] GameObject options;
    void OnEnable() 
    {
        NavigationManager.Instance.ShowMouse();
    }

    void OnDisable() 
    {
        NavigationManager.Instance.HideMouse();
    }
    
    public void Resume()
    {
        gameObject.SetActive(false);
        main.SetActive(true);
        options.SetActive(false);
    }

    public void Options()
    {
        main.SetActive(!main.activeSelf);
        options.SetActive(!options.activeSelf);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
