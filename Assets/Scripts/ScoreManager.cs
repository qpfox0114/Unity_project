using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    private int[] levelScores = new int[5];

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetLevelScore(int level, int score)
    {
        if (level >= 0 && level < levelScores.Length)
        {
            levelScores[level] = score;
        }
    }

    public int GetLevelScore(int level)
    {
        if (level >= 0 && level < levelScores.Length)
        {
            return levelScores[level];
        }
        return 0;
    }

    public void EvaluateScores()
    {
        for (int i = 0; i < levelScores.Length; i++)
        {
            if (levelScores[i] > 60)
            {
                Debug.Log("Level " + (i + 1) + " score is above 60.");
            }
            else
            {
                Debug.Log("Level " + (i + 1) + " score is 60 or below.");
            }
        }
    }
}
