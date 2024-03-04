using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private UIManager uiManager;

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
        uiManager.UIMainMenu();
    }

    private void Gameplay()
    {
        Cursor.visible = false;
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
            gameState = GameState.MainMenu;
            Time.timeScale = 1;
        }
    }

}
