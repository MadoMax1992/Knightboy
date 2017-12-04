using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spCont : MonoBehaviour {
    public  GameObject enemy;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnSnake", 1, 3);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnSnake()
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
    }
}
