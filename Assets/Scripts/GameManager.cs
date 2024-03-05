using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private UIManager uiManager;

    private CharacterController2D player;
    public GameObject playerSprite;
    public GameObject spawnPoint;

    public enum GameState
    {
        MainMenu,
        Gameplay,
        Settings,
        Pause
    }

    public GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        player = FindObjectOfType<CharacterController2D>();
        gameState = GameState.MainMenu;
    }

    // Update is called once per frame
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }

        switch (gameState)
        {
            case GameState.MainMenu:
                MainMenu();
                break;
            case GameState.Gameplay:
                Gameplay();
                break;
            case GameState.Pause:
                Pause();
                break;
            case GameState.Settings:
                Settings();
                break;
        }
    }

    private void MainMenu()
    {
        Cursor.visible = true;
        playerSprite.SetActive(false);
        uiManager.UIMainMenu();
    }

    private void Gameplay()
    {
        Cursor.visible = false;
        playerSprite.SetActive(true);
        uiManager.UIGameplay();
    }

    private void Settings()
    {
        Cursor.visible = true;
        uiManager.UISettings();
    }

    private void Pause()
    {
        Cursor.visible = true;
        uiManager.UIPause();
    }

    public void PauseGame()
    {
        if (gameState != GameState.Pause)
        {
            gameState = GameState.Pause;
            Time.timeScale = 0;
        }
        else if (gameState == GameState.Pause)
        {
            //this is where i would go back to the previous state
            gameState = GameState.Gameplay;
            Time.timeScale = 1;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MovePlayerToSpawnPoint()
    {
        spawnPoint = GameObject.FindWithTag("SpawnPoint");
        player.transform.position = spawnPoint.transform.position;
    }

}
