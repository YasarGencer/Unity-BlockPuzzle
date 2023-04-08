using Newtonsoft.Json.Bson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int Score { get; private set; }
    private int oldScore;
    public int ScoreMultiplier;
    private int killedLayerCount;
    bool isScoreUp;

    public void Initialize() {
        isScoreUp = false;
        Score = 0;
        killedLayerCount = 0;
        MainManager.Instance.EventManager.onKill += OnKill;
        MainManager.Instance.EventManager.onKillLayerUp += OnKillLayerUp;
    }

    private void OnKillLayerUp() { 
        killedLayerCount++;
    }

    private void OnKill() { 
        Score += ScoreMultiplier * killedLayerCount;
        Invoke("ScoreUp", .1f);
    } 
    private void ScoreUp() {
        if (isScoreUp == true)
            return;
        isScoreUp = true;

        MainManager.Instance.EventManager.RunOnScoreUp(Score, Score - oldScore);

        killedLayerCount = 0;
        oldScore = Score;

        Invoke("SetScoreUp", .15f);
    }
    void SetScoreUp() {
        isScoreUp = false;
    }
}
