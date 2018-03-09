using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moonRotate : MonoBehaviour
{
    public Transform center;  //  earth
    public float distance;  
    public float normal_x;
    public float normal_y;
    public float normal_z;
    public float speed;

    private Vector3 normal;  // normal

    private GameObject shadow;  // the shadow of earth

    void Start()
    {
        shadow = new GameObject();
        shadow.transform.position = center.position;
        transform.parent = shadow.transform;  // moon is the sunobject of the shadow of earth
        transform.localPosition = new Vector3(distance, 0, 0);  // distance between moon and the shadow

        normal = new Vector3(normal_x, normal_y, normal_z);
    }

    void Update()
    {
        shadow.transform.position = center.position;  // keep the shadow with earth
        shadow.transform.Rotate(normal, speed * Time.deltaTime);  // moon will follow the shadow, which is rotating
    }
}


