using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorPosition : MonoBehaviour {

    public Camera cam;
    private Vector3 originalScale;         //the original scale of the cursor
	void Start () {
        originalScale = this.transform.localScale;   //get the original scale
	}
	
	// Update is called once per frame
	void Update () {

        float distance;           //distance of the cursor 
        RaycastHit hit;
        Ray ray = new Ray(cam.transform.position, 
            cam.transform.rotation * Vector3.forward);    //set the ray
        if (Physics.Raycast(ray, out hit))
        {
            distance = hit.distance*0.9f;           //if something was hit, then let cursor be there
        }
        else
        {
            distance = cam.farClipPlane * 0.95f;    //else let cursor stick on the far clip plane
        }

        this.transform.position = cam.transform.position +
           cam.transform.rotation * Vector3.forward * distance;  //set the transform of cursor use distance

        this.transform.localScale = originalScale * distance;    //change the scale
    }
}
