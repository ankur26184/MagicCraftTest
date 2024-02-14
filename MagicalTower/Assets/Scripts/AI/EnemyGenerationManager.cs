using AVFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AVFramework;

[System.Serializable]
public class EnemySpawConfig
{
    public float m_LevelTime;
    public float m_SpawnDelay;
}
public class EnemyGenerationManager : Singleton<EnemyGenerationManager>, IGamePlayStartObserver
{
    [Header("Enter the values here to configure enemy spawn delay based on level")]
    [SerializeField] private List<EnemySpawConfig> m_EnemySpawnConfig;

    [Header("Assign Spawn point parent")]
    [SerializeField] private Transform m_SpawnPointsParent;

    [Header("Assign Enemy Object Pool Manager")]
    [SerializeField] private PoolManager m_EnemyPoolManager;

    [Header("Assign Target point")]
    [SerializeField] private Transform m_TargetPoint;

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
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        
        for(int i = 0; i < m_SpawnPointsParent.childCount; i++)
        {
            Enemy enemy = (Enemy)m_EnemyPoolManager.GetObject();
            float randomXOffset = Random.Range(-2, 2);
            float randomZOffset = Random.Range(-2, 2);
            enemy.transform.position = m_SpawnPointsParent.GetChild(i).transform.position;
            enemy.transform.position += new Vector3(randomXOffset, 0, randomZOffset);

            enemy.SetTarget(m_TargetPoint);
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

    public List<PoolObject> GetActiveEnemyList()
    {
       return m_EnemyPoolManager.GetActiveObjectList();
    }
}
