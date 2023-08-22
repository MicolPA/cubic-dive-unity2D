using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_old : MonoBehaviour
{

    public float horizontalInput;
    public float speed = 5.0f;
    private Rigidbody2D playerRb;
    public float jumpForce;
    public float gravityModifier = 1.5f;


    private float yBound = 4.8f;
    private float xBound = 2.6f;    

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        // Physics.gravity *= gravityModifier;

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(Vector3.right * Time.deltaTime * speed * horizontalInput);     


        if(transform.position.x > xBound){
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }

        if(transform.position.x < -xBound){
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }


        
        
    }

    private void OnCollisionEnter(Collision other) {
        // playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        // transform.Translate(Vector3.up * Time.deltaTime * 5.0f * jumpForce);
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("AQUI");
        // playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

    }
}
