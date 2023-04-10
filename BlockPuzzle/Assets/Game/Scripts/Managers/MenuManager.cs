using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] MenuCanvas menuCanvas;
    [SerializeField] GameCanvas gameCanvas;
    [SerializeField] EndCanvas endCanvas;
    public MenuCanvas MenuCanvas { get { return menuCanvas; } }
    public GameCanvas GameCanvas { get { return gameCanvas; } }
    public EndCanvas EndCanvas { get { return endCanvas; } }

    public void Initialize() {
        menuCanvas.Initialize();
        gameCanvas.Initialize();
        endCanvas.Initialize(); 
        MainManager.Instance.EventManager.onGameEnd += GameEnd;
    }
    void GameEnd() {
        endCanvas.Open();
    }
}
