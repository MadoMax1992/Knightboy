using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCotroller : MonoBehaviour {

    public GameObject player;       


    private Vector3 offset;         
    private Vector3 secOffset;
    public Vector3 minCam;
    public Vector3 maxCam;
    

    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.transform.position;    
        secOffset.Set(-4.5f, 0.3f, 0);
    }

    
    void Update()
    {
        
        
        if (player.transform.position.x >= 0)
        {
            transform.position = player.transform.position+offset+secOffset;

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCam.x, maxCam.x),
                Mathf.Clamp(transform.position.y, minCam.y, maxCam.y),
                Mathf.Clamp(transform.position.z, minCam.z, maxCam.z));

        }
        
        
    }
}
