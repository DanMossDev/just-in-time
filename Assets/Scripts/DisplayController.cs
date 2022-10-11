using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI customersRemaining;
    [SerializeField] TextMeshProUGUI waveCounter;
    [SerializeField] TextMeshProUGUI timer;
    
    
    void Update()
    {
        customersRemaining.text = "Customers Remaining: " + GameManager.customersRemaining;
        waveCounter.text = "Current Wave: " + GameManager.currentWave;
        timer.text = "" + (int)GameManager.timeRemaining;
    }
    
}
