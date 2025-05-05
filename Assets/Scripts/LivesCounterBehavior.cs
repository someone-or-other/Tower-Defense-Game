using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesCounterBehavior : MonoBehaviour
{
    private TMP_Text livesLeftText;

    public int maxLives;
    private int lives;

    public int GetLives()
    {
        return lives;
    }
    void Start()
    {
        lives = maxLives;
        livesLeftText = GetComponentInChildren<TMP_Text>();
        UpdateLivesCounter();
    }
    // Start is called before the first frame update
    public bool LoseLife(int damage)
    {
        lives -= damage;
        if (lives > 0)
        {
            UpdateLivesCounter();
            return false;
        }
        lives = 0;
        UpdateLivesCounter();
        return true;
    }

    // Update is called once per frame
    public void UpdateLivesCounter()
    {
    livesLeftText.text = lives.ToString();
    }
}
