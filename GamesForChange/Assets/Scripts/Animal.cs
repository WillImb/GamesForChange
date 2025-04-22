using System.Collections;
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


    public bool CheckIfHeadInView(LayerMask mask)
    {
        Debug.Log("hit");
        RaycastHit hit;
        if(Physics.Raycast(head.position,Camera.main.transform.position - head.position, out hit , 300f, mask))  
        {
           
            if (hit.transform.name == "Player")
            {
                Debug.Log(name);
                return true;
               
            }
        }

        return false;
    }
}
