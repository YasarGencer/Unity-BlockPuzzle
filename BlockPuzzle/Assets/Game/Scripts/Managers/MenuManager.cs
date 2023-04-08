using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] MainCanvas mainCanvas;
    public MainCanvas MainCanvas { get { return mainCanvas; } }

    public void Initialize() {
        mainCanvas.Initialize();
    }
}
