using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(PlayerController))] //Требуется скрипт PlayerController для работы
public class PlayerInput : MonoBehaviour
{
    [SerializeField]private Camera mainCamera;
    private Interactable previousInteractable;

    // Переменные, которые хранят в себе клавиши
    public KeyCode forward = KeyCode.W;
    public KeyCode back = KeyCode.S;
    public KeyCode right = KeyCode.D;
    public KeyCode left = KeyCode.A;
    public KeyCode turnRight = KeyCode.E;
    public KeyCode turnLeft = KeyCode.Q;

    private PlayerController controller;
    private PlayerStats stats;

    private void Awake()
    {
//        mainCamera = this.GetComponent<Camera>();
        controller = GetComponent<PlayerController>();
        stats = GetComponent<PlayerStats>();
    }

    
    
    private void Update()
    {
        
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 3f))
        {
            var interactable = hit.collider.GetComponent<Interactable>();  //Где-то тут есть баг, из-за которого при наведении на несколько объектов сразу, обводка не пропадает
            var Enemy = hit.collider.GetComponent<EnemyStats>();
            
            if (interactable != null) 
            {
                if (interactable != previousInteractable)
                {
                    interactable.OnHoverEnter();
                    previousInteractable = interactable;
                }
            }
            else if (previousInteractable != null)
            {
                previousInteractable.OnHoverExit();
                previousInteractable = null;
            }

            if (Enemy != null & Input.GetKeyUp(KeyCode.Mouse0))
            {
                stats.Hit(Enemy);
                
            }
            
            
        }


        if (Input.GetKeyUp(forward)) controller.MoveForward();
        if (Input.GetKeyUp(back)) controller.MoveBackward();
        if (Input.GetKeyUp(left)) controller.MoveLeft();
        if (Input.GetKeyUp(right)) controller.MoveRight();
        if (Input.GetKeyUp(turnLeft)) controller.RotateLeft();
        if (Input.GetKeyUp(turnRight)) controller.RotateRight();
        
    }
}
