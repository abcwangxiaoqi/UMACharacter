using UnityEngine;

public class CameraPng
{
    public static void CaptureCamera(Camera camera, Rect rect, string fileName)
    {
        // 创建一个RenderTexture对象  
        RenderTexture rt = new RenderTexture((int)rect.width, (int)rect.height, 0);

        // 临时设置相关相机的targetTexture为rt, 并手动渲染该相机
        camera.targetTexture = rt;
        camera.Render();

        // 激活这个rt, 并从中中读取像素。  
        RenderTexture.active = rt;  //一定要激活，不然读取不到像素的


        Texture2D screenShot = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.ARGB32, false);
        screenShot.ReadPixels(rect, 0, 0);// 这个时候，它是从RenderTexture.active中读取像素  
        screenShot.Apply();
        

        // 重置相关参数，以使camera继续在屏幕上显示  
        camera.targetTexture = null;
        RenderTexture.active = null;
        GameObject.Destroy(rt);

        // 最后将这些纹理数据转换成一个png图片文件并保存   
        byte[] bytes = screenShot.EncodeToJPG();
        GameObject.Destroy(screenShot);
        System.IO.File.WriteAllBytes(fileName, bytes);
        Debug.Log("截屏了一张图片:" + fileName);
    }
}

public class PlayerIcon
{

}
