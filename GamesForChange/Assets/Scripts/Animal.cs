using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public string title;
    public Transform head;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public bool CheckIfHeadInView()
    {
        RaycastHit hit;
        if(Physics.Raycast(head.position,Camera.main.transform.position - head.position, out hit , 100f))  
        {
            if(hit.transform.name == "Player")
            {
                return true;
            }
        }

        return false;
    }
}
