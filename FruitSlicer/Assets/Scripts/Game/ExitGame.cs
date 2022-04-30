using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{

    public void Exit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        //only work for a built application
        //Application.Quit();
    }
}
