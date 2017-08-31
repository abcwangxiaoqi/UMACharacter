using UnityEngine;
using System.Collections;
using System.IO;

public class CameraScreetShot : MyEvent.EventDispatcher
{
    static CameraScreetShot instance = null;
    public static CameraScreetShot Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new CameraScreetShot();
            }
            return instance;
        }
    }

    string rootFold = "screenshot";
    Task task = null;
    public void Shot(string filename)
    {
        string fold = string.Format("{0}/{1}", Application.persistentDataPath, rootFold);

        if(!Directory.Exists(fold))
        {
            Directory.CreateDirectory(fold);
        }

        string shotPath = string.Format("{0}/{1}/{2}", Application.persistentDataPath, rootFold, filename);
        string pngPath = shotPath;
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            shotPath = string.Format("{0}/{1}", rootFold, filename);
        }
        Application.CaptureScreenshot(shotPath);
        task = new Task(ShotComplete(pngPath));
    }

    IEnumerator ShotComplete(string path)
    {
        while(!File.Exists(path))
        {
            yield return 1;
        }
        this.dispatchEvent(new CameraScreetShotEvent(CameraScreetShotEvent.COMPLETE));
        task = null;
    }
}

public class CameraScreetShotEvent:MyLoad.LoadEvent
{
    public CameraScreetShotEvent(string type,bool bobble=false)
        : base(type, bobble)
    {

    }
}
