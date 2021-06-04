using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadingLevel : MonoBehaviour
{
    public GameObject loadingScreen;
    public Image progressBar;
    public TMP_Text progressText;
    public float counter = 0;
    public float time = 5;


    IEnumerator LoadAsynchronously(int currentscene)
    {
        loadingScreen.SetActive(true);

        // makes a fake counter 
        while (counter < time)
        {
            counter += Time.deltaTime; // making it 5 real seconds long 

            float progress = Mathf.Clamp01(counter / time); //to show progress in decimals

            progressBar.fillAmount = progress; //fills the progress bar on the loadin bar
            progressText.text = progress * 100f + "%"; //changes the text and multiply it by 100 to make it from decimal to % and add % symbol

            
            yield return null;
        }
        SceneManager.LoadScene(currentscene);

        //AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
        //SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex); //Failed Attempt Code
    }
    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex)); //when LoadLevel Method is called do what was above (Loading the Level with Loading Bar)
    }
}
