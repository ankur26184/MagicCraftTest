using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AVFramework;

public enum eGameStateType
{
    SPLASH_SCREEN_STATE,
    LEVEL_LOADING_STATE,
    MAIN_MENU_STATE,
    GAME_PLAY_STATE,
    LEVEL_COMPLETE_STATE,
    LEVEL_COMPLETE_SKIN_UNLOCK_STATE,
    LEVEL_COMPLETE_TRAIL_UNLOCK_STATE,
    LEVEL_FAILED_STATE,
    RETRY_STATE,
    STORE_STATE,    
    SHOP_SATE,
    PAUSE_STATE,  
    SETTINGS_STATE,
    RATE_US,
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
