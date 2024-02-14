using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AVFramework;

public enum eGameStateType
{
    GAME_PLAY_STATE,
    LEVEL_COMPLETE_STATE,
    LEVEL_FAILED_STATE,
}
public class GameStateManager : ObjectStateManager
{
    protected override void RegisterState(ObjectState objectState)
    {
        GameState gameState = (GameState)objectState;
        RegisterState(gameState.gameStateType.ToString(), gameState);
    }

    public void ChangeStateTo(eGameStateType gameStateType)
    {       
        ChangeStateTo(statesDictionary[gameStateType.ToString()]);
    }
}
