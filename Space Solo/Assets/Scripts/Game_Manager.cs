using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public List<GameObject> FuzesObjON = new List<GameObject>();
    public List<GameObject> FuzesObjOff = new List<GameObject>();
    public float XSeconds;
    
    void Start()
    {
        StartCoroutine(TaskTimer());
    }

    IEnumerator TaskTimer()
    {
        Debug.Log("Started");
        Debug.Log(FuzesObjON.Count);


        yield return new WaitForSeconds(XSeconds);
        int RNG = Random.Range(0, FuzesObjON.Count);
        if (FuzesObjON.Count != 0)
        {
            FuzesObjON[RNG].GetComponent<BoxCollider>().enabled = true;
            FuzesObjOff.Add(FuzesObjON[RNG]);
            FuzesObjON.Remove(FuzesObjON[RNG]);
            Debug.Log("happens");
        }
        else
        {
            Debug.Log("empty");
        }

        

        StartCoroutine(TaskTimer());
    }
}
