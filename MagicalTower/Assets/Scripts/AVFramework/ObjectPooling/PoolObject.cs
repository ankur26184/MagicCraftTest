using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AVFramework
{
    public class PoolObject : MonoBehaviour
    {
        private PoolManager poolManager;
        protected bool isActive;

        public virtual void SetActive(bool active)
        {
            isActive = active;
            enabled = active;
        }

        public virtual bool IsActive()
        {
            return isActive;
        }
        public void SetPoolManager(PoolManager poolManager)
        {
            this.poolManager = poolManager;
        }
        public virtual void AddObjectToPool()
        {
            if (poolManager != null)
                poolManager.AddObject(this);
            else
                Destroy(gameObject);
        }
    }
}

