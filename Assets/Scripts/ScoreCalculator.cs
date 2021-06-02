using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCalculator : MonoBehaviour
{
    public TMP_Text scoreCount;
    public float endofTime;
    public BirdBoiScript birdBoi;
    public bool isRunning = true;

    void Start() // has the score system set up
    {
        endofTime = PlayerPrefs.GetFloat("endofTime");
        if (isRunning)
        {
            StartCoroutine(updateScoreManager(1f, 1f));
        }
    }

    private void OnDestroy() //Saves the score
    {
        PlayerPrefs.SetFloat("endofTime", endofTime);
    }

    public void ResetScore() //resests score when a new game has begun
    {
        endofTime = 3600;
    }

    void LateUpdate() //To round up the score that is counting to 0 
    {
        if (isRunning)
        {
            scoreCount.text = Mathf.CeilToInt(endofTime).ToString();
        }
    }

    IEnumerator updateScoreManager(float totalTime, float amount) //Score manager
    {
        while (endofTime > 0) //Letting the score go down by 1 per second
        {
            endofTime -= amount * Time.deltaTime;
            yield return null; 
        }
        birdBoi.LoseGameRestart();   //when score goes down to 0 you die and have to restart a new game
    }

    public void Level1PassBonus()
    {
        endofTime += 15;
    }

    public void Level2PassBonus()
    {
        endofTime += 750;
    }
}
