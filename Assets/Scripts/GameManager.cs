using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // 暫停 UI 元素
    public Button PauseButton; // 暫停按鈕
    public GameObject PauseWindow; // 暫停視窗
    private bool isPause; // 紀錄遊戲是否暫停

    // 其他 UI 元素
    public Button ContinueButton; // 叉叉
    public Button RestartButton; // 重新開始按鈕
    public Button QuitButton; // 退出遊戲按鈕
    public Button MuteButton; // 靜音按鈕
    public Slider VolumeSlider; // 音量調整滑桿
    private bool isMuted = false; // 紀錄是否靜音

    void Start()
    {
        isPause = false;
        PauseButton.onClick.AddListener(PauseGame); // 為暫停按鈕添加點擊事件

        // 為其他按鈕添加點擊事件
        ContinueButton.onClick.AddListener(ContinueGame);
        RestartButton.onClick.AddListener(RestartGame);
        QuitButton.onClick.AddListener(QuitGame);
        MuteButton.onClick.AddListener(MuteGame);
        VolumeSlider.onValueChanged.AddListener(AdjustVolume);

        // 設置初始按鈕圖片
        PauseButton.image.sprite = Resources.Load<Sprite>("pause");
        ContinueButton.image.sprite = Resources.Load<Sprite>("continue");
        RestartButton.image.sprite = Resources.Load<Sprite>("restart");
        QuitButton.image.sprite = Resources.Load<Sprite>("quit");
        MuteButton.image.sprite = Resources.Load<Sprite>("mute");
    }

    // 暫停遊戲方法
    void PauseGame()
    {
        isPause = !isPause; // 切換暫停狀態

        if (isPause)
        {
            PauseButton.image.sprite = Resources.Load<Sprite>("resume"); // 更改按鈕圖像為"恢復"
            PauseWindow.SetActive(true); // 顯示暫停視窗
            Time.timeScale = 0; // 暫停遊戲時間
        }
        else
        {
            PauseButton.image.sprite = Resources.Load<Sprite>("pause"); // 更改按鈕圖像為"暫停"
            PauseWindow.SetActive(false); // 隱藏暫停視窗
            Time.timeScale = 1; // 恢復遊戲時間
        }
    }

    // 繼續遊戲方法
    void ContinueGame()
    {
        PauseGame(); // 取消暫停，繼續遊戲
    }

    // 重新開始遊戲方法
    void RestartGame()
    {
        Time.timeScale = 1; // 確保遊戲恢復正常速度
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // 重新加載當前場景
    }

    // 退出遊戲方法
    void QuitGame()
    {
        Application.Quit(); // 退出應用程序
    }

    // 靜音/取消靜音方法
    void MuteGame()
    {
        isMuted = !isMuted; // 切換靜音狀態
        AudioListener.volume = isMuted ? 0 : VolumeSlider.value; // 設置音量
        MuteButton.image.sprite = Resources.Load<Sprite>(isMuted ? "unmute" : "mute"); // 更改按鈕圖像
    }

    // 調整音量方法
    void AdjustVolume(float volume)
    {
        if (!isMuted)
        {
            AudioListener.volume = volume; // 設置音量
        }
    }
}
