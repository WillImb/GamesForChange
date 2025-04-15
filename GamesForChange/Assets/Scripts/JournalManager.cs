using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JournalManager : MonoBehaviour
{
    public bool isBookOpen = false;
    public int startingPage;
    public int currentPage;
    public GameObject canvas;
    public List<GameObject> pages;
    public UIManager uimanager;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < pages.Count; i++)
        {
            pages[i].SetActive(false);
        }
        canvas.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && !isBookOpen)
        {
            if (!uimanager.screenOpen)
            {
                uimanager.screenOpen = true;
                isBookOpen = true;
                canvas.SetActive(true);
                currentPage = startingPage;
                pages[startingPage].SetActive(true);
                pages[startingPage + 1].SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
        }
        else if (Input.GetKeyDown(KeyCode.J) && isBookOpen) 
        {
            uimanager.screenOpen = false;
            isBookOpen = false;
            canvas.SetActive(false);
            startingPage = currentPage;
            Cursor.lockState = CursorLockMode.Locked;
        }
        if(isBookOpen)
        {
            FlipPage();
        }
    }

    void FlipPage()
    {
        //Debug.Log("in flip page");
        if (Input.GetMouseButtonDown(1) && currentPage != pages.Count - 2)
        {
            Debug.Log("flip forward");
            pages[currentPage].gameObject.SetActive(false);
            pages[currentPage+1].gameObject.SetActive(false);

            currentPage += 2;

            pages[currentPage].gameObject.SetActive(true);
            pages[currentPage + 1].gameObject.SetActive(true);

        }
        else if (Input.GetMouseButtonDown(0) && currentPage != 0)
        {
            Debug.Log("flip backward");
            pages[currentPage].gameObject.SetActive(false);
            pages[currentPage + 1].gameObject.SetActive(false);

            currentPage -= 2;

            pages[currentPage].gameObject.SetActive(true);
            pages[currentPage + 1].gameObject.SetActive(true);
        }
    }


}
