using System;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI; 

public class ThemeManager : MonoBehaviour
{
    [SerializeField] ThemeList Themes;
    GameObject[] color0;
    GameObject[] color1;
    GameObject[] color2;
    GameObject[] color3; 

    public void Initialize() { 
        PlayerPrefs.SetInt(Themes.GetTheme(0).name, 1);
        MainManager.Instance.EventManager.onSelect += SetThemeObjects;
        Themes.Indexer();
        GetThemeObjects();
        SetThemeObjects();
    }
#if UNITY_EDITOR && UNITY_EDITOR_WIN
    private void Update() { 
        if (Input.GetKeyDown(KeyCode.K)) { 
            SetActiveThemeIndex(GetActiveThemeIndex() + 1);
            GetThemeObjects();
            SetThemeObjects();
        }
        if (Input.GetKeyDown(KeyCode.J)) { 
            SetActiveThemeIndex(GetActiveThemeIndex() - 1);
            GetThemeObjects();
            SetThemeObjects();
        }
    }
#endif

    public int GetActiveThemeIndex() { return PlayerPrefs.GetInt("activeTheme"); } 
    public void SetActiveThemeIndex(int index) 
    {
        if (index < 0)
            PlayerPrefs.SetInt("activeTheme", Themes.GetThemes().Count);
        else if (index >= Themes.GetThemes().Count)
            PlayerPrefs.SetInt("activeTheme", 0);
        else
            PlayerPrefs.SetInt("activeTheme", index);
    }
    public Theme GetActiveTheme() { return Themes.GetTheme(GetActiveThemeIndex()); }
    public Theme GetTheme(int index) { return Themes.GetTheme(index); } 
    public List<Theme> GetThemes() { return Themes.GetThemes(); } 
    void GetThemeObjects() {
        color0 = GameObject.FindGameObjectsWithTag("color0");
        color1 = GameObject.FindGameObjectsWithTag("color1");
        color2 = GameObject.FindGameObjectsWithTag("color2");
        color3 = GameObject.FindGameObjectsWithTag("color3");
    }
    void SetThemeObjects() {
        Color[] colors = GetActiveTheme().GetColors();
        foreach (var item in color0)
            Colorize(item, colors[0]);
        foreach (var item in color1)
            Colorize(item, colors[1]);
        foreach (var item in color2)
            Colorize(item, colors[2]);
        foreach (var item in color3)
            Colorize(item, colors[3]);
        foreach (var item in GameObject.FindObjectsOfType<Item>()) {
            var index = UnityEngine.Random.Range(0,2);
            if (index == 0)
                item.Initialize(1);
            else if (index == 1)
                item.Initialize(3); 
        } 

        Camera.main.backgroundColor= colors[0];
    }
    void Colorize(GameObject item, Color color) {
        SpriteRenderer sprite = item.GetComponent<SpriteRenderer>() as SpriteRenderer;
        if (sprite != null) {
            sprite.color = color;
        }

        Image image = item.GetComponent<Image>() as Image;
        if (image != null) {
            image.color = color;
        }

        TextMeshProUGUI text = item.GetComponent<TextMeshProUGUI>() as TextMeshProUGUI;
        if (text != null) {
            text.color = color;
        }
    }

}
