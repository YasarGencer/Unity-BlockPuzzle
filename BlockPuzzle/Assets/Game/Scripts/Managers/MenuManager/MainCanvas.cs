using DG.Tweening; 
using TMPro;
using UnityEngine; 
using static EventManager;

public class MainCanvas : UI {
    [SerializeField] private TextMeshProUGUI scoreText, scoreUpText;
    public override void Initialize() {
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
