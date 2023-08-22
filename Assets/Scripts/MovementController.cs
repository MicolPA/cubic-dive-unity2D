using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private float moveSpeed = 200;
	public GameObject character;

	private Rigidbody2D characterBody;
	private float ScreenWidth;

    // Start is called before the first frame update
    void Start()
    {

        // Color col = GetComponent<Image>().color;
        // col.a = 0;
        // GetComponent<Image>().color = col;

        ScreenWidth = Screen.width;
		characterBody = character.GetComponent<Rigidbody2D>();


        // itemImage.GetComponent<Image>().color = Color.white;
        
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;
		//loop over every touch found
		while (i < Input.touchCount) {
			if (Input.GetTouch (i).position.x > ScreenWidth / 2) {
				//move right
				RunCharacter (1.0f);
			}
			if (Input.GetTouch (i).position.x < ScreenWidth / 2) {
				//move left
				RunCharacter (-1.0f);
			}
			++i;
		}
    }

    void FixedUpdate(){
        // Debug.Log(Input.GetAxis("Horizontal"));
		#if UNITY_EDITOR
		RunCharacter(Input.GetAxis("Horizontal"));
		#endif
	}

	private void RunCharacter(float horizontalInput){
		//move player
        // Debug.Log(horizontalInput);
		characterBody.AddForce(new Vector2(horizontalInput * moveSpeed * Time.deltaTime, 0));

	}
}
