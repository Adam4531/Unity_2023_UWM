using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float speed = 10.0f;
    private Vector3 startPosition;
    private bool isMovingForward = true;

    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(isMovingForward){
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            if(transform.position.x > startPosition.x + speed ){
                isMovingForward = false;
            }
        } else {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if(transform.position.x < startPosition.x){
                isMovingForward = true;
            }
        }
    }
}
