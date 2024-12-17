using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public void ButtonPlay()
    {
        GameSceneManager.LoadScene(SceneNames.Main);
    }

    public void RestartGame()
    {
        GameSceneManager.ReloadCurrentScene();
    }
}
