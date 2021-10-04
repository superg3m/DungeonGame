using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera cam;
    private Vector2 moveDirec;
    private Vector2 mousePos;
    private float speed = 100;
    float angle;

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirec = new Vector3(moveX, moveY);
        // Handles rotation of sprite to user input mouse position
        mousePos= cam.ScreenToWorldPoint(Input.mousePosition);
        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirec.x * speed * Time.deltaTime, moveDirec.y * speed * Time.deltaTime);
        rb.rotation = angle;
    }
}
