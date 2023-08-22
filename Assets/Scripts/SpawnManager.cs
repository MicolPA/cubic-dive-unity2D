using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] clonePrefab;
    private Vector2 spawnPos = new Vector2(0, -8);
    public float xBound;

    private float startDelay = 1;
    public float repeatRate;

    // public GameManager GameManager;
    public GameObject GameManagerObj;

    // Start is called before the first frame update
    void Start()
    {
        GameManagerObj = GameObject.FindGameObjectWithTag("GameManager");
        
        Debug.Log(clonePrefab[0].tag);

        if(clonePrefab[0].tag == "Platform"){
            repeatRate = GameManagerObj.GetComponent<GameManager>().platformSpeed * 2;
            repeatRate = repeatRate >= 6 ? 4.5f : repeatRate;   
        }

        InvokeRepeating("SpawnObj", startDelay, repeatRate);
    }

    void SpawnObj(){

        spawnPos = new Vector2(Random.Range(-xBound, xBound), gameObject.transform.position.y);

        int countPrefabObj = clonePrefab.Length;
        int selectPrefab = Random.Range(0, countPrefabObj - 1);
        Instantiate(clonePrefab[selectPrefab], spawnPos, clonePrefab[selectPrefab].transform.rotation);

    }
}
