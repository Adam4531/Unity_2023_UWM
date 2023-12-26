using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquarereMovement : MonoBehaviour
{
    private float movementAngle = 90.0f;
    public float speed = 10.0f;
    private int currentDirection = 1;
    private Vector3 currentPosition;

    // Start is called before the first frame update
    void Start()
    {
        currentPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentDirection == 1){
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            if(transform.position.z > currentPosition.z + speed){
                transform.Rotate(0, movementAngle, 0, Space.World);
                currentPosition = transform.position;
                currentDirection = 2;
            }
        }
        if(currentDirection == 2){
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            if(transform.position.x > currentPosition.x + speed){
                currentDirection = 3;
                transform.Rotate(0, movementAngle, 0, Space.World);
                currentPosition = transform.position;
            }
        }
        if(currentDirection == 3){
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            if(transform.position.z < currentPosition.z - speed){
                currentDirection = 4;
                transform.Rotate(0, movementAngle, 0, Space.World);
                currentPosition = transform.position;
            }
        }
        if(currentDirection == 4){
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            if(transform.position.x < currentPosition.x - speed){
                currentDirection = 1;
                transform.Rotate(0, movementAngle, 0, Space.World);
                currentPosition = transform.position;
            }
        }
    }
}
