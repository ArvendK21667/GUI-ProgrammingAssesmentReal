using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;


public class MenuHandlerTrial : MonoBehaviour
{
    public static AudioMixer masterAudio;
    public ScoreCalculator scoreing;
    [SerializeField] private bool isPaused;
    [SerializeField] private GameObject pausePanel;
    public GameObject OptionsMenu;
    public Resolution[] resolutions;
    public TMP_Dropdown resolution;
    public Player player;



    public void ChangeVolume(float volume) //Volume control
    {
        masterAudio.SetFloat("volume", volume);
    }

    public void ToggleMute(bool isMuted) //mute control
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
    public void PauseGame() //Pause Menu
    {
        isPaused = true;

        Time.timeScale = 0;

        pausePanel.SetActive(true);
    }
    public void OptionMenu() // To open Options Menu
    {
        OptionsMenu.SetActive(true);
    }
    public void OptionMenuClose() //To close Options Menu
    {
        OptionsMenu.SetActive(false);
    }
    public void UnPauseGame() //To Unpause Game
    {
        isPaused = false;

        Time.timeScale = 1;

        pausePanel.SetActive(false);
    }
    public void LoadScene(int currentscene) //To Load a scene for a level in the game
    {
        SceneManager.LoadScene(currentscene, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quality(int qualityIndex) //Quality Control
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    private void Start()
    {
        // Resolution Control
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
    public void SetResolution(int resolutionIndex) //Resolution Control
    {
        Resolution res = resolutions[resolutionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
    public void Playgame(int currentscene) //Play Game 
    {
        //SceneManager.LoadScene(currentscene); //Loads the to the Firt Level with new score
        SceneManager.LoadScene(currentscene, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);


        Time.timeScale = 1;
    }
    public void LoadGame() //Load Game Method for Button
    {
        PlayerData data = SaveSystem.LoadPlayer();
        SceneManager.LoadScene(data.level);
    }
    public void RestartLevel(int currentscene) //Panel to restart for when Bird/Player Dies
    {
        //SceneManager.LoadScene(currentscene);
        SceneManager.LoadSceneAsync(currentscene, LoadSceneMode.Additive);
        //Scene sceneToUnload = default;

        //for (int i = 0; i < SceneManager.sceneCount; i++)
        //{
        //    if (SceneManager.GetSceneAt(i).buildIndex != 6)  //Andrew Code
        //    {
        //        sceneToUnload = SceneManager.GetSceneAt(i);
        //        break;
        //    }
        //}

        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        Time.timeScale = 1;

        //PlayerPrefs.GetFloat("endofTime");
        //scoreing.scoreCount.text = scoreing.endofTime.ToString();
    }
    public void NextLevel(int currentscene) //When Bird reaches the end and goes to next level
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadSceneAsync(currentscene, LoadSceneMode.Additive); //Loads next scene/level in game
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }
    public void Mainmenu(int currentscene) // Goes back to main menu
    {
        //SceneManager.LoadScene(currentscene);
        SceneManager.LoadSceneAsync(currentscene, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void ReturnToMainAfterEndGame(int currentscene) // EngGame method that puts you at the end of game
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4); //back to scene 1 the main menu
        SceneManager.LoadSceneAsync(currentscene, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex - 4);
        Time.timeScale = 1;
    }

    //public void NextScene(int currentscene)
    //{
    //    SceneManager.LoadSceneAsync(currentscene, LoadSceneMode.Additive);
    //    Scene sceneToUnload = default;

    //    for (int i = 0; i < SceneManager.sceneCount; i++)
    //    {
    //        if (SceneManager.GetSceneAt(i).buildIndex != 6)
    //        {
    //            sceneToUnload = SceneManager.GetSceneAt(i);
    //            break;
    //        }
    //    }

    //    SceneManager.UnloadSceneAsync(sceneToUnload);

    //    Time.timeScale = 1;
    //}

    public void Quitgame() //quit game function
    {
        Debug.Log("quit");
        Application.Quit();
    }
}


