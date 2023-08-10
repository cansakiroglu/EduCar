using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CursorFreeAgain : MonoBehaviour
{
    
    public BonnetController bonnetController;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        // When the scene is done:
        if (bonnetController.done)
        {
            bonnetController.done = false;
            Invoke("goToFinishScene", 3f);
        }
    }

    void goToFinishScene()
    {
        SceneManager.LoadScene(sceneName: "FinishScene");
    }
}
