using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOb : MonoBehaviour {

    Canvas cursor;
	void Start () {
        cursor = transform.Find("Cursor").GetComponent<Canvas>(); //get the cursor canvas
        cursor.gameObject.SetActive(false);   //not active
	}
	
	// Update is called once per frame
	void Update () {
        cursor.gameObject.SetActive(false);
        Ray ray = new Ray(gameObject.transform.position, gameObject.transform.rotation * Vector3.forward); //set the ray
        RaycastHit hit;
        
        if(Physics.Raycast (ray,out hit))  //if something is hit
        {
            var tag = hit.transform.gameObject.tag;   //get the tag of the colider
            if(tag =="Button")                        //if it is a button
            {
                cursor.gameObject.SetActive(true);    //show the cursor
            }
        }
        
		
	}
}
