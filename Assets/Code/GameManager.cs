using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int levelIndex;

    private void Start()
    {
        Application.targetFrameRate = 60;
        Time.timeScale = 1f;
        levelIndex = PlayerPrefs.GetInt("LevelIndex", 0);
    }

    public void NextScene()
    {
        levelIndex++;

        if (levelIndex == SceneManager.sceneCountInBuildSettings)
        {
            levelIndex = 0;
        }

        PlayerPrefs.SetInt("LevelIndex", levelIndex);
        SceneManager.LoadScene(levelIndex);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}