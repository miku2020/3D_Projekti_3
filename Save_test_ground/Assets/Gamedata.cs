using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Gamedata : MonoBehaviour
{

    public PlayerData playerdata;
    PlayerData loadedData;

    private string JSON_FILE_NAME = "/TestSave.json";
    private string JsonDirectory;
    [SerializeField]
    private Button_test UIscript;

    public string loadedname;
    public int loadedscore;
    public System.DateTime loadedtime;

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
            SaveJsonData("/TestSave.json");
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            LoadJsonData();
        }




    }
    public void SaveJsonData(string save_input)
    {
        JSON_FILE_NAME = "/" + playerdata.playerName + "/" + save_input + ".json";
        JsonDirectory = "/" + playerdata.playerName;
        string Json = JsonUtility.ToJson(playerdata);
        string filepath = Application.persistentDataPath + JSON_FILE_NAME;
        string jsondir = Application.persistentDataPath + JsonDirectory;
        if (Directory.Exists(filepath))
        {
            Debug.Log("loi");
            Debug.Log(filepath);
            File.WriteAllText(filepath, Json);
        }
        else
        {
            Debug.Log("yritt‰‰");
            Debug.Log("jsondir " + jsondir);
            Directory.CreateDirectory(jsondir);
            Debug.Log(filepath);
            File.WriteAllText(filepath, Json);
        }

        Debug.Log("save created: " + save_input);
    }

    public void LoadJsonData()
    {
        string filepath = Application.persistentDataPath + JSON_FILE_NAME;
        string json = System.IO.File.ReadAllText(filepath);
        playerdata = JsonUtility.FromJson<PlayerData>(json);
        Debug.Log("my Json Data is " + playerdata);
    }

    public void getDirectiories()
    {
        string[] dirs = Directory.GetDirectories(Application.persistentDataPath);
        foreach (string dir in dirs)
        {
            Debug.Log("dir on "+dir);
            string dirname = Path.GetFileName(Path.GetFileName(dir));
            //Debug.Log(dir);
            UIscript.InstantiatePlayerdirs(dirname, dir);
        }

    }

    public void getsaves(string path)
    {
        
        //string[] savedirs = Directory.GetDirectories(path + "/");
        string[] savedirs = Directory.GetFiles(path + "/");        
        foreach (string dir in savedirs)
        {
            string dirname = Path.GetFileName(Path.GetFileName(dir));
            var filedate = File.GetCreationTime(dir);
            Debug.Log(dir + " " + filedate);
            string json = File.ReadAllText(dir);
            loadedData = JsonUtility.FromJson<PlayerData>(json);
            loadedname = loadedData.playerName;
            loadedscore = loadedData.Score;
            loadedtime = filedate;
            UIscript.InstantiateSaveDirs();
        }
    }
}