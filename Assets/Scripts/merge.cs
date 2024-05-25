using UnityEngine;
using UnityEngine.EventSystems;

public class merge : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector3 initialPosition;
    private int count;
    public GameObject obj;
    private pappear pappear;

    private void Awake()
    {
        pappear = obj.GetComponent<pappear>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
        initialPosition = rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
        Debug.Log("Begin Drag: " + gameObject.name);
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
        Debug.Log("End Drag: " + gameObject.name);

        Vector2 raycastPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(raycastPosition, Vector2.zero);
        if (hit.collider != null)
        {
            GameObject hitObject = hit.collider.gameObject;
            Debug.Log("Hit: " + hitObject.name);
            if (hitObject.CompareTag("Manipulatable1"))
            {
                Debug.Log("1");
                Destroy(hitObject);
                pappear.appear(obj);
                rectTransform.gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("2");
                rectTransform.anchoredPosition = initialPosition;
            }
        }
        else
        {
            Debug.Log("3");
            rectTransform.anchoredPosition = initialPosition;
        }
    }
}
