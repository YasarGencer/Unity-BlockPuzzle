using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCanvas : UI {
    [SerializeField] CustomizationPanel customizationPanel;
    public override void Initialize() {
        base.Initialize();
        customizationPanel.Initialize();
    }
    public void StartButton() {
        MainManager.Instance.ItemsManager.Initialize();
        MainManager.Instance.GameManager.Initialize();
        Close();
    }
    public void CustomizationButton() {
        customizationPanel.Change();
    }
    public void QuitButton() {
        Application.Quit();
    }
}
