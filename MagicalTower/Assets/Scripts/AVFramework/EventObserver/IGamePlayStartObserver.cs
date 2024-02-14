using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGamePlayStartObserver
{
    void OnGamePlayStart();
    void OnGamePlayStop();
}
