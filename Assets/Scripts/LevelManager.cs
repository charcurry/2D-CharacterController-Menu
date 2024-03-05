using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void LoadScene(string levelName)
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        if (levelName.StartsWith("Gameplay"))
        {
            gameManager.gameState = GameManager.GameState.Gameplay;
        }
        SceneManager.LoadScene(levelName);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        gameManager.MovePlayerToSpawnPoint();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
