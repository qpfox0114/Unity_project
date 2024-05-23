using UnityEngine;
using UnityEngine.UI;

public class popUpHint : MonoBehaviour
{
    public GameObject hint;  // 参考提示窗口的Panel
    public Button hintButton;     // 参考显示提示的按钮
    public Button closeButton;    // 参考关闭提示的按钮

    void Start()
    {
        // 初始化时隐藏提示窗口
        hint.SetActive(false);

        // 为按钮添加监听事件
        hintButton.onClick.AddListener(ShowHint);
        closeButton.onClick.AddListener(HideHint);
    }

    // 显示提示窗口
    void ShowHint()
    {
        hint.SetActive(true);
    }

    // 隐藏提示窗口
    void HideHint()
    {
        hint.SetActive(false);
    }
}
