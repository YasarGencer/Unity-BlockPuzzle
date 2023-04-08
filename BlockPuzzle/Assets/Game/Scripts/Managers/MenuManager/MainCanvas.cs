using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static EventManager;

public class MainCanvas : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI scoreText, scoreUpText;
    public void Initialize() {
        MainManager.Instance.EventManager.onScoreUp += OnScoreUp;
        scoreText.SetText("0"); 
    } 
    public void OnScoreUp(int currentSocre, int scoreUp) {
        scoreText.SetText(currentSocre.ToString());
        scoreUpText.SetText("+" + scoreUp.ToString());

        scoreUpText.GetComponent<CanvasGroup>().DOFade(1, .25f).SetEase(Ease.OutCirc).OnComplete(() =>
            scoreUpText.GetComponent<CanvasGroup>().DOFade(0, 1f).SetEase(Ease.InCirc)
        );
    }
}
