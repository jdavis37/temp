using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour
{
    public GameObject GameOverScreen;
    public PlayerController player1, player2, player3, player4;

    // Use this for initialization
    void Start()
    {
        GameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player2 == null && player3 == null && player4 == null)
        {
            if (player1.IsPlayerDead())
            {
                GameOverScreen.SetActive(true);
            }
        }
        else if (player3 == null && player4 == null)
        {
            if (player1.IsPlayerDead() && player2.IsPlayerDead())
            {
                GameOverScreen.SetActive(true);
            }
        }
        else if (player4 == null)
        {
            if (player1.IsPlayerDead() && player2.IsPlayerDead() && player3.IsPlayerDead())
            {
                GameOverScreen.SetActive(true);
            }
        }
        else
        {
            if (player1.IsPlayerDead() && player2.IsPlayerDead() && player3.IsPlayerDead() && player4.IsPlayerDead())
            {
                GameOverScreen.SetActive(true);
            }
        }
    }
}
