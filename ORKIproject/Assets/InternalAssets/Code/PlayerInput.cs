using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(PlayerController))] //Требуется скрипт PlayerController для работы
public class PlayerInput : MonoBehaviour
{
    
    // Переменные, которые хранят в себе клавиши
    public KeyCode forward = KeyCode.W;
    public KeyCode back = KeyCode.S;
    public KeyCode right = KeyCode.D;
    public KeyCode left = KeyCode.A;
    public KeyCode turnRight = KeyCode.E;
    public KeyCode turnLeft = KeyCode.Q;

    private PlayerController controller; 

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(forward)) controller.MoveForward();
        if (Input.GetKeyUp(back)) controller.MoveBackward();
        if (Input.GetKeyUp(left)) controller.MoveLeft();
        if (Input.GetKeyUp(right)) controller.MoveRight();
        if (Input.GetKeyUp(turnLeft)) controller.RotateLeft();
        if (Input.GetKeyUp(turnRight)) controller.RotateRight();
    }
}
