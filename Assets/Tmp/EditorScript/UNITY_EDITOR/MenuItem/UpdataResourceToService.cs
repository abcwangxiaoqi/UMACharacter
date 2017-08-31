#if UNITY_EDITOR
/*
 * 上传角色assetbundle资源 到服务器 
 */
using UnityEditor;

public class UpdataResourceToService
{
    [MenuItem("Custom/上传资源到本地服务器")]
    static void Character_UploadAndroid()
    {
        IUpload upload = new Upload();
        upload.upload();
    }
}
#endif
