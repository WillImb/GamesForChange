using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadWorld : MonoBehaviour
{
    // Start is called before the first frame update
  

    public GameObject player;
    public Entries entries;

    

    void Start()
    {

      
      


    }


    private void Update()
    {
        //Delete These before Build
        /*
        //Save World
        if (Input.GetKeyDown(KeyCode.M))
        {
            SaveWorldPrefs();
        }
        //Load Save
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadPrefs();
        }
        //Reset Save
        if (Input.GetKeyDown(KeyCode.N))
        {
            ResetSavePrefs();
        }
        */
    }


    void SaveWorld()
    {
        SavesPanel saveWorld = new SavesPanel
        {
            pictures = entries.isPicTaken,
            playerPos = player.transform.position
        };
        string saveJson = JsonUtility.ToJson(saveWorld);

        //For Desktop
        File.WriteAllText(Application.dataPath + "/Saves/worldSave.txt", saveJson);

        
    }
    void Load()
    {
        if(File.Exists(Application.dataPath + "/Saves/worldSave.txt"))
        {
            //if old Game
            string jsonText = File.ReadAllText(Application.dataPath + "/Saves/worldSave.txt");
            SavesPanel world = JsonUtility.FromJson<SavesPanel>(jsonText);

            player.transform.position = world.playerPos;
            entries.isPicTaken = world.pictures;

            entries.loadData();
}
        else
        {
            
            //if new Game
            SaveWorld();

        }
    }
    void ResetSave()
    {
        if (File.Exists(Application.dataPath + "/Saves/worldSave.txt"))
        {
            File.Delete(Application.dataPath + "/Saves/worldSave.txt");
            SceneManager.LoadScene(1);

        }
    }


    //These are for loading and saving in the web version
    void SaveWorldPrefs()
    {
        SavesPanel saveWorld = new SavesPanel
        {
            pictures = entries.isPicTaken,
            playerPos = player.transform.position
        };
        string saveJson = JsonUtility.ToJson(saveWorld);


        PlayerPrefs.SetString("save", saveJson);


    }
    void LoadPrefs()
    {
        if (PlayerPrefs.GetString("save", "") != "")
        {
            //if old Game
            string jsonText = PlayerPrefs.GetString("save", "");
            SavesPanel world = JsonUtility.FromJson<SavesPanel>(jsonText);

            player.transform.position = world.playerPos;
            entries.isPicTaken = world.pictures;

            entries.loadData();
        }
        else
        {

            //if new Game
            SaveWorldPrefs();

        }
    }
    void ResetSavePrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("save", "");
        
    }







}
