using UnityEngine;

public class BoardChecker : MonoBehaviour {
    [SerializeField] BoardCheckers[] boardCheckers;
    public void Initialize() { 
        MainManager.Instance.EventManager.onItemPlaced += CheckTheBoard;
    } 
    public void CheckTheBoard(int value) {
        //check horizontal
        bool[] horizontals = new bool[10];
        for (int i = 0; i < 10; i++) {
            bool[] bools = new bool[10];
            for (int j = 0; j < 10; j++)
                bools[j] = boardCheckers[i * 10 + j].Check();
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
}
