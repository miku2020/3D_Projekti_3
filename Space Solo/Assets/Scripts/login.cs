using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class login : MonoBehaviour
{

    //This cod For Login Button

    public InputField UsernameInput;
    public InputField passwordInput;
    public Button LoginButton;

    // Start is called before the first frame update
    void Start()
    {
        LoginButton.onClick.AddListener(() =>{
            StartCoroutine( main.Instance.web.Login(UsernameInput.text, passwordInput.text));
        });
        
    }
}
