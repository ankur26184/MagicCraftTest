using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace AVFramework
{
    public abstract class ObjectStateManager : Singleton<ObjectStateManager>
    {
        protected ObjectState currentState;
        protected ObjectState previousState;
        protected Dictionary<string, ObjectState> statesDictionary = new Dictionary<string, ObjectState>();

        protected virtual void Start()
        {
            ObjectState[] arrayOfObjectsState = transform.GetComponents<ObjectState>();
            for (int i = 0; i < arrayOfObjectsState.Length; i++)
            {
                if (arrayOfObjectsState[i] != null)
                {
                    arrayOfObjectsState[i].Init();
                    RegisterState(arrayOfObjectsState[i]);
                }
            }
        }

        protected abstract void RegisterState(ObjectState objectState);
        protected virtual void RegisterState(string stateName, ObjectState objectState)
        {
            statesDictionary.Add(stateName, objectState);
        }
        protected virtual void Update()
        {
            if (currentState is IGameUpdate)
                ((IGameUpdate)currentState).OnUpdate();
        }

        protected virtual void LateUpdate()
        {
            if (currentState is ILateUpdate)
                ((ILateUpdate)currentState).OnLateUpdate();
        }

        public void ChangeStateTo(string stateName)
        {
            ChangeStateTo(statesDictionary[stateName]);
        }
        public void ChangeStateTo(ObjectState newState)
        {
            if (currentState != null)
                currentState.OnExit();

            if (currentState != newState)
            {
                previousState = currentState;
                currentState = newState;
                newState.OnEnter();
            }

        }

        public ObjectState GetPreviousState()
        {
            return previousState;
        }

        public ObjectState GetCurrentState()
        {
            return currentState;
        }
    }
}

