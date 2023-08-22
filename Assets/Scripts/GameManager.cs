using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public GameObject canvaGameOver;
    public GameObject canvaPause;
    private int score = 0;

    public GameObject player;
	private float ScreenWidth;
    public bool isGameOver = false;


    public float platformSpeed = 0.6f;
    public float cloudSpeed = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        InvokeRepeating("IncreaseScore", 1, 1);
        InvokeRepeating("IncreaseDifficulty", 15, 15);
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y >= 5 || player.transform.position.y <= -3){
            GameOver();
        }

    }

    void IncreaseScore(){
        
        if(!isGameOver){
            score = score + 1;
            string scoreStr = score.ToString();
            scoreText.text = scoreStr;
        }

    }

    void IncreaseDifficulty(){
        platformSpeed += 0.3f;
        cloudSpeed += 0.2f;
        Debug.Log("GAMESPEED " + platformSpeed);
    }


    public void RestartGame(){
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    void GameOver(){

        isGameOver = true;
        Time.timeScale = 0;
        canvaGameOver.SetActive(true);
    }

    public void PauseGame(){
        Time.timeScale = 0;
        canvaPause.SetActive(true);
    }

    public void ResumeGame(){
        Time.timeScale = 1.0f;
        canvaPause.SetActive(false);
    }

    public void ExitScene(){
        SceneManager.LoadScene("MenuScene");
    }

    
    
    
}
