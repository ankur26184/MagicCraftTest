
using UnityEngine;
using AVFramework;

public class PlayerManager : Singleton<PlayerManager>, IGamePlayStartObserver
{
    [SerializeField] private float m_MaxHealth;

    private float m_CurrentHealth;

    private void Start()
    {
       GameStateEventsObserver.Instance.RegisterGamePlayStartObserver(this);
        enabled = false;
    }
    public void ReduceHealth(float reduceAmount)
    {
        m_CurrentHealth -= reduceAmount;
        UIManager.Instance.m_UIGamePlayScreen.SetHealthFillAmount(m_CurrentHealth);

        if (m_CurrentHealth <= 0)
            GameManager.Instance.ChangeStateTo(eGameStateType.LEVEL_FAILED_STATE);
    }

    public void OnGamePlayStart()
    {
        m_CurrentHealth = 1;
        enabled = true;
    }

    public void OnGamePlayStop()
    {
       enabled = false;
    }

    private void OnDestroy()
    {
        if (GameStateEventsObserver.Instance != null)
            GameStateEventsObserver.Instance.UnregisterGamePlayStartObserver(this);
    }
}
