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
    public Text deathText;
    public static int deathCounter = 0;
    public bool isGameActive = true;
    

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
            player.transform.position = new Vector3(-85.4f, 4.3f, 58.45f);
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
        isGameActive = false;
        gameOverScreen.gameObject.SetActive(true);
        Time.timeScale = 0;
        deathCounter++;
        deathText.text = "Deaths: " + deathCounter;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        deathText.text = "Deaths: " + deathCounter;
       
        Time.timeScale = 1;
        deathText.gameObject.SetActive(true);
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
