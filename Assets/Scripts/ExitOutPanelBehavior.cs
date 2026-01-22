using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ExitOutPanelBehavior : MonoBehaviour
{
    public void Exit()
    {
        if(CompareTag("ButtonMoon"))
        {
            StatsTextBehavior.moonParentObj.SetActive(false);

        }
        else if(CompareTag("ButtonSpark"))
        {
            StatsTextBehavior.sparkParentObj.SetActive(false);

        }
        else if(CompareTag("ButtonRay"))
        {
            StatsTextBehavior.rayParentObj.SetActive(false);

        }
    }
          
}
