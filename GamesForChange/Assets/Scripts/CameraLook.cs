using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public Transform lockPosition;
    float camX;
    float camY;
    public float sens;
   



    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    

    void Update()
    {
        camX -= Input.GetAxisRaw("Mouse Y") * sens;
        camX = Mathf.Clamp(camX, -90, 90);

        camY += Input.GetAxisRaw("Mouse X") * sens;

        transform.rotation = Quaternion.Euler(new Vector3(camX, camY, 0));


        transform.position = lockPosition.position;
    }
}
