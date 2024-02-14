using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace AVFramework
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T mInstance;
        private static object _lock = new object();
        public static T Instance
        {
            get
            {
                if (mInstance == null)
                    mInstance = FindObjectOfType<T>();

                return mInstance;
            }
        }

        protected virtual void Awake()
        {
           // DontDestroyOnLoad(gameObject);
        }
    }
}

