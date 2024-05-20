using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour{
    public AudioClip bgm; // 背景音樂
    // 看那些功能需要音效可以再加
    public AudioCLip seBubble; // 得到泡泡
    public AudioClip seBlock; // 放置區塊
    public AudioClip seClick; // 點選功能
    public AudioClip seJump; // 向上跳
    public AudioClip seSuccess; // 成功抵達終點

    List<AudioSource> audios = new List<AudioSource>();  // 聲音播放器的清單
    private void Awake() {
        for (int i = 0; i < 6; i++){
            var audio = this.gameObject.AddComponent<AudioSource>(); // 在遊戲物件上添加 AudioSource 組件
            audios.Add(audio); // 將 AudioSource 加入清單中
        }
    }

    // 使用的時候 GameManager.instance.audioManager.Play(index, name, true/false);
    void Play(int index, string name, bool isloop) {
        var clip = GetAudioClip(name);
        if(clip != null){
            var audio = audios[index];
            audio.clip = clip;
            audio.loop = isloop;
            audio.Play();
        }
    }

    // 根據特定的名稱找到對應的音效片段
    AudioClip GetAudioClip(string name){
        switch (name){
            case "bgm":
                return bgm;
            case "seBubble":
                return seBubble;
            case "seBlock":
                return seBlock;
            case "seClick":
                return seClick;
            case "seJump":
                return seJump;
            case "seSuccess":
                return seSuccess;
        }
        return null;
    }
}