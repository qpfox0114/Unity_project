using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_SettingsManager : MonoBehaviour
{
    public GameObject settingsPanel;
    public Button muteButton;
    public Slider volumeSlider;
    public Button exitButton;
    public Button closeButton;
    public Button achievementsButton;
    public Button restartButton;
    public GameObject achievementsPanel; // 成就面板

    private bool isMuted = false;
    private float previousVolume;

    void Start()
    {
        // 預設隱藏設定面板和成就面板
        settingsPanel.SetActive(false);
        achievementsPanel.SetActive(false);

        // 綁定按鈕事件
        muteButton.onClick.AddListener(ToggleMute);
        volumeSlider.onValueChanged.AddListener(AdjustVolume);
        exitButton.onClick.AddListener(ExitGame);
        closeButton.onClick.AddListener(CloseSettings);
        achievementsButton.onClick.AddListener(ShowAchievements);
        restartButton.onClick.AddListener(RestartLevel);
    }

    // 顯示設定面板
    public void ShowSettings()
    {
        settingsPanel.SetActive(true);
    }

    // 隱藏設定面板
    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    // 切換靜音狀態
    private void ToggleMute()
    {
        isMuted = !isMuted;
        AudioListener.volume = isMuted ? 0 : previousVolume;
        muteButton.GetComponentInChildren<Text>().text = isMuted ? "取消靜音" : "靜音";
    }

    // 調整音量
    private void AdjustVolume(float value)
    {
        if (!isMuted)
        {
            AudioListener.volume = value;
            previousVolume = value;
        }
    }

    // 退出遊戲返回主畫面
    private void ExitGame()
    {
        SceneManager.LoadScene("Start");
    }

    // 顯示成就面板
    private void ShowAchievements()
    {
        achievementsPanel.SetActive(true);
    }

    // 重新開始當前關卡
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
