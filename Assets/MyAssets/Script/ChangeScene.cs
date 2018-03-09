using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
        gameObject .GetComponent <Button>().onClick.AddListener(Change);

        
    }
    void Change()
    {
        SceneManager.LoadScene("Earth");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
