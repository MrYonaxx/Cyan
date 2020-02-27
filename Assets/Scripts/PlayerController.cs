using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Transform pivotCamera;
    [SerializeField]
    Camera camera;
    [SerializeField]
    CharacterController characterController;
    [SerializeField]
    float speed = 2;
    [SerializeField]
    float sensitivity = 2;

    float speedX = 0;
    float speedZ = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerInputCamera();
        Move();
    }

    public void Move()
    {
        if (Mathf.Abs(Input.GetAxis("Vertical")) != 0)
        {
            speedZ = -Input.GetAxis("Vertical");
        }
        else
        {
            speedZ = 0;
        }

        if (Mathf.Abs(Input.GetAxis("Horizontal")) != 0)
        {
            speedX = Input.GetAxis("Horizontal");
        }
        else
        {
            speedX = 0;
        }

        var forward = pivotCamera.forward;
        var right = pivotCamera.right;
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();
        Vector3 move = right * speedX + forward * speedZ;
        move *= speed;

        //rigidbodyCharacter.velocity = move * defaultSpeed * Time.deltaTime;
        characterController.Move(move * Time.deltaTime);
    }

    public void CheckPlayerInputCamera()
    {
        float rotateHorizontal = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float rotateVertical = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        transform.localRotation = Quaternion.Euler(rotateHorizontal, 0f, 0f);
        transform.RotateAround(pivotCamera.transform.position, Vector3.up, rotateHorizontal * sensitivity); 
        
        //use transform.Rotate(-transform.up * rotateHorizontal * sensitivity) instead if you dont want the camera to rotate around the player

        //transform.RotateAround(Vector3.zero, transform.right, rotateVertical * sensitivity);
    }


}
