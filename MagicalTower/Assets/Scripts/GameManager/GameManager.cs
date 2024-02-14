using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AVFramework;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameStateManager m_GameStateManager;

    void Start()
    {
        StartCoroutine(SetGamePlayState());
    }

    private IEnumerator SetGamePlayState()
    {
        yield return new WaitForEndOfFrame();

        m_GameStateManager.ChangeStateTo(eGameStateType.GAME_PLAY_STATE);
    }

    public void ChangeStateTo(eGameStateType gameStateType)
    {
        m_GameStateManager.ChangeStateTo(gameStateType);
    }

    public GameState GetPreviousState()
    {
        return (GameState)m_GameStateManager.GetPreviousState();
    }

    public GameState GetCurrentState()
    {
        return (GameState)m_GameStateManager.GetCurrentState();
    }
}
