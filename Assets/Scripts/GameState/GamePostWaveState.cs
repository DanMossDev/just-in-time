using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePostWaveState : GameState
{
    public override void EnterState(GameManager manager) 
    {
        manager.postWaveScreen.SetActive(true);
    }
    public override void UpdateState(GameManager manager) {}
}
