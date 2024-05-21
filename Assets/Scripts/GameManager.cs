using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    // Pause UI
    public Button PauseButton;
    public GameObject PauseWindow;
    private bool isPause;

    void Start()
    {
        isPause = false;
        PauseButton.onClick.AddListener(PauseGame);
    }

    void PauseGame()
    {
        isPause = !isPause;

        if (isPause == true)
        {
            PauseButton.image.sprite = Resources.Load<Sprite>("Sprites/resume");
            PauseWindow.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            PauseButton.image.sprite = Resources.Load<Sprite>("Sprites/pause");
            PauseWindow.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
}