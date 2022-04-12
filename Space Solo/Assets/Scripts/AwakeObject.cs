using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeObject : MonoBehaviour
{
    //[SerializeField] private GameObject Game;
    //[SerializeField] private Transform theCanvas;
    [SerializeField] private GameObject game_manager;
    [SerializeField] private GameObject Pointerobj;
    public void AwakeGame()
    {
        //Game.SetActive(true); //prototyping
        //GameObject.Find("FPP").GetComponent<FPP_Controller>().enabled = false;
        //GameObject.Find("FPC").GetComponent<FPP_camera>().CursorUnlock();
        //GameObject.Find("FPC").GetComponent<FPP_camera>().enabled = false;

        //Object.Instantiate(Game, theCanvas);

        game_manager.GetComponent<Game_Manager>().FuzesObjON.Add(gameObject);
        gameObject.GetComponent<BoxCollider>().enabled = false;
        Pointerobj.GetComponent<Obj_UI_behaviorTest>().targetnull();
    }
}
