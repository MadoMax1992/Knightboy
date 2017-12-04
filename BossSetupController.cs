using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSetupController : MonoBehaviour {

    private BoxCollider2D bc2d;
    public float camSetupVelo = 8f;
    public Transform camLookPos;
    public GameObject cam;
    public GameObject wizard;
    public Transform bossSpwanPoint;
    [HideInInspector]
    public bool isStarted= false;
    
    

	// Use this for initialization
	void Start () {
        bc2d = GetComponent<BoxCollider2D>();

        //StartBossFight();
        //bc2d.isTrigger = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (isStarted)
        {
            SetupCamera();
        }
	}

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartBossFight();
            bc2d.isTrigger = false;

        }
    }

    void StartBossFight()
    {
        GameObject.FindWithTag("MainCamera").GetComponent<CameraCotroller>().enabled = false;
        isStarted = true;
        Instantiate(wizard, bossSpwanPoint.transform.position, Quaternion.identity);
        
        
    }

    void SetupCamera()
    {
        cam.transform.position = Vector3.MoveTowards(cam.transform.position, camLookPos.transform.position, Time.deltaTime * camSetupVelo);
    }


}
