using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class savebox : MonoBehaviour
{
    string savename;
    int savescore;
    System.DateTime savedate;
    [SerializeField]
    private TextMeshProUGUI ScoreBox;
    [SerializeField]
    private TextMeshProUGUI DateBox;
    [SerializeField]
    private TextMeshProUGUI NameBox;

    GameObject gamedata;

    // Start is called before the first frame update
    void Awake()
    {
        gamedata = GameObject.Find("GameData");
        ScoreBox.text = gamedata.GetComponent<Gamedata>().loadedscore.ToString();
        DateBox.text = gamedata.GetComponent<Gamedata>().loadedtime.ToString();
        NameBox.text = gamedata.GetComponent<Gamedata>().loadedname.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
