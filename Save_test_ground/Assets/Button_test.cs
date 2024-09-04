using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Button_test : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI input;
    [SerializeField]
    private Gamedata gamedata;


    public GameObject PlayerField;
    [SerializeField]
    private GameObject playerboxPrefab;

    public string playerpath;
    public string playersname;
    public void callbutton()
    {
        gamedata.SaveJsonData(input.text);
    }

    public void refreshButton()
    {
        gamedata.getDirectiories();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            gamedata.SaveJsonData(input.text);
            input.text = "";
        }
    }

    public void InstantiatePlayerdirs(string name, string directory)
    {        
        playerpath = directory;
        playersname = name;
        Instantiate(playerboxPrefab, PlayerField.transform);
    }

    public void InstantiateSaveDirs()
    {

    }
}
