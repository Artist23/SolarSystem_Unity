using UnityEngine;
using System.Collections;

public class LookFly : MonoBehaviour  //flying in the direction you are looking
{
    public float velocity = 7f;    //fly speed 

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 moveDirection = Camera.main.transform.forward;   //direction is forward
        moveDirection *= velocity * Time.deltaTime;   
        transform.position += moveDirection;        //make move
        
    }
}