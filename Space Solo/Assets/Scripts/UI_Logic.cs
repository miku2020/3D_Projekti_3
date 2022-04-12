using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Logic : MonoBehaviour
{
    [SerializeField] private GameObject Window;

    public void CloseWindow()
    {
        Destroy(Window);
        GameObject.Find("FPP").GetComponent<FPP_Controller>().enabled = true;
        GameObject.Find("FPC").GetComponent<FPP_camera>().enabled = true;
        GameObject.Find("FPC").GetComponent<FPP_camera>().CursorLock();
    }
}
