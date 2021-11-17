using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookMovement : MonoBehaviour
{
    public float minZrotate = -55f, maxZrotate = 55f;
    public float rotateSpeed = 50f;

    private float rotateAngle;

    private bool rotateRight;
    private bool canRotate;

    public float moveSpeed = 3f;
    private float initialMoveSpeed;

    public float minYposition = -2.5f;

    private float initialY;

    private bool moveDown;

    //linerener
    private RopeRenderer ropeRenderer;

    private void Awake()
    {
        ropeRenderer = GetComponent<RopeRenderer>();
    }

    void Start()
    {
        initialY = transform.position.y;
        initialMoveSpeed = moveSpeed;

        canRotate = true;

    }

   
    void Update()
    {
        Rotate();
        GetInput();
        MoveRope();
    }

    private void Rotate()
    {
        if (!canRotate)
        {
            return;
        }

        if (rotateRight)
        {
            rotateAngle += rotateSpeed * Time.deltaTime;
        }
        else
        {
            rotateAngle -= rotateSpeed * Time.deltaTime;
        }

        transform.rotation = Quaternion.AngleAxis(rotateAngle, Vector3.forward);//по z будет фигачить

        if (rotateAngle >= maxZrotate)
        {
            rotateRight = false;
        }
        else if (rotateAngle <= minZrotate)
        {
            rotateRight = true;
        }

       
    }//rot

    void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canRotate)
            {
                canRotate = false;
                moveDown = true;
            }
        }
    }

    void MoveRope()
    {
        if (canRotate)
        {
            return;
        }

        if (!canRotate)
        {
            //sounman

            Vector3 temp = transform.position;
            if (moveDown)
            {
                temp-= transform.up * Time.deltaTime * moveSpeed;
            }
            else
            {
                temp += transform.up * Time.deltaTime * moveSpeed;
            }

            transform.position = temp;

            if (temp.y <= minYposition)
            {
                moveDown = false;
            }
            if (temp.y >= initialY)
            {
                canRotate = true;
                ropeRenderer.RenderLine(Vector3.zero, false);
                //reset
                moveSpeed = initialMoveSpeed;
            }
            ropeRenderer.RenderLine(temp, true);
        }//

        
    }

    public void HookAttachedItem()
    {
        moveDown = false;
    }









}//class
