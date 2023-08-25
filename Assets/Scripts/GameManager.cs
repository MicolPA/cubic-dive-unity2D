using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public GameObject canvaGameOver;
    public GameObject canvaPause;
    private int score = 0;

    public GameObject player;
	private float ScreenWidth;
    public bool isGameOver = false;


    public float platformSpeed = 0.6f;
    public float cloudSpeed = 1.0f;
    public float speedLimit = 2.5f;


    public AudioSource audioSource;
    public AudioClip ambientSound;
    public AudioClip gameOverSound;


    // Start is called before the first frame update
    void Start()
    {
        audioSource.volume = 0.1f;
        audioSource.Play();
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        Time.timeScale = 1.0f;
        InvokeRepeating("IncreaseScore", 1, 1);
        InvokeRepeating("IncreaseDifficulty", 15, 15);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameOver){

            if(player.transform.position.y >= 5 || player.transform.position.y <= -3){
                GameOver();
            }

        }

        if(score >= int.Parse(highScoreText.text)){
            highScoreText.text = scoreText.text;
            PlayerPrefs.SetInt("HighScore", int.Parse(scoreText.text));
        }

    }

    void IncreaseScore(){
        
        if(!isGameOver){
            score = score + 1;
            scoreText.text = score.ToString();
        }

    }

    void IncreaseDifficulty(){
        if(platformSpeed < speedLimit){
            platformSpeed += 0.3f;
            cloudSpeed += 0.2f;
        }
    }


    public void RestartGame(){
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    void GameOver(){

        isGameOver = true;
        audioSource.Stop ();
        audioSource.PlayOneShot(gameOverSound);
        Time.timeScale = 0;
        canvaGameOver.SetActive(true);
    }

    public void PauseGame(){
        Time.timeScale = 0;
        audioSource.Pause();
        canvaPause.SetActive(true);
    }

    public void ResumeGame(){
        Time.timeScale = 1.0f;
        audioSource.Play();
        canvaPause.SetActive(false);
    }

    public void ExitScene(){
        SceneManager.LoadScene("MenuScene");
    }

    
    
    
}
