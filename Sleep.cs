using UnityEngine;
using System.Collections;

public class Sleep : MonoBehaviour
{
    public GameObject smallThing;

    void Start()
    {
        // 在遊戲開始時隱藏物件
        smallThing.SetActive(false);
    }

    public void ShowObject()
    {
        // 在需要時顯示物件並啟動協程
        smallThing.SetActive(true);
        StartCoroutine(FadeOutAfterDelay(2.0f)); // 兩秒後開始淡出
        Debug.Log("Start");
    }

    IEnumerator FadeOutAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // 等待兩秒

        // 檢查是否有 SpriteRenderer 組件
        SpriteRenderer spriteRenderer = smallThing.GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("No SpriteRenderer component found on smallThing");
            yield break; // 結束協程
        }

        // 假設要實現的效果是淡入淡出，這裡示範一下淡出的效果
        float duration = 1.0f; // 淡出時間
        float elapsedTime = 0.0f;

        Color startColor = spriteRenderer.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0.0f); // 完全透明的顏色

        while (elapsedTime < duration)
        {
            float alpha = Mathf.Lerp(1.0f, 0.0f, elapsedTime / duration);
            spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 確保淡出完全完成，設置完全透明的顏色並隱藏物件
        spriteRenderer.color = endColor;
        smallThing.SetActive(false);
    }
}
