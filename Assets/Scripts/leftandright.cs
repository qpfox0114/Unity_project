using UnityEngine;
using UnityEngine.EventSystems;

public class leftandright : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector3 initialPosition; // �O����l��m
    private int count; // �p�ƾ�

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

        // ���� 2D �g�u�˴����˴��D UI ����
        Vector2 raycastPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(raycastPosition, Vector2.zero);
        if (hit.collider != null)
        {
            GameObject hitObject = hit.collider.gameObject;
            Debug.Log("Hit: " + hitObject.name); // �T�{�g�u�˴��쪺����
            if (hitObject.CompareTag("Manipulatable"))
            {
                Debug.Log("Manipulatable object detected: " + hitObject.name); // �T�{����㦳���T������
                Flip(hitObject); // �N eventData �@���ѼƶǤJ function
                rectTransform.anchoredPosition = initialPosition; // ��^��l��m
            }
            else
            {
                Debug.Log("Hit object does not have the correct tag, returning to original position");
                rectTransform.anchoredPosition = initialPosition; // ��^��l��m
            }
        }
        else
        {
            Debug.Log("No object hit by Raycast, returning to original position");
            rectTransform.anchoredPosition = initialPosition; // �p�G�S���˴���ؼЪ���A��^��l��m
        }
        if (count == 5)
        {
            rectTransform.gameObject.SetActive(false); // ���� UI ����
        }
    }

    private bool flipped = false;

    public void Flip(GameObject obj)
    {
        count++;
        // ���o����ثe��Scale��
        Vector3 scale = obj.transform.localScale;

        // ½�ફ��A�NX�b��Scale�ȭ��H-1
        scale.x *= -1;

        // �N�s��Scale�ȳ]�m������
        obj.transform.localScale = scale;

        // ��s½�બ�A
        flipped = !flipped;
    }


}