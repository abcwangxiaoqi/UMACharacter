/*
 * 加载出配置 和 所有的依赖资源
 */
using UnityEngine;
public class CharacterManifestDenpenLoad : SubJect
{
    public override void Run()
    {
        SOAService_Resource_Character_Manifest manifestRequest = new SOAService_Resource_Character_Manifest();
        manifestRequest.AddListener(LoadManifestComplete);
        manifestRequest.Run();
    }
    void LoadManifestComplete(SOAData_Resource data)
    {
        AssetBundleManifest manifest = (AssetBundleManifest)data.obj;
        CacheManager.Insert<AssetBundleManifest>(CacheKeys.CharacterManifest, manifest, true);

        LoadDenpen();
    }

    void LoadDenpen()
    {
        string[] denpens = 
        {
            "common/common.assetbundle"
        };
        denpenCout = denpens.Length;
        for (int i = 0; i < denpens.Length; i++)
        {
            SOAService_Resource_Character_Denpen denpenReq = new SOAService_Resource_Character_Denpen(denpens[i]);
            denpenReq.AddListener(LoadDenpenComplete);
            denpenReq.Run();
        }
    }

    int denpenCout = 0;
    int finishCout = 0;
    void LoadDenpenComplete(SOAData_Resource data)
    {
        finishCout++;
        if (finishCout == denpenCout)
        {
            this.Notify();
        }
    }
}