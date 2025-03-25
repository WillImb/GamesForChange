using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class LoadPanel : MonoBehaviour
{
    public Button loadButton;
    public Button TrashButton;
    public TextMeshProUGUI loadText;

    public bool[] saves;
    int selectedIndex;

    // Start is called before the first frame update
    void Start()
    {
        LoadArray();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            if (saves[i])
            {

                transform.GetChild(0).GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Save " + i + 1;
            }
            else
            {
                transform.GetChild(0).GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = "New Game";
            }
        }
    }

    public void LoadInteractable(bool on)
    {
        loadButton.interactable = on;
    }
    public void TrashInteractable(bool on)
    {
        TrashButton.interactable = on;
    }

    public void SaveClick(int index)
    {
        selectedIndex = index;
        if (saves[index])
        {
            loadText.text = "Load Save";
            LoadInteractable(true);
            TrashInteractable(true);
        }
        else
        {
            loadText.text = "New Save";
            LoadInteractable(true);
            TrashInteractable(false);

        }
    }

    public void TrashSave()
    {
        saves[selectedIndex] = false;
        //code to save array
        SaveArray();
    }

    public void LoadGame()
    {
        //loading previously saved game
        if (saves[selectedIndex])
        {

        }
        //loading new game
        else
        {
            saves[selectedIndex] = true;
            SaveArray();


        }


        //load GameScene
        SceneManager.LoadScene(1);

    }

    void SaveArray()
    {
        SavesPanel save = new SavesPanel
        {
            saveIndex = selectedIndex,
            newGames = saves
        }; 

        string json = JsonUtility.ToJson(save);
        
        File.WriteAllText(Application.dataPath + "/Saves/savePanels.txt", json);
        
        
    }
    void LoadArray()
    {
        string json = File.ReadAllText(Application.dataPath + "/Saves/savePanels.txt");

        SavesPanel panels = JsonUtility.FromJson<SavesPanel>(json);

        saves = panels.newGames;
        selectedIndex = panels.saveIndex;
    }


    class SavesPanel
    {
        public int saveIndex;
        public bool[] newGames;
    }
}
