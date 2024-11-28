using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class DebugCanvas
{
    private static GameObject debugText;
    private static Text d;
    public static void Log(string message)
    {
        if(debugText != null)
        {
            d.text += message+"\n";
        }
        else 
        {
            debugText = GameObject.Find("DebugText");
            d = debugText.GetComponent<Text>();
            d.text += message + "\n";
        }
    }
}
