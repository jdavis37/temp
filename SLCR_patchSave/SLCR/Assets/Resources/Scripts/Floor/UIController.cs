using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour
{
    public GameObject GameOverScreen;
    public PlayerController player1, player2, player3, player4;

    /**
    * @pre Start is called before the first frame update.
    * @post Game Over Screen set to be inactive.
    * @param None.
    * @return None.
    */
    void Start()
    {
        GameOverScreen.SetActive(false);
    }

    /**
   * @pre Update is called once per frame
   * @post If all active players are dead, Game Over Screen is set as active.
   * @param None.
   * @return None.
   */
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
