using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AVFramework;
using UnityEngine.SceneManagement;

public class UILevelFailedScreen : UIScreen
{
   public void OnCickRestart()
    {
        SceneManager.LoadScene(0);
    }
}
