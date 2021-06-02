using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressAnyKey : MonoBehaviour
{
    public GameObject pressAnyKeyPanel;
    void Update()
    {
        if(Input.anyKey) //Press Any Key Input
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Loads next scene
            pressAnyKeyPanel.SetActive(false); //turns off panel
        }
    }
}
