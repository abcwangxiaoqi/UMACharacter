#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using UnityEditor;

public class BuildPlayer_Android : BuildPlayer
{
    public override UnityEditor.BuildTarget target
    {
        get { return BuildTarget.Android; }
    }

    public override string suffix
    {
        get { return "apk"; }
    }
}
#endif