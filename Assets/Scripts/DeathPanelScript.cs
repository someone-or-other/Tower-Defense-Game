using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeathPanelScript : MonoBehaviour
{
    public GameObject deathPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleDeathPanel()
    {
        deathPanel.SetActive(!deathPanel.activeSelf);
    }
}
