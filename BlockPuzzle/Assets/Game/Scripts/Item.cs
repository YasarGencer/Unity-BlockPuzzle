using DG.Tweening;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Item : MyGrid.Code.TileController {
    [SerializeField] LayerMask shootLayer;
    bool isAlive = true;
    Rigidbody2D rb;
    bool canPunch = true;
    public void Initialize(int index) {
        if(canPunch)
            transform.DOPunchScale(new Vector3(1, 1, 0), .5f, 0, 0).OnComplete(() => canPunch = true);
        canPunch = false;

        GetComponent<SpriteRenderer>().color = MainManager.Instance.ThemeManager.GetActiveTheme().GetColors()[index]; 
        if (index  == 3) 
            transform.GetChild(0).GetComponent<SpriteRenderer>().color = MainManager.Instance.ThemeManager.GetActiveTheme().GetColors()[1];
        else
            transform.GetChild(0).GetComponent<SpriteRenderer>().color = MainManager.Instance.ThemeManager.GetActiveTheme().GetColors()[3];
    }
     

    public RaycastHit2D ShootRay() {
        return Physics2D.Raycast(transform.position + transform.forward, transform.forward, 8, shootLayer);
    }
   public bool CheckHit(){
        if(!isAlive)
            return true; 
        if (ShootRay()) { 
            if (ShootRay().transform.gameObject.layer == 9)
                return true;
            else return false;
        }
        else return false;
    }
    public void Place() {
        if (!isAlive)
            return;
        transform.parent = GameObject.Find("PlacedTiles").transform;
        var target = ShootRay().transform.position;
        target.z = -1;
        transform.position = target;
        gameObject.layer = 10;
        rb = GetComponent<Rigidbody2D>();
    }
   public void Close(bool value) {
        isAlive= value;
        gameObject.SetActive(value);
    }

    public void Kill() {
        Destroy(GetComponent<BoxCollider2D>());
        rb.gravityScale = 1;
        transform.DOPunchScale(new Vector3(1, 1, 0), .5f, 0, 0).OnComplete(() => PunchComplete());
    }
    void PunchComplete() {
        rb.AddForce(Vector3.up * 1000);
        rb.AddForce(Vector3.right * Random.Range(-100, 100));
        rb.gravityScale = 5;
        transform.DOScale(Vector3.zero, 1.5f).SetEase(Ease.InCirc).OnComplete(() => Close(false));
        MainManager.Instance.EventManager.RunOnKill();
    }
}
