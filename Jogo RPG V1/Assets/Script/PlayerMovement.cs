using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
<<<<<<< Updated upstream
    private bool isMoving;
    private Vector3 origPos, targetPos;
    private float timeToMove = 0.2f;
   
=======
    public float moveSpeed = 5;
    private bool walking;

    private Rigidbody2D rb;

    private Vector2 movement;
    private Vector3 moveToPosition;

    public Tilemap obstacles;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
>>>>>>> Stashed changes

    void Update()
    {
        if (!walking)
        {
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");
        }

        if (movement.x != 0)
        {
            movement.y = 0;
        }

        moveToPosition = transform.position + new Vector3(movement.x, movement.y, 0);
        Vector3Int obstacleMapTile = obstacles.WorldToCell(moveToPosition - new Vector3(0, 0.5f, 0));

        if (obstacles.GetTile(obstacleMapTile) == null)
        {
            StartCoroutine(Move(moveToPosition));
        }
    }

    IEnumerator Move(Vector3 newPos)
    {
        walking = true;

        while ((newPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, newPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = newPos;

        walking = false;
    }
}