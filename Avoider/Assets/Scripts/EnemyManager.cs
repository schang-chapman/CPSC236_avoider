using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] waypoints;
    private GameObject previousWaypoint;
    int current = 0;
    public float speed = 3f;
    float waypointRadius = 0.5f;
    private Vector3 currentDirection;

    public float sightDistance = 15f;
    public LineRenderer lineOfSight;
    public Gradient redColor;
    public Gradient greenColor;

    private bool seenPlayer = false;

    private float chaseTime = 0f;
    public float chaseDuration = 3f;
    private Transform target;

    void Start()
    {
        Physics2D.queriesStartInColliders = false;
        transform.position = waypoints[0].transform.position;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        if (!seenPlayer)
        {
            Patrol();
        } else
        {
            Chase();
        }
    }

    private void Patrol()
    {
        if (Vector3.Distance(waypoints[current].transform.position, transform.position) < waypointRadius)
        {
            previousWaypoint = waypoints[current];
            ++current;
            if (current >= waypoints.Length)
            {
                current = 0;
            }
        }
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, waypoints[current].transform.position, step);
        LookDirection();
    }

    private void LookDirection()
    {
        currentDirection = (waypoints[current].transform.position - previousWaypoint.transform.position).normalized;
        if (currentDirection.x > 0)
        {
            CheckSight(transform.right);
        } else if (currentDirection.x < 0)
        {
            CheckSight(-transform.right);
        } else if (currentDirection.y > 0)
        {
            CheckSight(transform.up);
        } else if (currentDirection.y < 0)
        {
            CheckSight(-transform.up);
        }
    }

    private void CheckSight(Vector3 direction)
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, direction, sightDistance);
        if (hitInfo.collider != null)
        {
            lineOfSight.SetPosition(1, hitInfo.point);
            lineOfSight.colorGradient = redColor;

            if (hitInfo.collider.CompareTag("Player"))
            {
                seenPlayer = true;
            }
        }
        else
        {
            lineOfSight.SetPosition(1, transform.position + direction * sightDistance);
            lineOfSight.colorGradient = greenColor;
        }
        lineOfSight.SetPosition(0, transform.position);
    }

    private void Chase()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        if (chaseTime < chaseDuration)
        {
            chaseTime += Time.fixedDeltaTime;
        } else
        {
            chaseTime = 0f;
            seenPlayer = false;
        }
    }
}
