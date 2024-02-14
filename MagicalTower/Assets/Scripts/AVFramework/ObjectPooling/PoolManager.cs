using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AVFramework
{
    public class PoolManager : MonoBehaviour
    {
        public GameObject[] prefab;
        protected List<PoolObject> unUsedObjectsList = new List<PoolObject>();
        protected List<PoolObject> usedObjectsList = new List<PoolObject>();

        protected virtual void Update()
        {
            if (usedObjectsList.Count > 0)
            {
                for(int i = 0; i < usedObjectsList.Count; i++)
                {
                    if (usedObjectsList[i] is IGameUpdate)
                        ((IGameUpdate)usedObjectsList[i]).OnUpdate();
                }
            }

        }
        public void AddObject(PoolObject obj)
        {

            if (usedObjectsList.Contains(obj))
                usedObjectsList.Remove(obj);

            obj.SetActive(false);
            if(!unUsedObjectsList.Contains(obj))
                unUsedObjectsList.Add(obj);
        }

        public PoolObject GetObject(Transform parent = null)
        {
            PoolObject obj;
            if (unUsedObjectsList.Count > 0)
            {
                obj = unUsedObjectsList[0];
                unUsedObjectsList.RemoveAt(0);
            }
            else
            {
                int index = Random.Range(0, prefab.Length);
                GameObject go = Instantiate(prefab[index]);
                obj = go.GetComponent<PoolObject>();
                obj.SetPoolManager(this);

            }

            if (parent != null)
                obj.transform.parent = parent;
            obj.SetActive(true);
            usedObjectsList.Add(obj);

            return obj;
        }

        public void DestroyPoolManager(bool destroyUsed = false)
        {
            for (int i = 0; i < unUsedObjectsList.Count; i++)
            {
                if(unUsedObjectsList[i] != null)
                    Destroy(unUsedObjectsList[i].gameObject);
            }
            unUsedObjectsList.Clear();

            if(destroyUsed)
            {
                for (int i = 0; i < usedObjectsList.Count; i++)
                {
                    if (usedObjectsList[i] != null)
                        Destroy(usedObjectsList[i].gameObject);
                }
                usedObjectsList.Clear();
            }

            Destroy(gameObject);
        }

        public List<PoolObject> GetActiveObjectList()
        {
            return usedObjectsList;
        }
    }
}
