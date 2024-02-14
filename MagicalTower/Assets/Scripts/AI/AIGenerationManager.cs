using AVFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemySpawConfig
{
    public float m_LevelTime;
    public float m_SpawnDelay;
}
public class AIGenerationManager : MonoBehaviour, IGamePlayStartObserver
{
    [SerializeField] private List<EnemySpawConfig> m_EnemySpawnConfig;
    [SerializeField] private float m_MinX;
    [SerializeField] private float m_MaxX;

    private float m_SpawnDelay;
    private float m_CurrentLevelTime;
    private int m_LevelIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameStateEventsObserver.Instance.RegisterGamePlayStartObserver(this);
    }

    // Update is called once per frame
    void Update()
    {
        CheckForLevel();
        CheckForEnemySpawn();
    }

    private void CheckForLevel()
    {
        m_CurrentLevelTime += Time.deltaTime;

        if(m_CurrentLevelTime >= m_EnemySpawnConfig[m_LevelIndex].m_LevelTime
            && m_LevelIndex < m_EnemySpawnConfig.Count - 1)
        {
            m_LevelIndex++;
            m_SpawnDelay = m_EnemySpawnConfig[m_LevelIndex].m_SpawnDelay;
        }
    }

    private void CheckForEnemySpawn()
    {
        m_SpawnDelay -= Time.deltaTime;
        if (m_SpawnDelay <= 0)
        {
            //Create Enemy
            m_SpawnDelay = m_EnemySpawnConfig[m_LevelIndex].m_SpawnDelay;
        }
    }

    public void OnGamePlayStart()
    {
        this.enabled = true;
        m_LevelIndex = 0;
    }

    public void  OnGamePlayStop()
    {
        this.enabled = false;
    }

    private void OnDestroy()
    {
        if (GameStateEventsObserver.Instance != null)
            GameStateEventsObserver.Instance.UnregisterGamePlayStartObserver(this);
    }
}
