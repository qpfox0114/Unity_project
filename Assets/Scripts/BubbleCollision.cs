using UnityEngine;

public class BubbleCollision : MonoBehaviour
{
    public AudioManager audioManager; // 音效管理器
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // 檢查碰撞的對象是否為 Player
        {
            PlayerScore playerScore = other.GetComponent<PlayerScore>(); // 獲取 PlayerScore 組件
            if (playerScore != null)
            {
                playerScore.IncreaseScore(5); // 增加分數
            }
            if (audioManager != null)
            {
                //audioManager.Play(1, "seBubble", false); // 播放泡泡音效
                //audioManager.PlaySE(1, "seBubble");
            }
            Destroy(gameObject); // 銷毀泡泡對象
        }
    }
}
