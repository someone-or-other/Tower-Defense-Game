using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathButtons : MonoBehaviour
{

    public void DeathButtonPressed()
    {
        SceneManager.LoadScene(0);
    }
}
