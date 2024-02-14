#define USE_SHOOT_EVENT
#define USE_LEVEL_COMPLETE_STATUS_EVENT

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AVFramework
{
    public class GameStateEventsObserver : Singleton<GameStateEventsObserver>
    {
        #region SHOOT_EVENT
#if USE_SHOOT_EVENT

        private List<IShootEventObserver> m_ShootEventObserversList = new List<IShootEventObserver>();

        public void RegisterShootObserver(IShootEventObserver observer)
        {
            if (!m_ShootEventObserversList.Contains(observer))
                m_ShootEventObserversList.Add(observer);
        }

        public void UnRegisterShootObserver(IShootEventObserver observer)
        {
            m_ShootEventObserversList.Remove(observer);
        }

        public void SendShootEventToObserversList()
        {
            foreach (IShootEventObserver observer in m_ShootEventObserversList)
                observer.RecieveEvent();

        }

#endif

        #endregion

        #region LEVEL_COMPLETE_STATUS_EVENT

#if USE_LEVEL_COMPLETE_STATUS_EVENT

        private List<ILevelCompleteStatusObserver> levelCompleteStatusObserverList = new List<ILevelCompleteStatusObserver>();
        public void RegisterLevelCompleteObserver(ILevelCompleteStatusObserver observer)
        {
            if (!levelCompleteStatusObserverList.Contains(observer))
                levelCompleteStatusObserverList.Add(observer);
        }

        public void UnRegisterLevelCompleteObserver(ILevelCompleteStatusObserver observer)
        {
            levelCompleteStatusObserverList.Remove(observer);
        }

        public void SendLevelCompleteEventToObserversList()
        {
            foreach (ILevelCompleteStatusObserver observer in levelCompleteStatusObserverList)
                observer.OnLevelComplete();

        }

        public void SendLevelFailEventToObserversList()
        {
            foreach (ILevelCompleteStatusObserver observer in levelCompleteStatusObserverList)
                observer.OnLevelFailed();
        }
#endif
        #endregion

        #region RETRY

        private List<ILevelRetryObserver> levelRetryObserverList = new List<ILevelRetryObserver>();

        public void RegisterLevelRetryObserver(ILevelRetryObserver levelRetryObserver)
        {
            levelRetryObserverList.Add(levelRetryObserver);
        }

        public void UnRegisterLevelRetryObserver(ILevelRetryObserver levelRetryObserver)
        {
            levelRetryObserverList.Remove(levelRetryObserver);
        }

        public void SendLevelRetryToObserverList()
        {
            foreach (ILevelRetryObserver levelRetryObserver in levelRetryObserverList)
                levelRetryObserver.Reset();
        }

        #endregion

        #region GAME_PLAY_START_EVENT
        private List<IGamePlayStartObserver> gameplayStartObserverList = new List<IGamePlayStartObserver>();
        
        public void RegisterGamePlayStartObserver(IGamePlayStartObserver observer)
        {
            gameplayStartObserverList.Add(observer);
        }

        public void UnregisterGamePlayStartObserver(IGamePlayStartObserver observer)
        {
            gameplayStartObserverList.Remove(observer);
        }

        public void SendGamePlayStartEvent()
        {
            foreach (IGamePlayStartObserver gamePlayStartObserver in gameplayStartObserverList)
                gamePlayStartObserver.OnGamePlayStart();
        }

        public void SendGamePlayStopEvent()
        {
            foreach (IGamePlayStartObserver gamePlayStartObserver in gameplayStartObserverList)
                gamePlayStartObserver.OnGamePlayStop();
        }
        #endregion

    }
}

