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
        sensitivity = 1.5f;
        alive = true;
        thrust = 350f;

        birdRigid = GetComponent<Rigidbody2D>();
        birdRigid.mass = mass;
        mass = 50;
    }

    public void Update()
    {
        if (alive == false)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
            Restart();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            birdRigid.AddForce(transform.up * 1f * thrust, ForceMode2D.Impulse);
        }

        birdRigid.AddForce(transform.right * 0.00015f * thrust, ForceMode2D.Impulse);
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Floor too Low" || col.gameObject.tag == "Sky too High" || col.gameObject.tag == "DEAD")
        {
            alive = false;

        }

        if (col.gameObject.tag == "WIN1")
        {
            Destroy(gameObject);
            NextLevel();
            Score.Level1PassBonus();
        }

        if (col.gameObject.tag == "WIN2")
        {
            Destroy(gameObject);
            NextLevel();
            Score.Level2PassBonus();
        }

        if (col.gameObject.tag == "WIN3")
        {
            Destroy(gameObject);
            NextLevel();
        }

        if (col.gameObject.tag == "Back to Main")
        {
            Destroy(gameObject);
            EndGame();
        }
    }

    public void NextLevel()
    {
        isPaused = true;

        Time.timeScale = 0;

        //nextLevel.NextLevel();
        nextLevel.NextLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart()
    {
        isPaused = true;

        Time.timeScale = 0;

        restartPanel.SetActive(true);

        menuButton.SetActive(false);
    }

    public void LoseGameRestart()
    {
        isPaused = true;

        Time.timeScale = 0;

        losegamerestartPanel.SetActive(true);

        menuButton.SetActive(false);
    }
    public void PauseGame()
    {
        isPaused = true;

        Time.timeScale = 0;
            
        pausePanel.SetActive(true);
    }

    public void EndGame()
    {
        isPaused = true;

        Time.timeScale = 0;

        endGamePanel.SetActive(true);

        theEndText.gameObject.SetActive(false);
    }
}
