using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour
{
    public TMP_Text creditsText;
    public TMP_Text creditsTitle;
    public Image creditsPanel;
    public Button closeCreditsButton;
    public Button openCreditsButton;
    public Button startButton;
    public Button quitButton;
    public TMP_Text title;
    public GameObject background;

    public void Start()
    {
        creditsText.enabled = false;
        creditsTitle.enabled = false;
        creditsPanel.enabled = false;
        closeCreditsButton.gameObject.SetActive(false);
        openCreditsButton.gameObject.SetActive(true);
        startButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        title.enabled = true;
        background.GetComponent<Animator>().Play("ZoomInOut");
    }
    public void MainMenuButtonClicked()
    {
        SceneManager.LoadScene(1);
    }

    public void CreditsButtonClicked()
    {
        creditsText.enabled = true;
        creditsTitle.enabled = true;
        creditsPanel.enabled = true;
        closeCreditsButton.gameObject.SetActive(true);
        openCreditsButton.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        title.enabled = false;
    }

    public void CreditsCloseButtonClicked()
    {
        creditsText.enabled = false;
        creditsTitle.enabled = false;
        creditsPanel.enabled = false;
        closeCreditsButton.gameObject.SetActive(false);
        openCreditsButton.gameObject.SetActive(true);
        startButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        title.enabled = true;
    }

    public void QuitButtonClicked()
    {
        Application.Quit();
    }
    
}
