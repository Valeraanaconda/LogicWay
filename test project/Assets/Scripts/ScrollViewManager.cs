using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollViewManager : MonoBehaviour
{
    [SerializeField] GameObject pazzleCount;
    [SerializeField] GameObject parentObject;

    private int pazzleCountValue;
    private void Start()
    {
        pazzleCountValue = pazzleCount.transform.childCount;
    }
    private void Update()
    {
        if (parentObject.transform.childCount == pazzleCountValue)
        {
            ScreenShot.TakeSkreenshotStatic(880,800);
            SceneController.LoadSceneStatic(1);
        }
    }
}
