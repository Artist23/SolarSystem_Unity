using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gaze : MonoBehaviour {

    private Transform cam;
    Ray ray;
    RaycastHit hit;
    GameObject hitOb;
    public void GazeInit()
    {
        cam = Camera.main.transform;
        
    }
	void Update ()
    {
        
    }
    public bool GazeIsHit()
    {
        ray = new Ray(cam.transform.position, cam.transform.rotation * Vector3.forward);
        if(Physics.Raycast (ray,out hit))
        {
            return true;
        }
        return false;
    }
    public GameObject GazeHitOb()
    {
        ray = new Ray(cam.transform.position, cam.transform.rotation * Vector3.forward);
        if (Physics.Raycast (ray,out hit))
        {
            hitOb = hit.collider.gameObject;
            return hitOb;
        }
        return null;
        
    }
}
