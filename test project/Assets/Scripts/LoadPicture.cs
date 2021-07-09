using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;


public class LoadPicture : MonoBehaviour
{
    private Texture2D winTexture;
    private RawImage rawImage;

    private void OnEnable()
    {
        AssetDatabase.Refresh();
    }
    private void Start()
    {
        rawImage = GetComponent<RawImage>();
        LoadImage();
    }
    private void LoadImage()
    {
        winTexture = Resources.Load<Texture2D>("CameraScreenshot");
        rawImage.texture = winTexture;
    }
}
