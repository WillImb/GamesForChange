using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class SaveAdnLoad : MonoBehaviour
{
    public Button newGameButton;
   

    public GameObject overWritePopUp;

    

    // Start is called before the first frame update
    void Start()
    {
        //WebVersion
        if (PlayerPrefs.GetString("save", "") != "")
        {

            newGameButton.interactable = true;
        }
        else
        {


            newGameButton.interactable = true;
        }
        //Desktop Version
        /*
        if (File.Exists(Application.dataPath + "/Saves/worldSave.txt"))
        {
            newGameButton.interactable = true;
            continueButton.interactable = true;
        }
        else
        {
            continueButton.interactable = false;
            newGameButton.interactable = true;
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        
        if(File.Exists(Application.dataPath + "/Saves/worldSave.txt"))
        {
            //OverWriteExistingSave
            overWritePopUp.SetActive(true);
        }
        else
        {
            //New Game
            
            ChangeScene();
        }
    }
    public void NewGamePrefs()
    {

        if (PlayerPrefs.GetString("save", "") != "")
        {
            //OverWriteExistingSave
            overWritePopUp.SetActive(true);
        }
        else
        {
            //New Game

            ChangeScene();
        }
    }

    public void Continue()
    {
        ChangeScene();
    }


    public void OverWriteSave()
    {
        File.Delete(Application.dataPath + "/Saves/worldSave.txt");
        NewGame();
    }
    //For Web Version
    public void OverWriteSavePrefs()
    {
        PlayerPrefs.SetString("save", "");
        NewGamePrefs();
    }



    public void ClosePopUp()
    {
        overWritePopUp.SetActive(false);
    }
    void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }
}
