using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWaveState : GameState
{
    public override void EnterState(GameManager manager) 
    {
        manager.servedCustomers = 0;
        manager.i = 0;
        manager.totalCustomers = (int)manager.waveProperties[manager.currentWave].x;
        GameManager.patience = manager.waveProperties[manager.currentWave].z;
        manager.BeginWave();
        //update display to show current wave
    }
    public override void UpdateState(GameManager manager) {}
}
