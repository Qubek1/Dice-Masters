using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationQuit : MonoBehaviour
{
    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
