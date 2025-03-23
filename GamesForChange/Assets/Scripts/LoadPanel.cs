using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    }

    public void LoadInteractable(bool on)
    {
        loadButton.interactable = on;
    }
    public void TrashInteractable(bool on)
    {
        loadButton.interactable = on;
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
            //code to save saves array


        }



    }

    void SaveArray()
    {

    }
    void LoadArray()
    {

    }
}
