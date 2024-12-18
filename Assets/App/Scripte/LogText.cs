using System;
using TMPro;
using UnityEngine;

public class LogText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI logText;

    public void Log(string message)
    {
        if (logText)
        {
            logText.text += $"\n[{DateTime.Now:HH:mm:ss}] {message}";
        }
    }

    public void ClearLog()
    {
        if (logText)
        {
            logText.text = "";
        }
    }
}