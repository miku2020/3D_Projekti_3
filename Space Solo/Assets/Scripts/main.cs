using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    public static main Instance;
    public Web web;
   
    void Start()
    {
        Instance = this;
        web = GetComponent<Web>();
    }

    
}
