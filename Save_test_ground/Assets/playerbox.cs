using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class playerbox : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI playername;
    GameObject uiscript;
    [SerializeField]
    Toggle togglebutton;
    private string playerpath;
    GameObject gamedata;

    // Start is called before the first frame update
    void Awake()
    {
        uiscript = GameObject.Find("UI_script");
        playername.text = uiscript.GetComponent<Button_test>().playersname;
        playerpath = uiscript.GetComponent<Button_test>().playerpath;
        togglebutton.group = uiscript.gameObject.GetComponent<Button_test>().PlayerField.GetComponent<ToggleGroup>();
        gamedata = GameObject.Find("GameData");
    }

    public void callsaveload()
    {
        gamedata.GetComponent<Gamedata>().getsaves(playerpath);
        //Debug.Log(playerpath);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  
}
