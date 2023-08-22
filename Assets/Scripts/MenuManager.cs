using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip tapSound;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame(){
        audioSource.PlayOneShot(tapSound);
        // StartCoroutine(WaitBeforeAHH());
        LoadGame();
        // InvokeRepeating("LoadGame", 1.5f, 2);
    }


    public void ExitGame(){
        // audioSource.PlayOneShot(tapSound);
        // Invoke("Exit", 1.5f);
        Exit();
    }

    void Exit(){
        Application.Quit();
    }

    void LoadGame(){
        SceneManager.LoadScene("MainScene");
    }

    IEnumerator WaitBeforeAHH(){
        yield return new WaitForSeconds(3);
        Debug.Log("AQUI");

    }

}
