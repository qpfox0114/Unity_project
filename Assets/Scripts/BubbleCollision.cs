using UnityEngine;

public class BubbleCollision : MonoBehaviour
{
    private bool is_eat = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !is_eat) // 檢查碰撞的對象是否為 Player
        {
            PlayerScore playerScore = other.GetComponent<PlayerScore>(); // 獲取 PlayerScore 組件
            if (playerScore != null)
            {
                playerScore.IncreaseScore(10); // 增加分數
                is_eat = true;
            }
            Destroy(gameObject); // 銷毀泡泡對象
        }
    }
}
