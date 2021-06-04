using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BirdBoiScript : MonoBehaviour
{
    [SerializeField] private bool isPaused;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject restartPanel;
    [SerializeField] private GameObject losegamerestartPanel;
    [SerializeField] private GameObject endGamePanel;
    [SerializeField] private GameObject menuButton;
    [SerializeField] private TMP_Text theEndText;
    public static bool alive;
    public float sensitivity;
    public float thrust;
    public GameObject floorTooLow;
    public GameObject skyTooHigh;
    public Rigidbody2D birdRigid;
    public float mass;
    public ScoreCalculator Score;
    public MenuHandler2 nextLevel;


    private void Start()
    {
        sensitivity = 1.5f; //rigidbody stats
        alive = true;
        thrust = 350f;

        birdRigid = GetComponent<Rigidbody2D>(); 
        birdRigid.mass = mass; //rigidbody stats
        mass = 50;
    }

    public void Update() //updates every frame
    {
        if (alive == false) //if dead
        {
            gameObject.SetActive(false); //gameobject is false
            Destroy(gameObject); //it gets wrecked
            Restart(); //do restart method
        }

        if (Input.GetKeyDown(KeyCode.Mouse0)) //if left mouse click 
        {
            birdRigid.AddForce(transform.up * 1f * thrust, ForceMode2D.Impulse); //Gives force of thrust up
        }

        birdRigid.AddForce(transform.right * 0.00015f * thrust, ForceMode2D.Impulse); //has infinte thrust of right very slow
    }

    public void OnCollisionEnter2D(Collision2D col) //if touches
    {
        if (col.gameObject.tag == "Floor too Low" || col.gameObject.tag == "Sky too High" || col.gameObject.tag == "DEAD")
        {
            alive = false; //dies if hits those 3 tags

        }

        if (col.gameObject.tag == "WIN1") //level 1 right side of screen
        {
            Destroy(gameObject); //wrecks bird
            NextLevel(); //does next level method
            Score.Level1PassBonus(); //gives bonus in a different method
        }

        if (col.gameObject.tag == "WIN2") //level 2 right side of screen
        {
            Destroy(gameObject); //wrecks bird
            NextLevel(); //does next level method
            Score.Level2PassBonus(); //gives bonus in a different method
        }

        if (col.gameObject.tag == "WIN3") //level 3 right side of screen
        {
            Destroy(gameObject); //wrecks bird
            NextLevel(); //does next level method
        }

        if (col.gameObject.tag == "Back to Main") //level last Level right side of screen
        {
            Destroy(gameObject); //wrecks bird
            EndGame(); //does next level method
        }
    }

    public void NextLevel() 
    {
        isPaused = true; 

        Time.timeScale = 0; //pauses time

        nextLevel.NextLevel(SceneManager.GetActiveScene().buildIndex + 1); //goes to next scene
    }

    public void Restart()
    {
        isPaused = true;

        Time.timeScale = 0; //pauses time

        restartPanel.SetActive(true); //opens up the restart panel 

        menuButton.SetActive(false); //removes the menu button
    }

    public void LoseGameRestart() 
    {
        isPaused = true;

        Time.timeScale = 0; //pauses time

        losegamerestartPanel.SetActive(true); //opens the losegamerestartpanel

        menuButton.SetActive(false); //removes the menu button
    }
    public void PauseGame()
    {
        isPaused = true;

        Time.timeScale = 0; //pauses time

        pausePanel.SetActive(true); //opens pause panel
    }

    public void EndGame()
    {
        isPaused = true;

        Time.timeScale = 0; //pauses time

        endGamePanel.SetActive(true); //opens endgamepanel

        theEndText.gameObject.SetActive(false); //removes the End background text
    }
}
