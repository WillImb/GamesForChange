using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class Entries : MonoBehaviour
{
    //list of all the text that will be pulled from a txt file
    [SerializeField]
    private string[] animals = new string[4];
    [SerializeField]
    private string[] stats = new string[4];
    [SerializeField]
    private string[] blurb = new string[4];

    //list of all the components in the journal
    public TextMeshProUGUI[] nameText = new TextMeshProUGUI[4];
    public TextMeshProUGUI[] statText = new TextMeshProUGUI[4];
    public TextMeshProUGUI[] blurbText = new TextMeshProUGUI[4];

    //list of bools to know if a pic of an animal has been taken
    public bool[] isPicTaken = new bool[4];

    //Array of Images
    [SerializeField] Image[] images = new Image[4]; 

    // Start is called before the first frame update
    void Start()
    {
        NewLoadText();
        // readData();
        //loadData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void readData()
    {
        StreamReader info = new StreamReader("../GamesForChange/Files/animal_info.txt");
        try
        {
            //loop while there are lines to read
            string line = null;
            int index = 0;
            while ((line = info.ReadLine()) != null)
            {
                Console.WriteLine(line);
                //splitting a string
                string[] arr = line.Split('*');
                animals[index] = arr[0];
                stats[index] = arr[1] + "\n\n" + arr[2] + "\n\n" + arr[3] + "\n\n" + arr[4];
                blurb[index] = arr[5];
                index++;
            }
        }
        catch (Exception e)
        {
            Debug.Log("Error reading to file: " + e.Message);
        }
        finally
        {
            //as long as the file is open, close it
            if (info != null)
            {
                info.Close();
            }
        }
        //Will Here. Im going to redo this part because theres a better way of reading and writing data to unity plus I need to implement this with loading the save file
        // the entries section is fine because i dont need to implement it.
        /*
        StreamReader picTaken = new StreamReader("../GamesForChange/Files/picTaken_info.txt");
        try
        {
            //loop while there are lines to read
            string line = null;
            int index = 0;
            while ((line = picTaken.ReadLine()) != null)
            {
                if (int.Parse(line) == 1)
                {
                    isPicTaken[index] = true;
                }
                else
                {
                    isPicTaken[index] = false;
                }

                index++;
            }
        }
        catch (Exception e)
        {
            Debug.Log("Error reading to file: " + e.Message);
        }
        finally
        {
            //as long as the file is open, close it
            if (picTaken != null)
            {
                picTaken.Close();
            }
        }
        */
    }
    public void NewLoadText()
    {
        for (int i = 0; i < animals.Length; i++)
        {
            nameText[i].text = animals[i];
            if (isPicTaken[i])
            {
                statText[i].text = stats[i];
                blurbText[i].text = blurb[i];
                
            }
        }
    }
    public void loadData()
    {
        //loading all the names
        for (int i = 0; i < animals.Length; i++)
        {
            nameText[i].text = "Name: " + animals[i];
            //load data that is only available if theres a pic
            if (isPicTaken[i])
            {
                statText[i].text = stats[i];
                blurbText[i].text = blurb[i];
                //Loading the images
                byte[] byteArray = System.IO.File.ReadAllBytes(Application.dataPath + "/Saves/Photos/" + animals[i].ToLower() + "Photo.png");
                Texture2D tex = new Texture2D(2, 2);
                tex.LoadImage(byteArray);
                Rect rec = new Rect(0, 0, tex.width, tex.height); 
                Sprite sprite = Sprite.Create(tex, rec, new Vector2(0, 0), 1); 
                images[i].sprite = sprite;
            }
        }
    }
    public void loadImage(int index, Sprite sprite)
    {
        if (!isPicTaken[index])
        {
            images[index].sprite = sprite;
        }
        
    }

        public void loadDataWeb()
    {
        //loading all the names
        for (int i = 0; i < animals.Length; i++)
        {
            nameText[i].text = "Name: " + animals[i];
            //load data that is only available if theres a pic
            if (isPicTaken[i])
            {
                statText[i].text = stats[i];
                blurbText[i].text = blurb[i];
                //Loading the images
                byte[] byteArray = System.IO.File.ReadAllBytes(Application.persistentDataPath + "/Saves/Photos/" + animals[i].ToLower() + "Photo.png");
                Texture2D tex = new Texture2D(2, 2);
                tex.LoadImage(byteArray);
                Rect rec = new Rect(0, 0, tex.width, tex.height);
                Sprite sprite = Sprite.Create(tex, rec, new Vector2(0, 0), 1);
                images[i].sprite = sprite;
            }
        }
    }

    public int CheckFound(string name)
    {
        
        for(int i = 0; i < isPicTaken.Length; i++)
        {
            if (animals[i].ToLower() == name)
            {
                
                if (!isPicTaken[i]) 
                { 

                    return i;
                }
            } 
        }
        return -1;
        
    }
}
