using DG.Tweening; 
using TMPro;
using Unity.VisualScripting;
using UnityEngine; 
using static EventManager;

public class GameCanvas : UI {
    [SerializeField] private TextMeshProUGUI scoreText, scoreUpText, colorBonusText;
    public override void Initialize() {
        MainManager.Instance.EventManager.onScoreUp += OnScoreUp;
        scoreText.SetText("0");
        colorBonusText.gameObject.SetActive(false);
    }
    public void OnScoreUp(int currentSocre, int scoreUp, bool colorBonus) {
        scoreText.SetText(currentSocre.ToString());
        scoreUpText.SetText("+" + scoreUp.ToString());

        scoreUpText.GetComponent<CanvasGroup>().DOFade(1, .25f).SetEase(Ease.OutCirc).OnComplete(() =>
            scoreUpText.GetComponent<CanvasGroup>().DOFade(0, 1f).SetEase(Ease.InCirc)
        );
        ColorBonus(colorBonus);
    }
    void ColorBonus(bool colorBonus) {
        if (!colorBonus)
            return;
        colorBonusText.gameObject.SetActive(true);

        colorBonusText.GetComponent<CanvasGroup>().DOFade(1, .25f).SetEase(Ease.OutCirc).OnComplete(() =>
            colorBonusText.GetComponent<CanvasGroup>().DOFade(0, 1f).SetEase(Ease.InCirc).OnComplete(() =>
        colorBonusText.gameObject.SetActive(false)
        ));
        colorBonusText.transform.DOScale(Vector3.zero,0f).SetEase(Ease.OutCirc).OnComplete(() =>
            colorBonusText.transform.DOScale(Vector3.one, .25f).SetEase(Ease.OutCirc).OnComplete(() =>
            colorBonusText.transform.DOScale(Vector3.one, .5f).SetEase(Ease.OutCirc).OnComplete(() =>
        colorBonusText.transform.DOScale(Vector3.zero, .5f).SetEase(Ease.OutCirc) 
        )));
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.U))
            ColorBonus(true);
    }
}
