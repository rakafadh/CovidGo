using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            gameOverPanel.SetActive(true);
        }
    }

    public void Restart()
    {
        // Restart scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // Restart music
        BackgroundMusic backgroundMusic = FindObjectOfType<BackgroundMusic>();
        if (backgroundMusic != null)
        {
            backgroundMusic.RestartMusic();
        }
    }
}
