using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShowImageOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image imageToShow;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (imageToShow != null)
        {
            imageToShow.enabled = true; // 显示图片
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (imageToShow != null)
        {
            imageToShow.enabled = false; // 隐藏图片
        }
    }
}
