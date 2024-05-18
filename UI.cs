using UnityEngine;
using UnityEngine.EventSystems;

public class DragUIElement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f; // Make UI element semi-transparent during drag
        canvasGroup.blocksRaycasts = false; // Allow raycasts to go through this UI element
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;

        // Perform raycast to detect non-UI object
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.collider.gameObject;
            Debug.Log("Hit: " + hitObject.name); // Confirm the object hit by the Raycast
            if (hitObject.CompareTag("Manipulatable"))
            {
                Debug.Log("Manipulatable object detected: " + hitObject.name); // Confirm the object has the correct tag
                PerformAction(hitObject);
            }
        }
        else
        {
            Debug.Log("No object hit by Raycast");
        }
    }

    private void PerformAction(GameObject hitObject)
    {
        Debug.Log("Performing action on: " + hitObject.name); // Add debug message here
        switch (gameObject.name)
        {
            case "Large":
                EnlargeObject(hitObject);
                break;
            case "Shrink":
                ShrinkObject(hitObject);
                break;
            case "Rotate":
                RotateObject(hitObject);
                break;
            case "Stretch":
                StretchObject(hitObject);
                break;
            case "Disappear":
                Destroy(hitObject);
                break;
            default:
                Debug.Log("Unknown action");
                break;
        }
    }

    private void EnlargeObject(GameObject obj)
    {
        obj.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f); // Increase the scale more significantly
        Debug.Log("Enlarged " + obj.name + " to " + obj.transform.localScale);
    }

    private void ShrinkObject(GameObject obj)
    {
        obj.transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f); // Decrease the scale more significantly
        if (obj.transform.localScale.x < 0.1f) obj.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f); // Prevent negative or zero scale
        Debug.Log("Shrunk " + obj.name + " to " + obj.transform.localScale);
    }

    private void RotateObject(GameObject obj)
    {
        obj.transform.Rotate(Vector3.forward, 90f);
        Debug.Log("Rotated " + obj.name + " to " + obj.transform.rotation);
    }

    private void StretchObject(GameObject obj)
    {
        Vector3 scale = obj.transform.localScale;
        if (scale.x >= scale.y)
        {
            obj.transform.localScale += new Vector3(1f, 0, 0);
        }
        else
        {
            obj.transform.localScale += new Vector3(0, 1f, 0);
        }
        Debug.Log("Stretched " + obj.name + " to " + obj.transform.localScale);
    }
}
