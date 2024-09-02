using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamedata : MonoBehaviour
{

    public PlayerData playerdata;

    private const string JSON_FILE_NAME = "/TestSave.json";

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerdata.Score++;
            Debug.Log("Space key was pressed.");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SaveJsonData();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift)) 
        {
         LoadJsonData();
        } 

      


    }
    public void SaveJsonData()
    {
        string Json = JsonUtility.ToJson(playerdata);
        string filepath = Application.persistentDataPath + JSON_FILE_NAME;
        Debug.Log(filepath);
        System.IO.File.WriteAllText(filepath, Json);
        Debug.Log("save created");
    }

    public void LoadJsonData()
    {
        string filepath = Application.persistentDataPath + JSON_FILE_NAME;
        string json = System.IO.File.ReadAllText(filepath);
        playerdata = JsonUtility.FromJson<PlayerData>(json);
        Debug.Log("my Json Data is " + playerdata);
    }

   
}
