using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rg : MonoBehaviour
{
    //This cod For Register Button
   
    public InputField UsernameInput;
    public InputField passwordInput;
    public Button RgButton;

    // Start is called before the first frame update
    void Start()
    {
        RgButton.onClick.AddListener(() => {
            StartCoroutine(main.Instance.web.RegisterUser(UsernameInput.text, passwordInput.text));
        });

    }
}

