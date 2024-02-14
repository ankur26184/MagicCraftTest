using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace AVFramework
{
    public class Updater : Singleton<Updater>
    {
        public Action OnBackCallback = null;
		private List<IGameUpdate> updateClassList = new List<IGameUpdate>();
		private List<ILateUpdate> lateUpdateClassList = new List<ILateUpdate>();
		public void RegsiterUpdate(IGameUpdate updateClass)
		{
			updateClassList.Add(updateClass);
		}

		public void UnRegsiterUpdate(IGameUpdate updateClass)
		{
			updateClassList.Remove(updateClass);
		}

        public void RegsiterLateUpdate(ILateUpdate lateUpdateClass)
        {
            lateUpdateClassList.Add(lateUpdateClass);
        }

        public void UnRegsiterLateUpdate(ILateUpdate lateUpdateClass)
        {
            lateUpdateClassList.Remove(lateUpdateClass);
        }

        private void Update()
		{
			foreach (IGameUpdate observer in updateClassList)
            {
                if (observer != null)
                    observer.OnUpdate();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
                OnBackCallback?.Invoke();

		}

        private void LateUpdate()
        {
            foreach (ILateUpdate observer in lateUpdateClassList)
            {
                if (observer != null)
                    observer.OnLateUpdate();
            }
        }
    }
}

