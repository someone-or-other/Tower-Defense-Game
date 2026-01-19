using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExitOutPanelBehavior : MonoBehaviour, IPointerDownHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnPointerDown(PointerEventData eventData)
    {

        if (StatsTextBehavior.moonParentObj.gameObject.activeInHierarchy == true
            || StatsTextBehavior.sparkParentObj.gameObject.activeInHierarchy == true
            || StatsTextBehavior.rayParentObj.gameObject.activeInHierarchy == true)
        {

            Debug.Log("Clicked");
            StatsTextBehavior.moonParentObj.SetActive(false);
            StatsTextBehavior.sparkParentObj.SetActive(false);
            StatsTextBehavior.rayParentObj.SetActive(false);
        }
    }
}
