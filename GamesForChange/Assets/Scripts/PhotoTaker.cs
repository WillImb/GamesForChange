using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class PhotoTaker : MonoBehaviour
{
    public Camera cam;

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

    public LayerMask mask;


    [SerializeField] Animator fadeAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
        screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        cameraOverlay.SetActive(aimed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            aimed = !aimed;
            cameraOverlay.SetActive(aimed);
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

        yield return new WaitForEndOfFrame();

        Rect regionToRead = new Rect(0, 0, Screen.width, Screen.height);

        screenCapture.ReadPixels(regionToRead, 0, 0, false);
        screenCapture.Apply();

        CheckAnimal();

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

            hit.transform.GetComponent<Animal>().CheckIfHeadInView();
                      
        }
    }

    void ShowPhoto()
    {

        Sprite photoSprite = Sprite.Create(screenCapture, new Rect(0.0f, 0.0f, screenCapture.width, screenCapture.height), new Vector2(0.5f, 0.5f), 100.0f);
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
