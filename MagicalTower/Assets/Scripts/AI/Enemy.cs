using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AVFramework;

public class Enemy : PoolObject, IGamePlayStartObserver
{
    [SerializeField] private float m_MoveSpeed;
    [SerializeField] private float m_HealthPoints;
    [SerializeField] private float m_DamageToTower;
    [SerializeField] private float m_AttackDelay = 3;

    private Vector3 m_TargetPosition;
    private Transform m_MyTransform;
    private float m_CurrentHealth;
    private bool m_IsVisible;
    private bool m_IsAttackedInvoked;

    protected virtual void Start()
    {
        m_MyTransform = transform;
        GameStateEventsObserver.Instance.RegisterGamePlayStartObserver(this);
    }

    public override void SetActive(bool active)
    {
        base.SetActive(active);

        if(active)
        {
            m_IsAttackedInvoked = false;
            m_CurrentHealth = m_HealthPoints;
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    public void SetTarget(Transform target)
    {
        m_TargetPosition = target.position;
    }

    protected virtual void Update()
    {
        if(Vector3.Distance(m_MyTransform.position, m_TargetPosition) > 3)
        {
            MoveTowardsTarget();
        }
        else
        {
            if(!m_IsAttackedInvoked)
            {
                DoAttack();
                m_IsAttackedInvoked = true;
            }           
        }
    }

    protected virtual void MoveTowardsTarget()
    {
        m_MyTransform.LookAt(m_TargetPosition);
        m_MyTransform.position = Vector3.MoveTowards(m_MyTransform.position, m_TargetPosition, m_MoveSpeed * Time.deltaTime);      
    }

    protected virtual void DoAttack()
    {
        PlayerManager.Instance.ReduceHealth(m_DamageToTower);
        Invoke("DoAttack", m_AttackDelay);
    }

    public virtual void OnDamage(float damage)
    {
        m_CurrentHealth -= damage;

        if(m_CurrentHealth <= 0)
        {
            OnDead();
        }
    }

    public virtual void OnDead()
    {
        CancelInvoke("DoAttack");
        AddObjectToPool();
    }

    protected virtual void OnBecameVisible()
    {
        m_IsVisible = true;
    }

    protected virtual void OnBecameInvisible()
    {
        m_IsVisible = false;
    }

    public bool IsVisible()
    {
        return m_IsVisible;
    }

    public void OnGamePlayStart()
    {
        
    }

    public void OnGamePlayStop()
    {
        enabled = false;
    }

    private void OnDestroy()
    {
        if(GameStateEventsObserver.Instance != null)
            GameStateEventsObserver.Instance.UnregisterGamePlayStartObserver(this);
    }
}
