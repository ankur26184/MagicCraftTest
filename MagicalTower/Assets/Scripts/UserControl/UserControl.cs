using AVFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControl : MonoBehaviour, IGamePlayStartObserver
{
    [SerializeField] private BaseSpellSpawnManager[] m_BaseSpellManager;

    // Start is called before the first frame update
    void Start()
    {
        GameStateEventsObserver.Instance.RegisterGamePlayStartObserver(this);
        this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            int rand = Random.Range(0, m_BaseSpellManager.Length);
            m_BaseSpellManager[rand].ShootSpell();
        }
    }

    public void OnGamePlayStart()
    {
        enabled = true;
    }

    public void OnGamePlayStop()
    {
        enabled = false;
    }

}
