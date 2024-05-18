using UnityEngine;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{
    public Button startButton; // 開始按鈕
    public Button settingButton; // 設定按鈕

    void Start()
    {
        // 添加開始按鈕點擊事件監聽器
        startButton.onClick.AddListener(OnStartButtonPressed);
        // 添加設定按鈕點擊事件監聽器
        settingButton.onClick.AddListener(OnSettingButtonPressed);
    }

    void OnStartButtonPressed()
    {
        // 裡面放觸發[start]按鈕後會做的事
    }

    void OnSettingButtonPressed()
    {
        // 裡面放觸發[Setting]按鈕後會做的事
    }
}
