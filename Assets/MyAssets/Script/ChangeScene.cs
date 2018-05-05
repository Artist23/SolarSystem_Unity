using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour {

    public string sceneName;

	void Start () {     
        gameObject .GetComponent <Button>().onClick.AddListener(Change);
    }

    void Change()
    {
        if (sceneName == null)
        {
            return;
        }
        SceneManager.LoadScene(sceneName);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
