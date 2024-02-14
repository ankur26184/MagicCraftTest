using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevelCompleteStatusObserver
{
    void OnLevelComplete();
    void OnLevelFailed();
}

