using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Button_test : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI input;
    [SerializeField]
    private Gamedata gamedata;

    public void callbutton()
    {
        gamedata.SaveJsonData(input.text);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            gamedata.SaveJsonData(input.text);
            input.text = "";
        }
    }
}
