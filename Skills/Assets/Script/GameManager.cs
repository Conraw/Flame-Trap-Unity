using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button restartButton;
    public GameObject titleScreen;
    public GameObject gameOverScreen;
    public GameObject instructions;
    public GameObject player;
    public GameObject camera;

    public bool isGameActive;
    

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < -25)
        {
            GameOver();
        }
    
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
        titleScreen.gameObject.SetActive(false);
        camera.transform.position = new Vector3(-7.1f, 2.1f, -12);
    }
    public void Instructions()
    {
        titleScreen.gameObject.SetActive(false);
        instructions.gameObject.SetActive(true);
    }
    

}
