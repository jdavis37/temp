using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartTestSuite : MonoBehaviour
{
    public UnityEngine.UI.Button button;
    public GameObject buttonVisibilty;

    /**
    * @pre Start is called before the first frame update.
    * @post Event listener is added to button.
    * @param None.
    * @return None.
    */
    void Start()
    {
        button.onClick.AddListener(startTestSuite);
    }

    // Update is called once per frame
    /**
    * @pre Update is called once per frame.
    * @post button interactablility is set to true if Active Scene is UnitTest, false otherwsie.
    * @param None.
    * @return None.
    */
    void Update()
    {
        // Check if the name of the current Active Scene is your first Scene.
        if (SceneManager.GetActiveScene().name == "UnitTest")
        {
            button.interactable = false;
            buttonVisibilty.SetActive(false);
        }
        else
        {
            button.interactable = true;
        }
    }

    /**
    * @pre startTestSuite method will listen for the button onClick event.
    * @post startTestSuite method will load the UnitTest scene.
    * @param None.
    * @return None.
    */
    public void startTestSuite()
    {
        
        /**
        * The line of code for the Restart() function can be found in the Unity Answer Forum: https://answers.unity.com/questions/46918/reload-scene-when-dead.html
        */
        Debug.Log("Starting Test Suite");
        Debug.Log("Current Scene: " + SceneManager.GetActiveScene().name);
        Debug.Log("Switching to new Scene: UnitTest");
        SceneManager.LoadScene("UnitTest");
    }
}
