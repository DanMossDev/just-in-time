using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PostWaveMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI upgrade1;
    [SerializeField] TextMeshProUGUI upgrade2;
    enum Upgrades {
        IncreaseSpeed,
        DoubleSpeed,
        DoubleJumpHeight,
        OrderTablet,
        OrderMoreStock,
        DoPilates,
        HireCoworker,
        BecomeAmbidextrous
    }

    List<string> AlreadyUpgraded = new List<string>();

    string upgrade1Choice, upgrade2Choice;
    void OnEnable()
    {
        NavigationManager.Instance.ShowMouse();

        var values = System.Enum.GetValues(typeof(Upgrades));
        upgrade1Choice = ((Upgrades)Random.Range(0, values.Length)).ToString();
        while (AlreadyUpgraded.Contains(upgrade1Choice)) upgrade1Choice = ((Upgrades)Random.Range(0, values.Length)).ToString();
        upgrade2Choice = ((Upgrades)Random.Range(0, values.Length)).ToString();
        while (upgrade1Choice == upgrade2Choice || AlreadyUpgraded.Contains(upgrade2Choice)) upgrade2Choice = ((Upgrades)Random.Range(0, values.Length)).ToString();

        upgrade1.text = GenerateFlavourText(upgrade1Choice);
        upgrade2.text = GenerateFlavourText(upgrade2Choice);
    }

    string GenerateFlavourText(string choice) 
    {
        switch(choice)
        {
            case "IncreaseSpeed":
                return $"Increase Speed:{System.Environment.NewLine}All the cardio is paying off!";
            case "DoubleSpeed":
                return $"Double Speed:{System.Environment.NewLine}It's probably safe...";
            case "DoubleJumpHeight":
                return $"Double Jump Height:{System.Environment.NewLine}Just don't question it";
            case "OrderTablet":
                return $"Buy a Tablet:{System.Environment.NewLine}View orders from far away";
            case "OrderMoreStock":
                return $"Order More Stock:{System.Environment.NewLine}Isn't this someone else's job?";
            case "DoPilates":
                return $"Do Pilates:{System.Environment.NewLine}You feel more flexible just thinking about it!";
            case "HireCoworker":
                return $"Hire a Coworker:{System.Environment.NewLine}He's a bit slow but he's trying";
            case "BecomeAmbidextrous":
                return $"Become Ambidextrous:{System.Environment.NewLine}Look ma, both hands!";
            default:
                return $"Oops";
        }
    }

    void OnDisable() 
    {
        NavigationManager.Instance.HideMouse();
    }

    public void Upgrade1()
    {
        Invoke(upgrade1Choice, 0);
        GoToPreWave();
    }

    public void Upgrade2()
    {
        Invoke(upgrade2Choice, 0);
        GoToPreWave();
    }

    void IncreaseSpeed()
    {
        PlayerStats.moveSpeed += 2;
    }

    void DoubleSpeed()
    {
        PlayerStats.moveSpeed *= 2;
        AlreadyUpgraded.Add("DoubleSpeed");
    }

    void DoubleJumpHeight()
    {
        PlayerStats.jumpHeight *= 2;
        AlreadyUpgraded.Add("DoubleJumpHeight");
    }

    void OrderTablet()
    {
        //Gain a UI screen which shows currently waiting orders and their time remaining
        AlreadyUpgraded.Add("OrderTablet");
    }

    void OrderMoreStock()
    {
        ObjectPool.Instance.BeginRestock();
    }

    void DoPilates()
    {
        PlayerStats.hasCrouch = true;
        AlreadyUpgraded.Add("DoPilates");
    }

    void HireCoworker()
    {
        //hire an AI coworker who brings items at the back to the front
        AlreadyUpgraded.Add("HireCoworker");
    }

    void BecomeAmbidextrous()
    {
        PlayerStats.hasTwoHands = true;
        AlreadyUpgraded.Add("BecomeAmbidextrous");
    }

    void GoToPreWave()
    {
        this.gameObject.SetActive(false);
        GameManager.Instance.ChangeState(GameManager.Instance.preWave);
    }
}
