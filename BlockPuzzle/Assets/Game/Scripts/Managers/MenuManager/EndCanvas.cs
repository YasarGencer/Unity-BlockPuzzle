
using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndCanvas : UI {
    [Header("ANIMATIONS")]
    [SerializeField] CanvasGroup[] inPanel;
    [SerializeField] CanvasGroup[] buttons;
    [Header("UTILITIES")]
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highscoreText1, highscoreText2, highscoreText3;
    [SerializeField] TextMeshProUGUI coinText, gainedCoinText;
    public override void Initialize() {
        base.Initialize();
        Close(); 
    }
    public override void Close() {
        gameObject.SetActive(false);
    }
    public override void Open() {
        base.Open();
        StartCoroutine(IOpen());
        scoreText.SetText(MainManager.Instance.ScoreManager.Score.ToString());
        highscoreText1.SetText(MainManager.Instance.ScoreManager.GetHighscore(1).ToString());
        highscoreText2.SetText(MainManager.Instance.ScoreManager.GetHighscore(2).ToString());
        highscoreText3.SetText(MainManager.Instance.ScoreManager.GetHighscore(3).ToString());
        coinText.SetText(MainManager.Instance.CoinManager.GetCoin().ToString());
        gainedCoinText.SetText("+" + MainManager.Instance.CoinManager.GetGainedCoin().ToString());
    }
    IEnumerator IOpen() {
        for (int i = 0; i < inPanel.Length; i++)
            inPanel[i].DOFade(0, 0);
        for (int i = 0; i < buttons.Length; i++)
            buttons[i].DOFade(0, 0);
        yield return new WaitForSeconds(.25f);
        for (int i = 0; i < inPanel.Length; i++) {
            inPanel[i].DOFade(1, 1);
            yield return new WaitForSeconds(.125f);
        }
        yield return new WaitForSeconds(.25f);
        for (int i = 0; i < buttons.Length; i++) {
            buttons[i].DOFade(1, 1);
            yield return new WaitForSeconds(1f);
        }
    }
    // BUTTONS
    public void Quit() {
        Application.Quit();
    }
    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
