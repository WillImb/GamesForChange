using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation.Samples;
using UnityEngine;

public class RabbitHole : MonoBehaviour
{
    public int spawnDist;
    public int hiddenRabbits;
    public Transform player;
    
    public GameObject rabbit;
    public GameObject rabbitArea;

    public float xExtent;
    public float zExtent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) > spawnDist && hiddenRabbits > 0)
        {
            SpawnNewRabbits();
        }
    }

    public void AddRabbit()
    {
        hiddenRabbits++;
    }

    void SpawnNewRabbits()
    {
        
        for (int i = 0; i < hiddenRabbits; i++)
        {
            
            GameObject newRabbit = Instantiate(rabbit, transform.position, Quaternion.identity);
            newRabbit.GetComponent<AIRabbits>().animalArea = rabbitArea.transform;
            newRabbit.GetComponent<AIRabbits>().player = player;
            newRabbit.GetComponent<AIRabbits>().hole = transform;
            newRabbit.GetComponent<AIRabbits>().xExtent = xExtent;
            newRabbit.GetComponent<AIRabbits>().zExtent = zExtent;

        }

        hiddenRabbits = 0;        
    }
}
