 using UnityEngine; 

public class ItemsManager : MonoBehaviour
{
    [SerializeField] Transform[] itemPlaces;
    [SerializeField] GameObject item;
    public void Initialize() { 
        MainManager.Instance.EventManager.onItemPlaced += OnItemPlaced;
        for (int i = 0; i < itemPlaces.Length; i++) {
            SpawnItem(i);
        }
    }
    ItemController SpawnItem(int index) {
        ItemController item = Instantiate(this.item, itemPlaces[index]).GetComponent<ItemController>();
        item.Initiazlie();
        return item;
    }
    public void OnItemPlaced(int value) {
        SpawnItem(value);
    }

}
