using UnityEngine;
using UnityEngine.EventSystems;

public class appearObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector3 initialPosition; // 記錄初始位置
    private int count; // 計數器
    public GameObject objectToInstantiate; // 要实例化的对象
    public Camera mainCamera; // 主相机

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
        initialPosition = rectTransform.anchoredPosition; // 在 Awake 中記錄初始位置
        
        if (mainCamera == null)
        {
            mainCamera = Camera.main; // 自动查找主相机
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f; // 拖動過程中使 UI 元素半透明
        canvasGroup.blocksRaycasts = false; // 允許射線穿透這個 UI 元素
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

        // 在滑鼠位置新增2D物體
        Vector2 worldPoint = mainCamera.ScreenToWorldPoint(eventData.position);
        
        // 实例化新物体
        GameObject newObject = Instantiate(objectToInstantiate);
        newObject.transform.position = new Vector3(worldPoint.x, worldPoint.y, newObject.transform.position.z);
        count++;
        if(count>=5){
            rectTransform.gameObject.SetActive(false);
        }
    }
}
