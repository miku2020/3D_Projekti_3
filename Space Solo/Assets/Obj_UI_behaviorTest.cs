using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_UI_behaviorTest : MonoBehaviour
{

    public GameObject Enote;

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
        if (other.tag == "Obj_UI")
        {
            Enote.SetActive(true);
            Debug.Log("Triggered by Player objname: " + other.name);
            if (Input.GetKey(KeyCode.E))
            {
                other.GetComponent<AwakeObject>().AwakeGame();
            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Enote.SetActive(false);
    }
}
