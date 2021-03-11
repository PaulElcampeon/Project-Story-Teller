using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LandingUI : MonoBehaviour
{
    [SerializeField]
    private GameObject _controlPanels;

    public void ShowControlsUi()
    {
        _controlPanels.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void FadeOut()
    {
        Fader.INSTANCE.FadeOut();
    }

    public void FadeIn()
    {
        Fader.INSTANCE.FadeIn();
    }

    public void LoadLevel(string level)
    {
        //Fader.INSTANCE.FadeOut();
        SceneManager.LoadScene(level);
    }
}
