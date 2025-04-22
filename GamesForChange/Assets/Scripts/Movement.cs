using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    public Camera cam;
    public float speed;

 
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    private void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x, cam.transform.eulerAngles.y, transform.rotation.z);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 100)) {

            transform.position = hit.point + new Vector3(0,5,0);
        }

        
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");

        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;

        rb.velocity = move * speed *Time.fixedDeltaTime;
    }
}
