using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic backgroundMusic;
    public string musicTitle; // Judul lagu untuk identifikasi
    private AudioSource audioSource;

    void Awake()
    {
        if (backgroundMusic == null)
        {
            backgroundMusic = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (backgroundMusic != this && backgroundMusic.musicTitle != musicTitle)
        {
            Destroy(backgroundMusic.gameObject);
            backgroundMusic = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        RestartMusic();
    }

    public void RestartMusic()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
            audioSource.Play();
        }
    }
}
