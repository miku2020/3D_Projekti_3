using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_UI_behaviorTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("something is hitting");
        if (other.tag == "Obj_UI")
        {
            Debug.Log("Triggered by Player" + other.name);
        }
    }

    void OnCollisionStay(Collision other)
    {
        Debug.Log("something is hitting");
        
    }

}
