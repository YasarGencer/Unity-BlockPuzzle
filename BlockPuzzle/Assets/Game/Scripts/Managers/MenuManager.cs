using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] MainCanvas mainCanvas;
    [SerializeField] EndCanvas endCanvas;
    public MainCanvas MainCanvas { get { return mainCanvas; } }
    public EndCanvas EndCanvas { get { return endCanvas; } }

    public void Initialize() {
        mainCanvas.Initialize();
        endCanvas.Initialize(); 
        MainManager.Instance.EventManager.onGameEnd += GameEnd;
    }
    void GameEnd() {
        endCanvas.Open();
    }
}
