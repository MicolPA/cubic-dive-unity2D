using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpController : MonoBehaviour
{


    private float platformSpeed;
    private float cloudSpeed;
    public float frequencyRate;
    private float topBound = 7.0f;

    // public GameManager GameManager;
    public GameObject GameManagerObj;

    // Start is called before the first frame update
    void Start()
    {
        GameManagerObj = GameObject.FindGameObjectWithTag("GameManager");
        platformSpeed = GameManagerObj.GetComponent<GameManager>().platformSpeed;
        cloudSpeed = GameManagerObj.GetComponent<GameManager>().cloudSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        // Debug.Log(gameObject.tag);
        if(gameObject.tag == "Platform"){
            // Debug.Log("its Platform");
            platformSpeed = GameManagerObj.GetComponent<GameManager>().platformSpeed;
        }

        MoveUp();


        //Destroy objects on top boundaries
        if (transform.position.y > topBound && (gameObject.CompareTag("Platform") || gameObject.CompareTag("Clouds"))){
            Destroy(gameObject);
        }

        // Debug.Log("MOVE OBJECT SPEED " + speed);
    }

    void MoveUp(){

        // Debug.Log(platformSpeed);
        if(gameObject.CompareTag("Platform")){
            transform.Translate(Vector3.up * Time.deltaTime * platformSpeed);
        }

        if(gameObject.CompareTag("Clouds")){
            transform.Translate(Vector3.up * Time.deltaTime * cloudSpeed);
        }

    }

    // void IncreaseSpeed(){
    //     if (gameObject.CompareTag("Platform")){
    //         speed += 1;
    //         Debug.Log("INCREASE SPEED "+ speed);
    //     }
    // }

}
