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
        UIManager.Instance.m_UIGamePlayScreen.Show();

    }
    public override void OnExit()
    {
        base.OnExit();

        GameStateEventsObserver.Instance.SendGamePlayStopEvent();
        UIManager.Instance.m_UIGamePlayScreen.Hide();
    }
}
