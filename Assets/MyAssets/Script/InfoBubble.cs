using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoBubble : MonoBehaviour {

    Camera cam;
    Text t;
    GameObject p;
	void Start () {
        cam = GameObject.Find("Main Camera").GetComponent <Camera>();
        t = transform.Find("Text").GetComponent <Text >(); //get text component
        p = transform.parent.gameObject ;
        t.text = p.name;  //get parent's name and show
	}
	
	// Update is called once per frame
	void Update () {

        gameObject.transform.LookAt(cam .transform );
        gameObject.transform.Rotate(0.0f,180.0f,0.0f);
	}
}
