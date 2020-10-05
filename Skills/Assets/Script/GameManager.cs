using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Spawner spawnerScript;
    public Button restartButton;
    public GameObject titleScreen;
    public GameObject gameOverScreen;
    public GameObject instructionsScreen;
    public GameObject gameWonScreen;
    public GameObject player;
    public GameObject camera;

    public Text timerText;
    private float startTime;

    public bool isGameActive;
    

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Timer();

        if (player.transform.position.y < -25)
        {
            GameOver();
        }
        if (player.transform.position.x > 222)
        {
            GameWon();
        }
    }
    public void Timer()
    {
        float t = Time.time - startTime;
        string seconds = (t).ToString("f2");

        timerText.text = "Timer " + seconds;
    }

    public void GameOver()
    {
        gameOverScreen.gameObject.SetActive(true);
        Time.timeScale = 0;
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        isGameActive = true;
        Time.timeScale = 1;
        timerText.gameObject.SetActive(true);
        titleScreen.gameObject.SetActive(false);
        camera.transform.position = new Vector3(-7.1f, 2.1f, -12);
    }
    public void Instructions()
    {
        titleScreen.gameObject.SetActive(false);
        instructionsScreen.gameObject.SetActive(true);
    }
    public void InstructionBack()
    {
        titleScreen.gameObject.SetActive(true);
        instructionsScreen.gameObject.SetActive(false);
    }
    
    public void GameWon()
    {
        gameWonScreen.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

}
