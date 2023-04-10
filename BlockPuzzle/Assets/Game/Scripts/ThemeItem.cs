using UnityEngine;
using UnityEngine.UI; 

public class ThemeItem : MonoBehaviour
{
    Theme theme;
    public Theme Theme { get { return theme; } }
    [SerializeField] GameObject locked, selected,spin;
    [SerializeField] Image[] colors;
    public void Initialize(Theme theme) {
        this.theme = theme;
        MainManager.Instance.EventManager.onBuy += SetBought;
        MainManager.Instance.EventManager.onSelect += SetSelected;
        for (int i = 0; i < colors.Length; i++)
            colors[i].color = this.theme.GetColors()[i]; 
        SetBought();
        SetSelected();
        SetSpin(false);
    }
    public void SelectButton() {
        if(theme.GetBuy() == 1) {
            MainManager.Instance.ThemeManager.SetActiveThemeIndex(theme.GetIndex());
            MainManager.Instance.EventManager.RunOnSelect();
        }
    }
    public void SetBought() {
        if (theme.GetBuy() == 1)
            locked.SetActive(false);
        else
            locked.SetActive(true);
    }
    public void SetSelected() {
        if (MainManager.Instance.ThemeManager.GetActiveThemeIndex() == theme.GetIndex())
            selected.SetActive(true);
        else 
            selected.SetActive(false);
    } 
    public void SetSpin(bool value) {
        spin.SetActive(value);
    }
}
