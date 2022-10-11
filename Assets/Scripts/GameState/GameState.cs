using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState
{
    public abstract void EnterState(GameManager manager);
    public abstract void UpdateState(GameManager manager);
}
