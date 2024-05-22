using UnityEngine;
using UnityEngine.UI;

public class BGM_VolumeController : MonoBehaviour
{
    public Slider bgm_volumeSlider;  // 音量滑塊
    public AudioSource bgm_audioSource;  // 音樂音源
    public Button bgm_MuteButton;  // 音樂音源
    private float previousVolume = 1f;  // 記錄之前的音量
    private bool isMuted = false; // 記錄是否靜音
    public Sprite muteImage; // 靜音圖案
    public Sprite unmuteImage; // 取消靜音圖案

    void Start()
    {
        // 設置滑塊初始值為音源的音量
        bgm_volumeSlider.value = bgm_audioSource.volume;
        // 監聽滑塊值變化
        bgm_volumeSlider.onValueChanged.AddListener(ChangeVolume);
        bgm_MuteButton.onClick.AddListener(Mute);
        // 設置靜音按鈕初始圖案
        UpdateMuteButtonImage();
    }

    // 改變音量
    public void ChangeVolume(float value)
    {
        bgm_audioSource.volume = value;
        // 如果音量不為零，更新之前的音量
        if (value > 0)
        {
            previousVolume = value;
            isMuted = false;
            UpdateMuteButtonImage();
        }
    }

    // 靜音功能
    public void Mute()
    {
        // 如果當前音量不為零，將音量設置為零，並記錄之前的音量
        if (bgm_audioSource.volume > 0)
        {
            previousVolume = bgm_audioSource.volume;
            bgm_audioSource.volume = 0;
            bgm_volumeSlider.value = 0;
        }
        // 如果當前音量為零，將音量恢復到之前的值
        else
        {
            bgm_audioSource.volume = previousVolume;
            bgm_volumeSlider.value = previousVolume;
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
