using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePreWaveState : GameState
{
    public override void EnterState(GameManager manager) 
    {
        manager.OnStart();
    }
    public override void UpdateState(GameManager manager) {}
}
