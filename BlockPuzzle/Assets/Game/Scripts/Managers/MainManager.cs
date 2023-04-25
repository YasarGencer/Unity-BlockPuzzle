using UnityEngine;

public class MainManager : MonoBehaviour {

    private static MainManager instance;
    private EventManager eventManager;
    private ThemeManager themeManager;
    private ItemsManager itemsManager; 
    private ScoreManager scoreManager;
    private CoinManager coinManager;

    [SerializeField] private GameManager gameManager;
    [SerializeField]  private MenuManager menuManager;

    public static MainManager Instance { get { return instance; } }
    public EventManager EventManager { get { return eventManager; } }
    public ThemeManager ThemeManager { get { return themeManager; } }
    public ItemsManager ItemsManager { get { return itemsManager; } }
    public ScoreManager ScoreManager { get { return scoreManager; } }
    public CoinManager CoinManager { get { return coinManager; } }

    public GameManager GameManager { get { return gameManager; } }
    public MenuManager MenuManager { get { return menuManager; } }

    public void Awake() {
        Initialize();
    }

    public void Initialize() {
        instance = this;

        eventManager = GetComponent<EventManager>(); 
        themeManager = GetComponent<ThemeManager>(); 
        itemsManager= GetComponent<ItemsManager>();
        scoreManager = GetComponent<ScoreManager>();
        coinManager = GetComponent<CoinManager>();

        eventManager.Initialize();
        //gameManager.Initialize();
        //itemsManager.Initialize();
        themeManager.Initialize();
        scoreManager.Initialize();
        coinManager.Initialize();
        menuManager.Initialize();
    }
}
