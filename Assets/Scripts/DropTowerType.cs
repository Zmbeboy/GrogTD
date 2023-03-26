using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropTowerType : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject TowerType;
    private RectTransform rectTransform;
    [SerializeField] private Canvas canvas;
    public Transform parentTransform;
    private CanvasGroup canvasGroup;
    private Vector3 EndPos;
    private bool CanDrop;
    public GameObject radius;
    public List<Collider2D> colliders = new List<Collider2D>();
    public bool canBuy;
    public int towerCost;
    private void Awake()
    {
        CanDrop = true;
        canvasGroup = GetComponent<CanvasGroup>();
    }
    private void Update()
    {
        if(towerCost > GameObject.Find("GameController").GetComponent<Money>().money)
        {
            canBuy = false;
        }
        else
        {
            canBuy = true;
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (canBuy)
        {
            rectTransform = gameObject.GetComponent<RectTransform>();
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (canBuy)
        {
            EndPos = rectTransform.position;

            if (CanDrop)
            {
                gameObject.transform.parent = parentTransform;
                rectTransform.anchoredPosition = new Vector3(0, 0, 0);
                gameObject.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (canBuy)
        {
            radius.GetComponent<Image>().enabled = true;

            gameObject.transform.localScale = new Vector3(1.05f, 1.05f, 1);
            gameObject.transform.parent = canvas.transform;
            canvasGroup.alpha = 0.8f;
            canvasGroup.blocksRaycasts = false;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (canBuy)
        {
            
            if (!CanDrop)
            {
                var errorColor = Color.red;
                errorColor.a = .5f;
                radius.GetComponent<Image>().color = errorColor;

            }
            if (CanDrop)
            {
                var niceColor = Color.white;
                niceColor.a = .5f;
                radius.GetComponent<Image>().color = niceColor;
            }
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
            //screen bounds determine if the object can drop or not.
            //Also the colliders.count determines if the tower is on an obstacle tower or path
            if (rectTransform.position.x > -8.8 && rectTransform.position.x < 6.48 && rectTransform.position.y > -4.96 && rectTransform.position.y < 4.75 && colliders.Count == 0)
            {
                CanDrop = true;
            }
            else
            {
                CanDrop = false;
            }
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (canBuy)
        {
            canvasGroup.blocksRaycasts = true;
            if (CanDrop)
            {
                canvasGroup.alpha = 1f;
                //Debug.Log(EndPos.x+": X");
                //Debug.Log(EndPos.y+": Y");
                GameObject.Find("GameController").GetComponent<Money>().money -= towerCost;
                GameObject tower = Instantiate(TowerType);
                tower.transform.position = EndPos;

                radius.GetComponent<Image>().enabled = false;
            }
            // if the end of the object is in the ui menu or out of bounds - return the dropper to the itemslot
            if (EndPos.x < -8.8 || EndPos.x > 6.48 || EndPos.y < -4.96 || EndPos.y > 4.75)
            {
                gameObject.transform.parent = parentTransform;
                rectTransform.anchoredPosition = new Vector3(0, 0, 0);
                gameObject.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                radius.GetComponent<Image>().enabled = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool inList = false;
        if (collision.tag.Equals("Path") || collision.tag.Equals("Tower") || collision.tag.Equals("Obstacle"))
        {
            if (colliders.Count != 0)
            {
                foreach (Collider2D collide in colliders)
                {
                    if (collide == collision)
                    {
                        inList = true;
                    }

                }
                if (!inList)
                {
                    colliders.Add(collision);
                }
            }
            else
            {
                colliders.Add(collision);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Path") || collision.tag.Equals("Tower") || collision.tag.Equals("Obstacle"))
        {
            colliders.Remove(collision);
        }
    }
}
