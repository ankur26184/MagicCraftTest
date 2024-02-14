using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AVFramework;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameStateManager gameStateManager;

    void Start()
    {
        gameStateManager.ChangeStateTo(eGameStateType.SPLASH_SCREEN_STATE);
    }

    public void ChangeStateTo(eGameStateType gameStateType)
    {
        gameStateManager.ChangeStateTo(gameStateType);
    }

    public GameState GetPreviousState()
    {
        return (GameState)gameStateManager.GetPreviousState();
    }

    public GameState GetCurrentState()
    {
        return (GameState)gameStateManager.GetCurrentState();
    }
}
