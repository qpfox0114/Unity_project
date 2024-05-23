using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene("intro");
    }

    void OnSettingButtonPressed()
    {
        // 已經設定完要跳出 setting panel
    }
}
