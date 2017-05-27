using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.Net;

public class PostBuildProcess
{
    [PostProcessBuild]
    public static void OnPostProcessBuild(BuildTarget buildTarget, string path)
    {
        
    }

    private static void PostToChatwork(BuildTarget buildTarget)
    {
        string postMessage = "Unity Cloud Build :" + buildTarget.ToString() + "ビルド完了";
        WWWForm form = new WWWForm();

        form.AddField("token", "0a92ff08c08f06eae74de81d30e1a980");
        form.AddField("text", postMessage);

        float start = Time.time;

        WWW w = new WWW("https://api.chatwork.com/v2/rooms/16783614/messages", form);

        // 5秒までレスポンスを待つ
        while (!w.isDone && Time.time - start < 5.0f) {}

        if (w.isDone) {
            Debug.Log (w.text);
        } else {
            Debug.LogError ("Slack Post Timeout.");
        }


        Debug.Log("Finish");
    }
}
