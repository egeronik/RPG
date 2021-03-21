using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMove : MonoBehaviour
{
    public float speed;
    public GameObject Up;
    private Vector3 TPosition;
    private bool isMoving = false;
    Transform target;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            TriggerPosition();
        }

        if (isMoving)
        {
            ItsMove();
        }
    }

    void TriggerPosition()
    {
        TPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        TPosition.z = transform.position.z;

        isMoving = true;
        target.position = Up.transform.position;
    }

    void ItsMove()
    {
      //transform.rotation = Quaternion.LookRotation(Vector3.forward, TPosition);
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);



        if (transform.position == target.position)
        {
            isMoving = false;
        }
    }
}
