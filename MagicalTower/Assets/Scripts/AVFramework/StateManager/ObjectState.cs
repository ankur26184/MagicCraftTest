using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectState : MonoBehaviour
{
    public abstract void Init();

    public abstract void OnEnter();
    public abstract void OnExit();

}
