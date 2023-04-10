 using UnityEngine; 

public class ItemsManager : MonoBehaviour
{
    public Transform[] ItemPlaces;
    [SerializeField] GameObject item;
    int count = 0;
    public void Initialize() {
        MainManager.Instance.EventManager.onItemPlaced += OnItemPlaced;
        for (int i = 0; i < ItemPlaces.Length; i++) {
            OnItemPlaced(1);
        }
    }
    ItemController SpawnItem(int index) {
        ItemController item = Instantiate(this.item, ItemPlaces[index]).GetComponent<ItemController>();
        item.Initiazlie();
        return item;
    }
    public void OnItemPlaced(int value) { 
        count++;
        if(count >= 3) {
            count = 0;
            for (int i = 0; i < ItemPlaces.Length; i++) {
                SpawnItem(i);
            }
        }
    } 
}