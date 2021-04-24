using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float speed = 10f;

    private Vector3 lastClickedPos;
    private bool isMoving;
    private Rigidbody2D rb;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetMousePosition();
        }
        if (isMoving)
        {
            Move();
        }
    }

    private void SetMousePosition()
    {
        lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lastClickedPos.z = transform.position.z;
        isMoving = true;
    }

    private void Move()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, lastClickedPos, step);

        if (transform.position == lastClickedPos)
        {
            isMoving = false;
        }
    }

    //I put this here to try and stop the player from jittering in place, but it only stopped some cases of the jitter
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Environment")
        {
            float step = 0;
            transform.position = Vector2.MoveTowards(transform.position, transform.position, step);
            isMoving = false;
        }
    }
}
