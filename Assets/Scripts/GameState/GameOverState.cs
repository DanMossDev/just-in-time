using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : GameState
{
    public override void EnterState(GameManager manager) 
    {
        manager.gameOverScreen.gameObject.SetActive(true);
    }
    public override void UpdateState(GameManager manager) {}

}
