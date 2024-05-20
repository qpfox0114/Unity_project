using UnityEngine;
using UnityEngine.EventSystems;

public class DragUIElement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector3 initialPosition; // �O����l��m

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
        initialPosition = rectTransform.anchoredPosition; // �b Awake ���O����l��m
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f; // ��ʹL�{���� UI �����b�z��
        canvasGroup.blocksRaycasts = false; // ���\�g�u��z�o�� UI ����
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

        // ����g�u�˴����˴��D UI ����
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.collider.gameObject;
            Debug.Log("Hit: " + hitObject.name); // �T�{�g�u�˴��쪺����
            if (hitObject.CompareTag("Manipulatable"))
            {
                Debug.Log("Manipulatable object detected: " + hitObject.name); // �T�{����㦳���T������
                PerformAction(hitObject);
            }
        }
        else
        {
            Debug.Log("No object hit by Raycast, returning to original position");
            rectTransform.anchoredPosition = initialPosition; // �p�G�S���˴���ؼЪ���A��^��l��m
        }
    }

    private void PerformAction(GameObject hitObject)
    {
        Debug.Log("Performing action on: " + hitObject.name + " with UI element: " + gameObject.name); // �K�[�ոիH��
        switch (gameObject.name)
        {
            case "integral":
                Debug.Log("Calling EnlargeObject");
                EnlargeObject(hitObject);
                break;
            case "derivative":
                Debug.Log("Calling ShrinkObject");
                ShrinkObject(hitObject);
                break;
            case "rotate":
                Debug.Log("Calling RotateObject");
                RotateObject(hitObject);
                break;
            case "long":
                Debug.Log("Calling StretchObject");
                StretchObject(hitObject);
                break;
            case "disappear":
                Debug.Log("Calling Destroy");
                Destroy(hitObject);
                break;
            default:
                Debug.Log("Unknown action");
                break;
        }
    }

    private void EnlargeObject(GameObject obj)
    {
        obj.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f); // ��ۼW�[�Y��
        Debug.Log("Enlarged " + obj.name + " to " + obj.transform.localScale);
    }

    private void ShrinkObject(GameObject obj)
    {
        obj.transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f); // ��۴���Y��
        if (obj.transform.localScale.x < 0.1f) obj.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f); // �����Y�񬰭t�ιs
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