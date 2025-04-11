using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public bool hasPauseScreen;
    public GameObject pauseScene;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hasPauseScreen)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
                ShowScene(pauseScene);
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
        Time.timeScale = 1;
    }

    public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
