using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public CharacterController player;
    [SerializeField] private InputBehavior inputBehavior = null;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        DisablePlayer(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        player.enabled = true;
        DisablePlayer(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void LoadMenu()
    {
        GameIsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public bool isPaused()
    {
        return GameIsPaused;
    }
    public void DisablePlayer(bool disable)
    {
        if (player != null)
        {
            player.enabled = !disable;
        }
        else
        {
            Debug.LogError("You may want to add the player object into the inspector slot of the Disable Manager - Or change this if you're using a different controller");
        }
        if (inputBehavior != null)
        {
            inputBehavior.look.MoveCam = !inputBehavior.look.MoveCam;
        }
        else
        {
            Debug.LogError("Add the input behaviour script (Usually found on the Player) to the Disable Manager");
        }
    }
}
