using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowOrders : MonoBehaviour
{
    TextMeshProUGUI orderText;
    List<Items> items = new List<Items>();
    int boxCount = 0;
    int computerCount = 0;
    int ballCount = 0;

    public static ShowOrders Instance {get; private set;}

    private void Awake() 
    {
        if (Instance != null && Instance != this) Destroy(this); 
        else Instance = this; 
    }

    private void Start() 
    {
        orderText = GetComponent<TextMeshProUGUI>();
        CheckOrders();
    }


    public void CheckOrders()
    {
        boxCount = 0;
        computerCount = 0;
        ballCount = 0;
        foreach (CustomerOrder order in CheckProduct.Instance.orders)
        {
            switch (order.order.ToString())
            {
                case "Box":
                    boxCount++;
                    break;
                case "Computer":
                    computerCount++;
                    break;
                case "Ball":
                    ballCount++;
                    break;
                default:
                    break;
            }
        }

        orderText.text = $"Box: {boxCount}{System.Environment.NewLine + System.Environment.NewLine}Computer: {computerCount}{System.Environment.NewLine + System.Environment.NewLine}Ball: {ballCount}";
    }
}
