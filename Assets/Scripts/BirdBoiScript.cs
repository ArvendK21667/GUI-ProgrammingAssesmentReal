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
    [SerializeField] private GameObject nextLevelPanel;
    [SerializeField] private GameObject endGamePanel;
    [SerializeField] private GameObject menuButton;
    [SerializeField] private TMP_Text theEndText;
    public static bool alive;
    public GameObject birdBoi;
    public float sensitivity;
    public float thrust;
    public GameObject floorTooLow;
    public GameObject skyTooHigh;
    public Rigidbody2D birdRigid;
    public float mass;
    

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
            birdBoi.SetActive(false);
            Destroy(birdBoi);
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

        if (col.gameObject.tag == "WIN")
        {
            Destroy(birdBoi);
            NextLevel();
        }

        if (col.gameObject.tag == "Back to Main")
        {
            Destroy(birdBoi);
            EndGame();
        }
    }

    public void NextLevel()
    {
        isPaused = true;

        Time.timeScale = 0;

        nextLevelPanel.SetActive(true);
    }

    public void Restart()
    {
        isPaused = true;

        Time.timeScale = 0;

        restartPanel.SetActive(true);

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
