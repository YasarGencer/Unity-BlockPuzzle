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
    bool colorBonus;

    public void Initialize() {
        isScoreUp = false;
        colorBonus = false;
        Score = 0;
        killedLayerCount = 0;
        MainManager.Instance.EventManager.onKill += OnKill;
        MainManager.Instance.EventManager.onKillLayerUp += OnKillLayerUp;
        MainManager.Instance.EventManager.onGameEnd += SetHighscores;
    }

    private void OnKillLayerUp() { 
        killedLayerCount++;
    }

    private void OnKill() { 
        Score += ScoreMultiplier * killedLayerCount;
        Invoke("ScoreUp", .1f);
    } 
    public void ColorBonus() {
        colorBonus = true;
    }
    private void ScoreUp() {
        if (isScoreUp == true)
            return;
        isScoreUp = true;

        if (colorBonus)
            Score += Score - oldScore;

        MainManager.Instance.EventManager.RunOnScoreUp(Score, Score - oldScore, colorBonus);

        killedLayerCount = 0;
        oldScore = Score;
        colorBonus = false;

        Invoke("SetScoreUp", .15f);
    }
    void SetScoreUp() {
        isScoreUp = false;
    }
    void SetHighscores() {
        var score1 = GetHighscore(1);
        var score2 = GetHighscore(2);
        var score3 = GetHighscore(3);


        if (Score >= score1) {
            SetHighscore(1, Score);
            SetHighscore(2,score1);  
            SetHighscore(3,score2);  
        } else if (Score >= score2) {
            SetHighscore(2, Score);
            SetHighscore(3, score2);
        }
        else if (Score > score3)
            SetHighscore(3, Score);
    }
    public int GetHighscore(int index) {
        return PlayerPrefs.GetInt("hs" + index, 0);
    }
    void SetHighscore(int index, int value) {
        PlayerPrefs.SetInt("hs" + index, value);
    }

}
