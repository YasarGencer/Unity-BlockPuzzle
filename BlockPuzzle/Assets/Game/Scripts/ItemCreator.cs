using MyGrid.Code;
using System.Collections.Generic;
using UnityEngine;

public class ItemCreator : MonoBehaviour
{
    public static void Create(List<TileController> objects) {
        int selected = Random.Range(0, 19); 
        switch (selected) {
            case 0: //3X3 BOX
                Creator(objects, true, true, true, true, true, true, true, true, true);
                break; 
            case 1: //1X3 BOX
                Creator(objects, false, false, false, true, true, true, false, false, false);
                break;
            case 2: //3X1 BOX
                Creator(objects, false, true, false, false, true, false, false, true, false);
                break;
            case 3: //1X1 BOX
                Creator(objects, false, false, false, false, true, false, false, false, false);
                break;
            case 4: //LEFT UP L HORIZONTAL
                Creator(objects, false, false, false, true, true, true, true, false, false);
                break;
            case 5: //RIGHT UP L HORIZONTAL
                Creator(objects, false, false, false, true, true, true, false, false, true);
                break;
            case 6: //LEFT DOWN L HORIZONTAL
                Creator(objects, true, false, false, true, true, true, false, false, false);
                break;
            case 7: //RIGHT DOWN L HORIZONTAL
                Creator(objects, false, false, true, true, true, true, false, false, false);
                break;
            case 8: //LEFT UP L VERTICAL
                Creator(objects, false, true, false, false, true, false, true, true, false);
                break;
            case 9: //RIGHT UP L VERTICAL
                Creator(objects, false, true, false, false, true, false, false, true, true);
                break;
            case 10: //LEFT DOWN L VERTICAL
                Creator(objects, true, true, false, false, true, false, false, true, false);
                break;
            case 11: //RIGHT DOWN L VERTICAL
                Creator(objects, false, true, true, false, true, false, false, true, false);
                break;
            case 12: //MIDDLE UP
                Creator(objects, false, false, false, true, true, true, false, true, false);
                break;
            case 13: //MIDDLE DOWN
                Creator(objects, false, true, false, true, true, true, false, false, false);
                break;
            case 14: //MIDDLE RIGHT
                Creator(objects, false, true, false, false, true, true, false, true, false);
                break;
            case 15: //MIDDLE LEFT
                Creator(objects, false, true, false, true, true, false, false, true, false);
                break;
            case 16: //Z HORIZONTAL
                Creator(objects, false, false, false, true, true, false, false, true, true);
                break;
            case 17: //Z VERTICAL
                Creator(objects, false, true, false, true, true, false, true, false, false);
                break;
            case 18: //2X2 SQUARE
                Creator(objects, false, false, false, false, true, true, false, true, true);
                break;
            default:
                break;
        }
        
    }
    static void Creator(List<TileController> objects, bool value, bool value1, bool value2, bool value3, bool value4, bool value5, bool value6, bool value7, bool value8) {
        objects[0].gameObject.GetComponent<Item>().Close(value);
        objects[1].gameObject.GetComponent<Item>().Close(value1);
        objects[2].gameObject.GetComponent<Item>().Close(value2);
        objects[3].gameObject.GetComponent<Item>().Close(value3);
        objects[4].gameObject.GetComponent<Item>().Close(value4);
        objects[5].gameObject.GetComponent<Item>().Close(value5);
        objects[6].gameObject.GetComponent<Item>().Close(value6);
        objects[7].gameObject.GetComponent<Item>().Close(value7);
        objects[8].gameObject.GetComponent<Item>().Close(value8); 
    }
}
