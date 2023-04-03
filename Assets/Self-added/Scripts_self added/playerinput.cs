using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerinput : MonoBehaviour
{
    public float speed = .1f;
    void Update()
    {
        float xd = Input.GetAxis("Horizontal");
        float zd = Input.GetAxis("Vertical");
        Vector3 move = new Vector3( xd, 0.0f,  zd);
       
       //transform.position += move * speed;
     GetComponent<Rigidbody>().position+= move * speed;
    }
}