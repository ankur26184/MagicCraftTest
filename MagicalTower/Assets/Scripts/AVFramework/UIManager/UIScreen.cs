using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AVFramework
{
    public class UIScreen : MonoBehaviour
    {

        // Start is called before the first frame update
        protected virtual void Start()
        {
   
        }

        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }      
    }
}

