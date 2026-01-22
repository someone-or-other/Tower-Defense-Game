using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeathPanelScript : MonoBehaviour
{
    public GameObject deathPanel;

    public void toggleDeathPanel()
    {
        deathPanel.SetActive(!deathPanel.activeSelf);
    }
}
