using System.IO;
using System;
using UnityEngine;
using System.Collections;

public class MyScreenCapture : MonoBehaviour
{

    void OnGUI()
    {
        if (GUILayout.Button("TEST"))
        {
            StartCoroutine(CaptureByCamera(Camera.main, new Rect(0, 0, 1024, 768), Application.dataPath + "\\ScreenShot3.png"));
        }
    }
    private IEnumerator CaptureByCamera(Camera mCamera, Rect mRect, string mFileName)
    {
        yield return new WaitForEndOfFrame();

        RenderTexture mRender = new RenderTexture((int)mRect.width, (int)mRect.height, 0);
        mCamera.targetTexture = mRender;
        mCamera.Render();

        RenderTexture.active = mRender;

        Texture2D mTexture = new Texture2D((int)mRect.width, (int)mRect.height, TextureFormat.RGB24, false);
        mTexture.ReadPixels(mRect, 0, 0);
        mTexture.Apply();

        mCamera.targetTexture = null;
        RenderTexture.active = null;
        GameObject.Destroy(mRender);

        byte[] bytes = mTexture.EncodeToPNG();

        Debug.Log(bytes.Length);

        System.IO.File.WriteAllBytes(mFileName, bytes);
    }
}
