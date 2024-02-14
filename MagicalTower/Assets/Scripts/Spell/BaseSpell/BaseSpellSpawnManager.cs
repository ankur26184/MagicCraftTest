using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AVFramework;
using UnityEngine.Video;

public abstract class BaseSpellSpawnManager : MonoBehaviour
{
    [SerializeField] protected PoolManager m_SpellPoolManager;
   public virtual T GetSpell<T>() where T : BaseSpell
    {
       return  m_SpellPoolManager.GetObject() as T;
    }

    public abstract void ShootSpell();
}
