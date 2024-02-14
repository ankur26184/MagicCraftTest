using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AVFramework;
public class GamePlayState : GameState
{
    public override void OnEnter()
    {
        base.OnEnter();

        GameStateEventsObserver.Instance.SendGamePlayStartEvent();
    }
}
