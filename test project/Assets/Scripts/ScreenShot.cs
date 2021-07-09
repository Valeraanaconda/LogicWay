using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScreenShot : MonoBehaviour
{
    private static ScreenShot Instance;
    private Camera myCamera;
    private bool takeScreenShotOnNextFrame;


    private void Awake()
    {
        Instance = this;
        myCamera = GetComponent<Camera>();
    }

    private void OnPostRender()
    {
        if (takeScreenShotOnNextFrame)
        {
            takeScreenShotOnNextFrame = false;
            RenderTexture renderTexture = myCamera.targetTexture;

            Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
            renderResult.ReadPixels(rect, 0, 0);

            byte[] byteArray = renderResult.EncodeToPNG();
            File.WriteAllBytes("D:/unity/LogicWay/test project/Assets/Resources/" + "CameraScreenshot.png", byteArray);
            RenderTexture.ReleaseTemporary(renderTexture);
            myCamera.targetTexture = null;
        }
    }
    private void TakeScreenshot(int width, int hight)
    {
        myCamera.targetTexture = RenderTexture.GetTemporary(width, hight, 16);
        takeScreenShotOnNextFrame = true;
    }

    public static void TakeSkreenshotStatic(int width, int hight) => Instance.TakeScreenshot(width, hight);
}
