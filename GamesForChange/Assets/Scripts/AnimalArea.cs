using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalArea : MonoBehaviour
{
   
    public float maxDist;
    public Transform player;
    bool shown;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Vector3.Distance(player.position, transform.position) <= maxDist)
        {
            if (!shown)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                shown = true;
            }
        }
        else 
        {
            if (shown)
            {
                transform.GetChild(0).gameObject.SetActive(false);
                shown = false;
            }
        }
       
        
    }

   


    

}
