using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    private static SceneController Instance;

    private void Awake() => Instance = this;

    private void LoadScene(int sceneIndex) => SceneManager.LoadScene(sceneIndex);
    private void ExitGame() => Application.Quit();

    public static void LoadSceneStatic(int sceneIndex) => Instance.LoadScene(sceneIndex);
    public static void ExitGameStatic() => Instance.ExitGame();

}
