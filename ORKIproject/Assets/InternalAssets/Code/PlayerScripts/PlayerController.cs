using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float transitionSpeed = 10f;
    public float transitionRotationSpeed = 500f;

    private Vector3 targetGridPos;
    private Vector3 prevTargetGridPos;
    private Vector3 targetRotation;

    private void Start()
    {
        targetGridPos = transform.position;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private bool IsWallForward()
    {
        var rayForward = new Ray(this.transform.position, this.transform.forward);
        RaycastHit hit;
        
        if ((Physics.Raycast(rayForward, out hit, 2.1f))) 
        {
            Debug.Log("Стена вперди");
            return false;
        }
        else
        {
            return true;
        }
    }
    private bool IsWallBackward()
    {
        var rayForward = new Ray(this.transform.position, -this.transform.forward);
        RaycastHit hit;
        
        if ((Physics.Raycast(rayForward, out hit, 2.1f))) 
        {

            return false;
        }
        else
        {
            return true;
        }
    }
    private bool IsWallLeft()
    {
        var rayForward = new Ray(this.transform.position, -this.transform.right);
        RaycastHit hit;
        
        if ((Physics.Raycast(rayForward, out hit, 2.1f))) 
        {

            return false;
        }
        else
        {
            return true;
        }
    }
    private bool IsWallRight()
    {
        var rayForward = new Ray(this.transform.position, this.transform.right);
        RaycastHit hit;
        
        if ((Physics.Raycast(rayForward, out hit, 2.1f))) 
        {

            return false;
        }
        else
        {
            return true;
        }
    }
    
    
    
    // ReSharper disable Unity.PerformanceAnalysis
    void MovePlayer()
    {

        prevTargetGridPos = targetGridPos;

        Vector3 targetPosition = targetGridPos;
        if (targetRotation.y > 270f && targetRotation.y < 361f) targetRotation.y = 0f; //Не дает возможности повернуть за 360 градусов
        if (targetRotation.y < 0f) targetRotation.y = 270f; // Не дает повернуть в отрицательные значения

        transform.position =
            Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * transitionSpeed);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), Time.deltaTime * transitionRotationSpeed);


    }

    public void RotateLeft()
    {
        if (AtRest) targetRotation -= Vector3.up * 90f;
    }
    
    public void RotateRight()
    {
        if (AtRest) targetRotation += Vector3.up * 90f;
    }

    public void MoveForward()
    {
        if (AtRest && IsWallForward())
        {
            targetGridPos += transform.forward*2;
            
        }
    }
    
    public void MoveBackward()
    {
        if (AtRest && IsWallBackward())
        {
            targetGridPos -= transform.forward*2;
        }
    }
    
    public void MoveLeft()
    {
        if (AtRest && IsWallLeft())
        {
            targetGridPos -= transform.right*2;
        }
    }
    
    public void MoveRight()
    {
        if (AtRest && IsWallRight())
        {
            targetGridPos += transform.right*2;
        }
    }
    
    

    bool AtRest
    {
        get
        {
            if (Vector3.Distance(transform.position, targetGridPos) < 0.01f &&(Vector3.Distance(transform.eulerAngles, targetRotation) < 0.01f))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    
    

}
