using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool enabled;

    public float xBound = 2.8f;

    public AudioSource audioSource;
    public AudioClip slideSound;
    public AudioClip dropSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(enabled == false){
            FlipPlayerPos();
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("PRESSED");
            // Debug.Log(gameObject.tag);
            SoundEffect();
        }
        
    }

    void FlipPlayerPos(){

        // Debug.Log(transform.position.x);

        if(transform.position.x > xBound){
            transform.position = new Vector2(-xBound, transform.position.y);
        }

        if(transform.position.x < -xBound){
            transform.position = new Vector2(xBound, transform.position.y);
        }
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.collider.tag);
        if(other.collider.tag == "Platform"){
            audioSource.PlayOneShot(dropSound);

        }
    }

    public void SoundEffect(){

        

    }

   
   
}
