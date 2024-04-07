using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class ConsoleToGUI : MonoBehaviour
{
    public TextMeshProUGUI debugLog;
    string myLog = "Debug";
    string filename = "";
    int kChars = 3000;
    void OnEnable() { Application.logMessageReceived += Log; }
    void OnDisable() { Application.logMessageReceived -= Log; }

    void Update()
    {
        debugLog.text = myLog;
    }

    public void SetDebugPanelShown(bool show)
    {
        debugLog.gameObject.SetActive(show);
    }
    
    public void Log(string logString, string stackTrace, LogType type)
    {
        if (type != LogType.Error && type != LogType.Exception && type != LogType.Warning) return;
            // for onscreen...
        if (type is LogType.Error or LogType.Exception)
        {
            myLog = myLog + "\n<color=red>" + logString + "</color>\n" + "<size=16>" + stackTrace + "</size>";
        }
        else
            myLog = myLog + "\n" + logString;
        
        if (myLog.Length > kChars) { myLog = myLog.Substring(myLog.Length - kChars); }
     
        // for the file ...
        if (filename == "")
        {
            string d = System.Environment.GetFolderPath(
                System.Environment.SpecialFolder.Desktop) + "/YOUR_LOGS";
            System.IO.Directory.CreateDirectory(d);
            string r = Random.Range(1000, 9999).ToString();
            filename = d + "/log-" + r + ".txt";
        }
        try { System.IO.File.AppendAllText(filename, logString + "\n"); }
        catch { }
    }
}