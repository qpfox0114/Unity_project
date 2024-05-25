using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public int m_seconds;          // 倒數計時經換算的總秒數
    public int m_min;              // 用於設定倒數計時的分鐘
    public int m_sec;              // 用於設定倒數計時的秒數

    public TMP_Text m_timer;       // 設定畫面倒數計時的文字
    public GameObject m_gameOver;  // 設定 GAME OVER 物件

    public Button pauseButton;     // 暫停按鈕
    public Button resumeButton;    // 繼續按鈕

    private bool isPaused;         // 計時是否暫停

    public int levelNumber;
    public PlayerScore playerScore;

    void Start()
    {
        StartCoroutine(Countdown());   // 呼叫倒數計時的協程
        m_gameOver.SetActive(false); 
        isPaused = false;              // 初始狀態為未暫停

        pauseButton.onClick.AddListener(PauseTimer);
        resumeButton.onClick.AddListener(ResumeTimer);
        StartCoroutine(Countdown());   //呼叫倒數計時的協程
        m_gameOver.SetActive(false);
        playerScore = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScore>();
    }

    IEnumerator Countdown()
    {
        m_timer.text = string.Format("{0}:{1}", m_min.ToString("00"), m_sec.ToString("00"));
        m_seconds = (m_min * 60) + m_sec; // 將時間換算為秒數

        while (m_seconds > 0) // 如果時間尚未結束
        {
            yield return new WaitForSeconds(1); // 等候一秒再次執行

            if (!isPaused) // 如果未暫停
            {
                m_seconds--; // 總秒數減 1
                m_sec--;     // 將秒數減 1

                if (m_sec < 0 && m_min > 0) // 如果秒數為 0 且分鐘大於 0
                {
                    m_min -= 1; // 先將分鐘減去 1
                    m_sec = 59; // 再將秒數設為 59
                }
                else if (m_sec < 0 && m_min == 0) // 如果秒數為 0 且分鐘等於 0
                {
                    m_sec = 0; // 設定秒數等於 0
                }
                m_timer.text = string.Format("{0}:{1}", m_min.ToString("00"), m_sec.ToString("00"));
            }
        }

        yield return new WaitForSeconds(1); // 時間結束時，顯示 00:00 停留一秒
        m_gameOver.SetActive(true); // 時間結束時，畫面出現 GAME COMPLETE
        SceneManager.LoadScene("intro"); // 時間結束時，畫面跳轉 (先以intro來測試)
        Time.timeScale = 0; // 時間結束時，控制遊戲暫停無法操作
    }

    // 暫停計時
    public void PauseTimer()
    {
        isPaused = true;
    }

    // 繼續計時
    public void ResumeTimer()
    {
        isPaused = false;
        yield return new WaitForSeconds(1);   //時間結束時，顯示 00:00 停留一秒
        m_gameOver.SetActive(true);           //時間結束時，畫面出現 GAME COMPLETE
        Time.timeScale = 0;                   //時間結束時，控制遊戲暫停無法操作
        ScoreManager.Instance.SetLevelScore(levelNumber, playerScore.score);
    }
}
