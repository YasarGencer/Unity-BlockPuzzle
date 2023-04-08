using UnityEngine;

public class MainManager : MonoBehaviour {
    private static MainManager instance;
    private EventManager eventManager;
    [SerializeField] private GameManager gameManager;
    private ItemsManager itemsManager; 
    private ScoreManager scoreManager;
    private MenuManager menuManager;

    public static MainManager Instance { get { return instance; } }
    public EventManager EventManager { get { return eventManager; } }
    public GameManager GameManager { get { return gameManager; } }
    public ItemsManager ItemsManager { get { return itemsManager; } }
    public ScoreManager ScoreManager { get { return scoreManager; } }
    public MenuManager MenuManager { get { return menuManager; } }

    public void Awake() {
        Initialize();
    }

    private void Initialize() {
        instance = this;

        eventManager = GetComponent<EventManager>(); 
        itemsManager= GetComponent<ItemsManager>();
        scoreManager = GetComponent<ScoreManager>();
        menuManager = GetComponent<MenuManager>();

        eventManager.Initialize();
        gameManager.Initialize();
        itemsManager.Initialize();
        scoreManager.Initialize();
        menuManager.Initialize();
    }
}
