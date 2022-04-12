using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePos : MonoBehaviour
{
    public GameObject Player;
    

    private void Start()
    {
        if(PlayerPrefs.GetInt("Saved") == 1 && PlayerPrefs.GetInt("TimeToLoad") == 1)
        {
            float PX = Player.transform.position.x;
            float PY = Player.transform.position.y;
            float PZ = Player.transform.position.z;


            PX = PlayerPrefs.GetFloat("p_X");
            PY = PlayerPrefs.GetFloat("p_Y");
            PZ = PlayerPrefs.GetFloat("p_Z");

            Player.transform.position = new Vector3(PX, PY, PZ);

            PlayerPrefs.SetInt("TimeToLoad", 0);
            PlayerPrefs.Save();
        }
        

    }
    public void PlayerPosSave()
    {

        PlayerPrefs.SetFloat("p_X", Player.transform.position.x);
        PlayerPrefs.SetFloat("p_Y", Player.transform.position.y);
        PlayerPrefs.SetFloat("p_Z", Player.transform.position.z);

        PlayerPrefs.SetInt("Saved", 1);
        PlayerPrefs.Save();


    }
    public void LoadPlayerPos()
    {
        //transform.position = new Vector3(PlayerPrefs.GetFloat("p_x"), PlayerPrefs.GetFloat("p_y"), PlayerPrefs.GetFloat("p_z"));

        PlayerPrefs.SetInt("TimeToLoad", 1);
        PlayerPrefs.Save();
    }
}
