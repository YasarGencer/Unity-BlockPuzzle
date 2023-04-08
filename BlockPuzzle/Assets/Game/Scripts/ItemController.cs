using MyGrid.Code;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    GridManager gridmanager; 
    Vector3 offset, start;
    public void Initiazlie() {
        gridmanager = GetComponent<GridManager>();
        ItemCreator.Create(gridmanager.Tiles);
    }

    public void OnPointerDown(PointerEventData eventData) { 
        var target = Camera.main.ScreenToWorldPoint(eventData.position);
        offset = transform.position - target;
        start = transform.position;
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
    void ToStart() {
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
        gameObject.SetActive(false);
        MainManager.Instance.EventManager.RunOnItemPalced(int.Parse(transform.parent.name));
    }
}
