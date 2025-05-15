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
    public TMP_Text title;

    public void Start()
    {
        creditsText.enabled = false;
        creditsTitle.enabled = false;
        creditsPanel.enabled = false;
        closeCreditsButton.gameObject.SetActive(false);
        openCreditsButton.gameObject.SetActive(true);
        startButton.gameObject.SetActive(true);
        title.enabled = true;
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
        title.enabled = true;
    }
}
