//UNATHI SHIBE 2593319
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform Bounds_;
    public bool isbeinClicked ;
    Vector2 StartingPos;
    public Rigidbody2D rb;
  
    public float StartXPos, startYPos;
    Bounds Boundaries;
    public bool isGoal;
   public bool canStart2Play;
    private Vector3 playerPos;

    void Start()
    {
        playerPos = transform.position;
        isGoal = false;
        StartingPos = rb.position;
        rb = GetComponent<Rigidbody2D>();
        Boundaries = new Bounds(Bounds_.GetChild(0).position.y,
                                  Bounds_.GetChild(1).position.x,
                                  Bounds_.GetChild(2).position.y,
                                  Bounds_.GetChild(3).position.x);
    }


    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && (playerPos == transform.position) && canStart2Play)
        {
            isGoal = false;

            isbeinClicked = true;
            Vector2 mousePosition;
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            StartXPos = mousePosition.x - this.transform.localPosition.x;
            startYPos = mousePosition.y - this.transform.localPosition.y;


        }
    }
    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && canStart2Play)
        {
            isbeinClicked = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isbeinClicked= false; 
        }
            if (isbeinClicked == true && !isGoal && canStart2Play)
        {
            Vector2 mousePos = Input.mousePosition; ;

            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 Clamped = new Vector2(Mathf.Clamp(mousePos.x, Boundaries.Right,
                                             Boundaries.Left), Mathf.Clamp(mousePos.y,
                                             Boundaries.Up, Boundaries.Down));
            rb.MovePosition(Clamped);

        }
    }
    public void OnMouseUp()
    {
        isbeinClicked = false;
    }
    public void ResetPos()
    {
        rb.position = StartingPos;
    }
}
