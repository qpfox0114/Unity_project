using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider; // 音量滑塊
    public Button muteButton; // 靜音按鈕
    public Sprite muteImage; // 靜音圖案
    public Sprite unmuteImage; // 取消靜音圖案
    public AudioSource[] audioSources; // 多个音源

    private bool isMuted = false; // 記錄是否靜音
    private float previousVolume = 1f; // 記錄之前的音量

    void Start()
    {
        // 設置滑塊初始值為音源的音量
        volumeSlider.value = audioSources[0].volume;
        // 監聽滑塊值變化
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
        // 監聽靜音按鈕點擊事件
        muteButton.onClick.AddListener(ToggleMute);
        // 設置靜音按鈕初始圖案
        UpdateMuteButtonImage();
    }

    // 改變音量
    public void ChangeVolume(float value)
    {
        foreach (var audioSource in audioSources)
        {
            audioSource.volume = value;
        }
        // 如果音量不為零，更新之前的音量
        if (value > 0)
        {
            previousVolume = value;
            isMuted = false;
            UpdateMuteButtonImage();
        }
    }

    // 切換靜音狀態
    public void ToggleMute()
    {
        isMuted = !isMuted;
        foreach (var audioSource in audioSources)
        {
            if (isMuted)
            {
                audioSource.volume = 0;
            }
            else
            {
                audioSource.volume = previousVolume;
            }
        }
        UpdateMuteButtonImage();
    }

    // 更新靜音按鈕圖案
    private void UpdateMuteButtonImage()
    {
        if (isMuted)
        {
            muteButton.image.sprite = muteImage;
        }
        else
        {
            muteButton.image.sprite = unmuteImage;
        }
    }
}
