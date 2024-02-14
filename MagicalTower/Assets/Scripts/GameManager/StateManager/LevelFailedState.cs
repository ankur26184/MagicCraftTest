using AVFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFailedState : GameState
{
    public override void OnEnter()
    {
        base.OnEnter();

        UIManager.Instance.m_UILevelFailedScreen.Show();
    }
}
