using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;
using UnityEngine.SceneManagement;

public class EndSenceController : MonoBehaviour
{
    FlowerSystem fs;

    void Start()
    {
        fs = FlowerManager.Instance.CreateFlowerSystem("default", false);
        fs.SetupDialog();
        fs.SetupUIStage();
        fs.RegisterCommand("load_sence",(List<string> _params)=>{
            SceneManager.LoadScene(_params[0]);
        });
    }

    private bool isGameEnd = false;
    private int progress = 0;
    public int level;
    void Update()
    {
        if(fs.isCompleted && !isGameEnd){
            switch(progress){
                case 0:
                    fs.ReadTextFromResource("end");
                    Debug.Log("progress: "+progress);
                    progress+=level;
                    break;
                case 1: // All Pass + 得到成就
                    fs.ReadTextFromResource("end_achieve");
                    fs.Resume();
                    progress = 5;
                    break;
                case 2: // All Pass 
                    fs.ReadTextFromResource("end_ap");
                    fs.Resume();
                    progress = 5;
                    break;
                case 3: // 被當一科
                    fs.ReadTextFromResource("end_flunk");
                    fs.Resume();
                    progress = 5;
                    break;
                case 4: // 被當兩科以上(21)
                    fs.ReadTextFromResource("end_21");
                    fs.Resume();
                    progress = 5;
                    break;
                default:
                    isGameEnd = true;
                    break;
            }
            
        }

        if (!isGameEnd)
        {
            if(Input.GetKeyDown(KeyCode.Space)){
                fs.Next();
            }
            if(Input.GetKeyDown(KeyCode.R)){
                fs.Resume();
            }
        }

        if(isGameEnd)
        {
            StartCoroutine(FadeOutAndLoadScene());
        }
    }

    IEnumerator FadeOutAndLoadScene()
    {
        // 漸變螢幕顏色為黑色
        float fadeDuration = 1.5f;
        float elapsedTime = 0f;
        Color initialColor = Color.clear;
        Color targetColor = Color.black;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime; // 獲取前一幀與當前帧之間的時間間隔
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);
            // 使用 Color.Lerp 來漸變顏色
            // Camera.main 視為主攝影機，如果不是，請更換
            Camera.main.backgroundColor = Color.Lerp(initialColor, targetColor, t);
            yield return null;
        }

        // 延遲三秒
        yield return new WaitForSeconds(3f);

        // 轉換場景
        SceneManager.LoadScene("Start");
    }
}
