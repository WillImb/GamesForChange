using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadWorld : MonoBehaviour
{
    // Start is called before the first frame update
    int world;

    public GameObject player;
    public Entries entries;

    void Start()
    {
       



    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SaveWorld();
        }
    }


    public void SaveWorld()
    {
        WorldSave save = new WorldSave
        {
            tutorial = false,
            playerPos = player.transform.position,
            pictures = entries.isPicTaken
        };
        

        string json = JsonUtility.ToJson(save);

        if (world != 4)
        {
            File.WriteAllText(Application.dataPath + "/Saves/save" + world.ToString() + ".txt", json);
            Debug.Log("Saved!");
        }
        Debug.Log(world);
    }



    public void Load()
    {

    }






    


    class WorldSave
    {
        public bool tutorial;
        public Vector3 playerPos;
        public bool[] pictures;

       

    }
}
