using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SceneVideoManager : MonoBehaviour
{
    public string sceneName;
    public float playDuration = 3.0f;

    private VideoPlayer videoPlayer;
    private float timer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        if (videoPlayer == null)
        {
            Debug.LogError("VideoPlayer component is missing.");
            return;
        }

        videoPlayer.isLooping = true;
        videoPlayer.Play();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= playDuration)
        {
            videoPlayer.Stop(); 
            LoadNextScene(); 
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
