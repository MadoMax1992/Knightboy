using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public Sprite[] HearthSprite;
    public Image HearthUI;

    public static int health;
    

    
    
    // Use this for initialization

    void Start () {
       

       

        
    }
	
	// Update is called once per frame
	void Update () {
       
        health = HealthController.currentHealth;
        
        if (health>=0)
        {
            HearthUI.sprite = HearthSprite[health];
        }
       
        
	}
}
