using UnityEngine;
using UnityEngine.EventSystems;

public class copyFunction : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector3 initialPosition; // 記錄初始位置
    private CopyObjectOnDrop copyObjectScript; // 參考 CopyObjectOnDrop 腳本

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
        initialPosition = rectTransform.anchoredPosition; // 在 Awake 中記錄初始位置
        copyObjectScript = FindObjectOfType<CopyObjectOnDrop>(); // 尋找場景中的 CopyObjectOnDrop 腳本實例
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

        // 確認 Camera.main 不是 null
        if (Camera.main == null)
        {
            Debug.LogError("Camera.main 是 null。請確保場景中有一個 Main Camera，並將其標籤設置為 MainCamera。");
            rectTransform.anchoredPosition = initialPosition;
            return;
        }

        // 執行 2D 射線檢測來檢測非 UI 物體
        Vector2 raycastPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(raycastPosition, Vector2.zero);
        if (hit.collider != null)
        {
            GameObject hitObject = hit.collider.gameObject;
            Debug.Log("Hit: " + hitObject.name); // 確認射線檢測到的物體
            if (hitObject.CompareTag("Manipulatable"))
            {
                Debug.Log("Manipulatable object detected: " + hitObject.name); // 確認物體具有正確的標籤
                if (copyObjectScript != null)
                {
                    Debug.Log("調用 CopyObject 方法");
                    copyObjectScript.CopyObject(); // 調用 CopyObjectOnDrop 中的 CopyObject 方法
                    rectTransform.anchoredPosition = initialPosition;
                    rectTransform.gameObject.SetActive(false); // 隱藏 UI 元素
                }
                else
                {
                    Debug.LogError("copyObjectScript 是 null。請在場景中添加 CopyObjectOnDrop 腳本實例。");
                    rectTransform.anchoredPosition = initialPosition;
                }
            }
            else
            {
                Debug.Log("檢測到的物體標籤不正確，返回初始位置");
                rectTransform.anchoredPosition = initialPosition; // 返回初始位置
            }
        }
        else
        {
            Debug.Log("沒有檢測到物體，返回初始位置");
            rectTransform.anchoredPosition = initialPosition; // 如果沒有檢測到目標物體，返回初始位置
        }
    }
}
