using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
           GetComponent<Rigidbody>().position += new Vector3(0,.1f,0);
        }
        else if (Input.GetKey("s"))
        {
           GetComponent<Rigidbody>().position += new Vector3(0,-.1f,0);
        }
        else if (Input.GetKey("a"))
        {
           GetComponent<Rigidbody>().position += new Vector3(-.1f,0,0);
        }
        else if (Input.GetKey("d"))
        {
           GetComponent<Rigidbody>().position += new Vector3(.1f,0,0);
        }
        else if (Input.GetKey("z"))
        {
           GetComponent<Rigidbody>().position += new Vector3(0,0,-.1f);
        }
        else if (Input.GetKey("c"))
        {
           GetComponent<Rigidbody>().position += new Vector3(0,0,.1f);
        }
    }
}
