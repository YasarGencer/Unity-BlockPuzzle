using DG.Tweening;
using UnityEngine;

public abstract class UI : MonoBehaviour
{
    public virtual void Initialize() {

    }
    public virtual void Open() {
        gameObject.SetActive(true);
        GetComponent<CanvasGroup>().alpha = 0f;
        GetComponent<CanvasGroup>().DOFade(1, 1f).SetEase(Ease.Linear);
    }
    public virtual void Close() {
        GetComponent<CanvasGroup>().DOFade(0, 1f).SetEase(Ease.Linear).OnComplete(() => gameObject.SetActive(false));
    }
}
