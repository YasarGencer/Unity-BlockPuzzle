using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public void Initialize() {
        MainManager.Instance.EventManager.onGameEnd += SetCoin;
    }

    void SetCoin() {
        PlayerPrefs.SetInt("coin",GetCoin() + GetGainedCoin());
    }
    public int GetGainedCoin() {
        return MainManager.Instance.ScoreManager.Score / 10;
    }
    public int GetCoin() {
        return PlayerPrefs.GetInt("coin", 0);
    }
}
