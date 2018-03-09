using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    public Transform origin;    //the center
    public float gspeed;        //revolution speed
    public float zspeed;        //rotation speed
    public float ry, rz;        //inclination and ecentricity

    void Start()
    {

    }

    void FixedUpdate()
    {
        Vector3 axis = new Vector3(0, ry, rz);     //the axis
        this.transform.RotateAround(origin.position, axis, gspeed * Time.deltaTime);   //revolution
        this.transform.Rotate(Vector3.up * zspeed * Time.deltaTime);       //rotation
    }
}



