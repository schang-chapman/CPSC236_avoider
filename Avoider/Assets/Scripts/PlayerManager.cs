using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float speed = 10f;
    public float speedUpDuration = 1.5f;
    private float speedUpTime = 0f;
    private bool isSpeeding = false;
    private bool hasSpedUp = false;

    public float clickDelay = 0.5f;
    private float lastClick;
    private float clickTime;

    private Vector3 lastClickedPos;
    private bool isMoving;
    private Rigidbody2D rb;

    public GameObject treasure;
    private bool hasTreasure = false;

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickTime = Time.time - lastClick;
            if (clickTime < clickDelay)
            {
                isSpeeding = true;
            } else
            {
                SetMousePosition();
            }
            lastClick = Time.time;
        }

        if (isMoving)
        {
            Move();
        }

        if (isSpeeding)
        {
            SpeedUp();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject == treasure)
        {
            hasTreasure = true;
            treasure.SetActive(false);
        }
    }

    private void SpeedUp()
    {
        if (speedUpTime < speedUpDuration)
        {
            if (!hasSpedUp)
            {
                speed = speed * 2;
                hasSpedUp = true;
            }
            speedUpTime += Time.fixedDeltaTime;
        } else
        {
            speedUpTime = 0f;
            speed = speed / 2;
            isSpeeding = false;
            hasSpedUp = false;
        }
    }
}
