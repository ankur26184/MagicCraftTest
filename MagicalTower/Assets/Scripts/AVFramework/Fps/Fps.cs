using AVFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fps : MonoBehaviour
{
    float deltaTime = 0f;
    int fps;
    private void Start()
    {
        Application.targetFrameRate = 120;
    }
    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        fps =  Mathf.RoundToInt(1f / deltaTime);
    }

    void OnGUI()
    {
        int fps = Mathf.RoundToInt(1f / deltaTime);
        string text = $"FPS: {fps}";
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.fontSize = 24;
        style.normal.textColor = Color.white;

        GUI.Label(new Rect(10, 10, 100, 50), text, style);
    }
}
