using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeObject : MonoBehaviour
{
    public GameObject Game;

    public void AwakeGame()
    {
        Game.SetActive(true);
    }
}
