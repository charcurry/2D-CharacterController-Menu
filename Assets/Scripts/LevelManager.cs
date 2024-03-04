using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadScene(string levelName)
    {
        if (levelName.StartsWith("Gameplay"))
        {
            //this is where i would change the state to gameplay
        }
        SceneManager.LoadScene(levelName);
    }
}
