using Newtonsoft.Json.Linq;
using System.Collections; 
using UnityEngine;

public class BoardChecker : MonoBehaviour {
    [SerializeField] BoardCheckers[] boardCheckers;
    bool[] isFull;
    public void Initialize() { 
        isFull= new bool[boardCheckers.Length];
        MainManager.Instance.EventManager.onItemPlaced += CheckForScore;
        MainManager.Instance.EventManager.onItemPlaced += CheckForGame;
    } 
    void CheckForScore(int value) {
        //check horizontal and seperate empties from fulls
        bool[] horizontals = new bool[10];
        for (int i = 0; i < 10; i++) {
            bool[] bools = new bool[10];
            for (int j = 0; j < 10; j++) {
                bools[j] = boardCheckers[i * 10 + j].Check();
                //seperate empties from fulls
                isFull[i * 10 + j] = bools[j];
            }
            foreach (var item in bools) {
                horizontals[i] = true;
                if (item == true)
                    continue;
                else {
                    horizontals[i] = false;
                    break;
                }
            }
        }
        //check vertical
        bool[] verticals = new bool[10];
        for (int i = 0; i < 10; i++) {
            bool[] bools = new bool[10];
            for (int j = 0; j < 10; j++)
                bools[j] = boardCheckers[j * 10 + i].Check();
            foreach (var item in bools) {
                verticals[i] = true;
                if (item == true)
                    continue;
                else {
                    verticals[i] = false;
                    break;
                }
            }
        }
        //destroy horizontal
        for (int i = 0; i < 10; i++) {
            if (horizontals[i]) {
                MainManager.Instance.EventManager.RunOnKillLayerUp();
                for (int j = 0; j < 10; j++) {
                    boardCheckers[i * 10 + j].CheckObject().GetComponent<Item>().Kill();
                }
            }
        }
        //destroy vertic
        for (int i = 0; i < 10; i++) {
            if (verticals[i]) {
                MainManager.Instance.EventManager.RunOnKillLayerUp();
                for (int j = 0; j < 10; j++) {
                    boardCheckers[j * 10 + i].CheckObject().GetComponent<Item>().Kill();
                }
            }
        }
    }
    void CheckForGame(int value) { 
        StartCoroutine(RunEnd(value));
    }
    IEnumerator RunEnd(int value) {
        yield return new WaitForSeconds(.75f);
        if (CheckForPlaces(value) == false) 
            MainManager.Instance.EventManager.RunOnGameEnd();
    }
    bool CheckForPlaces(int value) {
        Transform[] items = MainManager.Instance.ItemsManager.ItemPlaces; 
        for (int i = 0; i < items.Length; i++)
            if (i != value) {
                var item = items[i].GetComponentInChildren<ItemController>() as ItemController; 
                if (item != null) {

                    for (int j = 0; j < boardCheckers.Length; j++) {
                        if (!isFull[j]) { 
                            item.transform.position = boardCheckers[j].transform.position;
                            bool canPlace = item.CheckSpot();
                            if (canPlace) {
                                item.ToStart(); 
                                return true;
                            }
                        }
                    }
                    item.ToStart();
                }
            } 
        return false;
    } 
}
