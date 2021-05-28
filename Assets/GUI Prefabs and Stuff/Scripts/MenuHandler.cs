using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;


public class MenuHandler : MonoBehaviour
{
    public AudioMixer masterAudio;

    public void ChangeVolume(float volume)
    {
        masterAudio.SetFloat("volume", volume);
    }

    public void ToggleMute(bool isMuted)
    {
        if (isMuted)
        {
            masterAudio.SetFloat("isMutedVolume", -80);
        }
        else
        {
            masterAudio.SetFloat("isMutedVolume", 0);
        }
    }

    [SerializeField] private bool isPaused;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject restartPanel;
    public GameObject OptionsMenu;

    public void PauseGame()
    {
        isPaused = true;

        Time.timeScale = 0;

        pausePanel.SetActive(true);
    }

    public void OptionMenu()
    {
        OptionsMenu.SetActive(true);
    }

    public void OptionMenuClose()
    {
        OptionsMenu.SetActive(false);
    }
    public void UnPauseGame()
    {
        isPaused = false;

        Time.timeScale = 1;

        pausePanel.SetActive(false);
    }
    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Quality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public Resolution[] resolutions;
    public TMP_Dropdown resolution;

    private void Start()
    {
        resolutions = Screen.resolutions;
        resolution.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolution.AddOptions(options);
        resolution.value = currentResolutionIndex;
        resolution.RefreshShownValue();

    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution res = resolutions[resolutionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

    public void Playgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartLevel(int currentscene)
    {
        SceneManager.LoadScene(currentscene);
        Time.timeScale = 1;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Mainmenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void Quitgame()
    {
        Debug.Log("quit");
        Application.Quit();
    }

}


