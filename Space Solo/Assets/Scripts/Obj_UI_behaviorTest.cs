using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_UI_behaviorTest : MonoBehaviour
{

    public GameObject Enote;
    private Collider target;
    public bool LockBool = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null && Input.GetKeyDown(KeyCode.E) && LockBool == false)
        {
            target.GetComponent<AwakeObject>().AwakeGame();
        }
    }

    void OnTriggerEnter(Collider other)
    {

        target = other;
        if (target != null && target.tag == "Obj_UI")
        {
            Enote.SetActive(true);
            Debug.Log("Triggered by Player objname: " + target.name);
            

        }
    }
    private void OnTriggerExit(Collider other)
    {
        targetnull();
    }
    public void targetnull()
    {
        target = null;
        Enote.SetActive(false);
    }
}
