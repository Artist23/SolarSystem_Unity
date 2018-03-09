using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonRay : MonoBehaviour {
    private Transform  camera;
    private GameObject currentButton;
    private float timeToSelect = 3.0f;  //timelaps
    private float countDown = 3.0f;

    void Start()
    {
        camera = Camera.main.transform;
    }
    
    void Update () {
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;
        GameObject hitButton = null;
        PointerEventData data = new PointerEventData(EventSystem.current);
        
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag == "Button")      //if button is hited
            {
                hitButton = hit.collider.gameObject;          //get the button
            }
        }
        if (currentButton != hitButton)
        {
            if (currentButton != null)
            { // unhighlight
                ExecuteEvents.Execute<IPointerExitHandler>(currentButton, data, ExecuteEvents.pointerExitHandler);
            }
            currentButton = hitButton;
            if (currentButton != null)
            { // highlight
                ExecuteEvents.Execute<IPointerEnterHandler>(currentButton, data, ExecuteEvents.pointerEnterHandler);
                countDown = timeToSelect;   //set the timer
            }
        }
        if (currentButton != null)
        {
            countDown -= Time.deltaTime;  //count down
            if (Input.GetMouseButton (0) || countDown < 0.0f)
            { // click
                ExecuteEvents.Execute<IPointerClickHandler>(currentButton, data, ExecuteEvents.pointerClickHandler);
                countDown = timeToSelect;     //reset the timer
            }
        }
    }
}
