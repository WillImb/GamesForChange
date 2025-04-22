using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public bool hasPauseScreen;
    public GameObject pauseScene;
    public bool screenOpen;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && hasPauseScreen && !screenOpen)
        {
            
            if (!screenOpen)
            {
               
                screenOpen = true;
                ShowScene(pauseScene);
                Cursor.lockState = CursorLockMode.None;
                
            }
            else
            {
                screenOpen = false;
                Resume();
                HideScene(pauseScene);               
                
            }
        }
       
    }

    public void Quit()
    {
        Application.Quit();
    }
    
    public void ShowScene(GameObject screen)
    {
        screen.SetActive(true);
        
    }

    public void HideScene(GameObject screen)
    {
        screen.SetActive(false);
        
    }

    public void Resume()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
   
}
