using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PostWaveMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI upgrade1;
    [SerializeField] TextMeshProUGUI upgrade2;
    enum Upgrades {
        DoubleSpeed,
        DoubleJumpHeight,
        OrderTablet,
        OrderMoreStock
    }
    void OnEnable()
    {
        NavigationManager.Instance.ShowMouse();

        var values = System.Enum.GetValues(typeof(Upgrades));
        upgrade1.text = ((Upgrades)Random.Range(0, values.Length)).ToString();
        upgrade2.text = ((Upgrades)Random.Range(0, values.Length)).ToString();
        while (upgrade1.text == upgrade2.text) upgrade2.text = ((Upgrades)Random.Range(0, values.Length)).ToString();
    }

    void OnDisable() 
    {
        NavigationManager.Instance.HideMouse();
    }

    public void Upgrade1()
    {
        Invoke(upgrade1.text, 0);
        GoToPreWave();
    }

    public void Upgrade2()
    {
        Invoke(upgrade2.text, 0);
        GoToPreWave();
    }

    void DoubleSpeed()
    {
        PlayerStats.moveSpeed += 1;
    }

    void DoubleJumpHeight()
    {
        PlayerStats.jumpHeight += 1;
    }

    // void IncreasePickupRange()
    // {
    //     PlayerStats.pickupRange += 1;
    // }

    void OrderTablet()
    {
        //Gain a UI screen which shows currently waiting orders and their time remaining
    }

    void OrderMoreStock()
    {
        ObjectPool.Instance.BeginRestock();
    }

    void GoToPreWave()
    {
        this.gameObject.SetActive(false);
        GameManager.Instance.ChangeState(GameManager.Instance.preWave);
    }
}
