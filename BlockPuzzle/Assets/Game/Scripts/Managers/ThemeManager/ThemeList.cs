using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Theme", menuName = "ScriptableObject/ThemeList", order = 0)]
public class ThemeList : ScriptableObject
{
    [SerializeField] private List<Theme> themes;
    
    public Theme GetTheme(int index) {
        return themes[index];
    }
    public Theme GetTheme(string name) {
        foreach (var item in themes) {
            if(item.name == name) return item;
        }
        return null;
    }

    public List<Theme> GetThemes() {
        return themes;
    }
    public void Indexer() {
        for (int i = 0; i < themes.Count; i++) {
            themes[i].SetIndex(i);
        }
    }
}
[System.Serializable]
public class Theme {
    public string name;
    public Color[] color;
    private int index;

    public void Buy() {
        PlayerPrefs.SetInt(name, 1);
        MainManager.Instance.EventManager.RunOnBuy();
    }
    public int GetBuy() {
        return PlayerPrefs.GetInt(name, 0);
    }
    public Color[] GetColors() {
        return color;
    }
    public void SetIndex(int index) { 
        this.index = index;
    }
    public int GetIndex() {
        return index;
    }

}
