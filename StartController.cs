using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartController : MonoBehaviour {

    public Button mybtn;

	// Use this for initialization
	void Start () {
        Button btn = mybtn.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    void TaskOnClick()
    {

        SceneManager.LoadScene("Main");

    }
}
