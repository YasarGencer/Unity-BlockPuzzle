using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public class GameManager : MonoBehaviour {
    [SerializeField] BoardChecker boardChecker;

    public void Initialize() {
        Invoke("InvokeBoardCheckers", 1f);
    }
    void InvokeBoardCheckers() { 
        boardChecker.Initialize();
    }

}
