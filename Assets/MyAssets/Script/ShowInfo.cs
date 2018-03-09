using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInfo : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        Transform camera = Camera.main.transform;
        Ray ray;
        RaycastHit hit;
        GameObject hitObject;
        ray = new Ray(camera.position, camera.rotation * Vector3.forward); //a ray from camera and casting forward

        if (Physics.Raycast(ray, out hit))            // if something hit by the ray
        {
            hitObject = hit.collider.gameObject;     //get the hit object
            Debug.Log("Tejo:" + hitObject.name);
            GameObject te = GameObject.Find("VisorCanvas/Text");    //get the UI Text object
            Text tt = te.GetComponent<Text>();
            tt.text = hitObject.name;           // show object name on canvas
        }
    }
}
