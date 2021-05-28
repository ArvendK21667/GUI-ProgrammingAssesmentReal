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


    IEnumerator LoadAsynchronously(int sceneIndex)
    {
       
        loadingScreen.SetActive(true);

        //fake counter
        while (counter < time)
        {
            counter += Time.deltaTime;

            float progress = Mathf.Clamp01(counter / time);

            progressBar.fillAmount = progress;
            progressText.text = progress * 100 + "%";
            yield return null;

        }
        //yield return new WaitUntil()???

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        // load
    }
    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }
}
