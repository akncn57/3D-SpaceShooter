using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject settingsMenuUI;
    public GameObject infoMenuUI;
    public GameObject gameControllerMenuUI;

    private void FixedUpdate()
    {
        // Skybox move.
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 1);
    }

    // Start Button Click.
    public void StartGameButton()
    {
        // Load GameLevel scene.
        SceneManager.LoadScene("GameLevel");
    }

    // Exit Button Click.
    public void ExitButton()
    {
        // Exit game.
        Application.Quit();
    }

    // Settings Button Click.
    public void SettingsButton()
    {
        mainMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);
    }

    // Exit Settings Button Click.
    public void ExitSettingsButton()
    {
        settingsMenuUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }

    // Info Button Click.
    public void InfoButton()
    {
        mainMenuUI.SetActive(false);
        infoMenuUI.SetActive(true);
    }

    // Exit Info Button Click.
    public void ExitInfoButton()
    {
        infoMenuUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }

    // Game Controller Button Click.
    public void GameControllerButton()
    {
        mainMenuUI.SetActive(false);
        gameControllerMenuUI.SetActive(true);
    }

    // Exit Game Controller Button Click.
    public void ExitGameControllerButton()
    {
        gameControllerMenuUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }
}
