using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class PhotoTaker : MonoBehaviour
{
    public Camera cam;
    [SerializeField] JournalManager journal;
    [SerializeField] Entries entries;
    [SerializeField] Image photoDisplayArea;
    [SerializeField] GameObject photoFrame;
    [SerializeField] bool aimed;
    public GameObject cameraOverlay;

    Texture2D screenCapture;
    bool viewingPhoto;

    [Header("Zoom Settings")]
    public float maxFov;
    public float minFov;
    public float zoomSpeed;

    public int width;
    public int height;

    float x;
    float y;

    public LayerMask mask;


    [SerializeField] Animator fadeAnimator;
    // Start is called before the first frame update
    void Start()
    {
        x = (Screen.width - width) / 2;
        y = (Screen.height - height) / 2;

        screenCapture = new Texture2D(width, height, TextureFormat.RGB24, false);
        cameraOverlay.SetActive(aimed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && !photoDisplayArea.IsActive() && !journal.isBookOpen)
        {
            aimed = !aimed;
            cameraOverlay.SetActive(aimed);
            if (!cameraOverlay.activeSelf)
            {
                cam.fieldOfView = maxFov;
            }
        }

        if (aimed)
        {

            if (Input.GetKey(KeyCode.Q))
            {
                if(cam.fieldOfView >= minFov)
                {
                    ZoomInCamera();
                }
            }
            if (Input.GetKey(KeyCode.E))
            {
                if (cam.fieldOfView <= maxFov)
                {
                    ZoomOutCamera();
                }
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                if (!viewingPhoto)
                {
                    StartCoroutine(CapturePhoto());
                }
                else
                {
                    RemovePhoto();
                }
            }
        }
    }

   

    IEnumerator CapturePhoto()
    {
        viewingPhoto = true;

        cameraOverlay.SetActive(false);

        yield return new WaitForEndOfFrame();


        Rect regionToRead = new Rect(x, y, width, height);

        screenCapture.ReadPixels(regionToRead, 0, 0, false);
        screenCapture.Apply();

       
        

        CheckAnimal();

        cameraOverlay.SetActive(true);

        ShowPhoto();
    }

    void ZoomOutCamera()
    {
        cam.fieldOfView += zoomSpeed * Time.deltaTime;
    }
    void ZoomInCamera()
    {
        cam.fieldOfView -= zoomSpeed * Time.deltaTime;
    }


    void CheckAnimal()
    {
        RaycastHit hit;
        if(Physics.SphereCast(cam.transform.position, 1, cam.transform.forward, out hit, 100f, mask))
        {

            Animal animal = hit.transform.GetComponent<Animal>();

            if (animal.CheckIfHeadInView())
            {
                int index = entries.CheckFound(animal.title.ToLower());
                if (index != -1)
                {
                    //save Photo;
                    byte[] byteArray = screenCapture.EncodeToPNG();
                    System.IO.File.WriteAllBytes(Application.dataPath + "/Saves/Photos/"+animal.title+"Photo.png", byteArray);
                    entries.isPicTaken[index] = true;
                    Debug.Log("Saved Photo");

                    entries.loadData();
                }
            }
                      
        }
    }

    void ShowPhoto()
    {

        Sprite photoSprite = Sprite.Create(screenCapture, new Rect(0, 0, width, height), new Vector2(0f, 0f), 100.0f);
        photoDisplayArea.sprite = photoSprite;



        photoFrame.SetActive(true);
        fadeAnimator.Play("PhotoFade");
    }

    void RemovePhoto()
    {
        viewingPhoto = false;
        photoFrame.SetActive(false);
    }


    
}
