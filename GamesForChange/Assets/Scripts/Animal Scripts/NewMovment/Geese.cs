using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Geese : MonoBehaviour
{
    public Transform gooseLead;
    public GameObject[] geese;

    public int maxDist;
    public int waitTime;
    bool flying;

    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        StartFly();
    }

    // Update is called once per frame
    void Update()
    {
        if (flying)
        {
            gooseLead.transform.position += gooseLead.forward * speed * Time.deltaTime;
            if (Vector3.Distance(gooseLead.position, transform.position) > maxDist)
            {
                foreach(GameObject g in geese)
                {
                    g.SetActive(false);
                }
                StartCoroutine(Intermission());
            }

            
        }
    }
    IEnumerator Intermission()
    {
        flying = false;
        yield return new WaitForSeconds(waitTime);
        StartFly();
    }

    void StartFly()
    {
        int num = Random.Range(1, 6);

        for(int i = 0; i < 6; i++)
        {
            if (i <= num)
            {
                geese[i].SetActive(true);
            }
            else
            {
                geese[i].SetActive(false);
            }
        }
        gooseLead.position = transform.position;
        gooseLead.forward = transform.forward;

        flying = true;
    }
}
