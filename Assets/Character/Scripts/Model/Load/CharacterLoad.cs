
using System.Collections.Generic;
using System.IO;
using UnityEngine;
abstract public class CharacterLoad
{
    abstract protected void localLoadRes(object[] objs);
    abstract protected void webLoadRes(object[] objs);

    abstract public void Stop();

    public void LoadRes(object[] objs)
    {
#if CharacterEditor
        if (CharacterConst.assetBundle)
        {
            WebLoadRes(objs);
        }
        else
        {
            localLoadRes(objs);
        }
#else
         WebLoadRes(objs);
#endif
    }

    static CharacterManifestDenpenLoad manifestDenpenLoad = null;

    void WebLoadRes(object[] objs)
    {
        if (manifestDenpenLoad==null)
        {
            manifestDenpenLoad = new CharacterManifestDenpenLoad();
            manifestDenpenLoad.Run();
        }
        if (manifestDenpenLoad.finish)
        {
            webLoadRes(objs);
        }
        else
        {
            manifestDenpenLoad.Sub(() =>
            {
                webLoadRes(objs);
            });
        }
    }
}
