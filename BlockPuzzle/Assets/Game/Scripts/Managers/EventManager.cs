using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void OnGamePuase();
    public delegate void OnGameUnPuase();
    public delegate void OnGameStart(); 
    public delegate void OnGameEnd();
    public delegate void OnItemPalced(int index);
    public delegate void OnKill();
    public delegate void OnKillLayerUp();
    public delegate void OnScoreUp(int currentScore, int scoreUp, bool colorBonus);
    public delegate void OnBuy();
    public delegate void OnSelect();


    public event OnGamePuase onGamePause;
    public event OnGameUnPuase onGameUnPause;
    public event OnGameStart onGameStart;
    public event OnGameEnd onGameEnd;
    public event OnItemPalced onItemPlaced;
    public event OnKill onKill;
    public event OnKillLayerUp onKillLayerUp;
    public event OnScoreUp onScoreUp;
    public event OnBuy onBuy;
    public event OnSelect onSelect;
    public void Initialize() {
    }
    public void RunOnGamePause() {
        onGamePause();
    }
    public void RunOnGameUnPuase() {
        onGameUnPause();
    }
    public void RunOnGameStart() {
        onGameStart();
    }
    public void RunOnGameEnd() {
        onGameEnd();
    }
    public void RunOnItemPalced(int index) {
        onItemPlaced(index);
    }
    public void RunOnKill() {
        onKill();
    }
    public void RunOnKillLayerUp() {
        onKillLayerUp();
    }
    public void RunOnScoreUp(int currentScore, int scoreUp, bool colorBonus) {
        onScoreUp(currentScore, scoreUp, colorBonus);
    } 
    public void RunOnBuy() {
        onBuy();
    }
    public void RunOnSelect() {
        onSelect();
    }
}