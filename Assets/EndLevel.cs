using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public LevelChanger levelChanger;
    public Collider2D player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == player)
        {
            if (SceneManager.GetActiveScene().name != "Level 2")
            {
                levelChanger.FadeToNextLevel();
            }
            else
            {
                levelChanger.FadeToLevel(0);
            }
        }
    }

}
