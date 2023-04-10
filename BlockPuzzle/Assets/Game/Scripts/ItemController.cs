using MyGrid.Code;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    GridManager gridmanager; 
    Vector3 offset, start;
    public void Initiazlie() {
        gridmanager = GetComponent<GridManager>();
        ItemCreator.Create(gridmanager.Tiles);
        foreach (var item in gridmanager.Tiles) {
            item.GetComponent<Item>().Initialize();
        }
        start = transform.position;
    }

    public void OnPointerDown(PointerEventData eventData) { 
        var target = Camera.main.ScreenToWorldPoint(eventData.position);
        offset = transform.position - target;
    }

    public void OnPointerUp(PointerEventData eventData) {
        if (CheckSpot())
            PlaceAll();
        else
            ToStart();
    } 
    public void OnDrag(PointerEventData eventData) {
        var target = Camera.main.ScreenToWorldPoint(eventData.position);
        target += offset;
        target.z = -5f;
        transform.position = target;
    }
    public void ToStart() {
        transform.position = start;
    }
    public bool CheckSpot() {
        bool value = false;
        foreach (var item in gridmanager.Tiles) {
            value = item.GetComponent<Item>().CheckHit(); 
            if (value == false)
                return value;
        }
        return true;
    }
    public void PlaceAll() {
        foreach (var item in gridmanager.Tiles) {
            item.GetComponent<Item>().Place();
        }
        MainManager.Instance.EventManager.RunOnItemPalced(int.Parse(transform.parent.name));
        Destroy(gameObject);
    }
}
