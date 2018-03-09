using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOb : MonoBehaviour {

    Canvas cursor;
	void Start () {

        cursor = transform.Find("Cursor").GetComponent<Canvas>();
        cursor.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        cursor.gameObject.SetActive(false);
        Ray ray = new Ray(gameObject.transform.position, gameObject.transform.rotation * Vector3.forward);
        RaycastHit hit;
        
        if(Physics.Raycast (ray,out hit))
        {
            var tag = hit.transform.gameObject.tag;
            if(tag =="Button")
            {
                cursor.gameObject.SetActive(true);
            }
        }
        
		
	}
}
