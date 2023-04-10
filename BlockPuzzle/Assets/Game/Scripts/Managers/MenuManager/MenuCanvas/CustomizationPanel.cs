using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationPanel : UI
{
    [SerializeField] Transform itemContainer;
    [SerializeField] GameObject themeItem;
    List<ThemeItem> themeItems;

    bool isOpen = false;
    bool isSpinning = false;
    public override void Initialize() {
        base.Initialize();

        themeItems= new();
        
        gameObject.SetActive(false); isOpen = false;

        foreach (var item in MainManager.Instance.ThemeManager.GetThemes()) { 
            var newItem = Instantiate(themeItem, itemContainer).GetComponent<ThemeItem>();
            newItem.Initialize(item);
            themeItems.Add(newItem);
        }
    }

    public void Change() { 
        if (isOpen)
            Close();
        else
            Open(); 
    }
    public override void Open() {
        base.Open();
        isOpen = true;
    }
    public override void Close() {
        base.Close();
        isOpen = false;
    }
    public void SpinButton() {
        if (isSpinning)
            return;
        isSpinning = true;
        List<ThemeItem> buyable = new();
        foreach (var item in themeItems) {
            if(item.Theme.GetBuy() == 0)
                buyable.Add(item);
        }
        if (buyable.Count > 1)
            StartCoroutine(Spin(15, buyable));
        else if (buyable.Count == 1) {
            buyable[0].Theme.Buy();
            isSpinning = false;
        } else {
            isSpinning = false;
        }
    }
    IEnumerator Spin(int spinAmount, List<ThemeItem> items) {
        foreach (var item in themeItems)
            item.SetSpin(false);
        var random = Random.Range(0, items.Count);
        items[random].SetSpin(true);
        yield return new WaitForSeconds(.1f);
        if(spinAmount > 0)
            StartCoroutine(Spin(spinAmount-1, items));
        else {
            items[random].Theme.Buy();
            items[random].SelectButton();
            items[random].SetSpin(false);
            isSpinning = false;
        }
    }
}
