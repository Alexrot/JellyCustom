using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject mainCanvas;
    public GameObject skinCanvas;
    public GameObject inGameCanvas;

    public void RunGame()
    {
        mainCanvas.SetActive(false);
        inGameCanvas.SetActive(true);
    }

    public void OpenShop()
    {
        mainCanvas.SetActive(false);
        skinCanvas.SetActive(true);
    }

    public void CloseShop()
    {
        skinCanvas.SetActive(false);
        mainCanvas.SetActive(true);
    }

    public void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
