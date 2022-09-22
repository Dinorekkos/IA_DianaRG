using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : SteerinngBehaviors
{
    [Header("Player Movement")]
    public Vector3 positionClick;

    private Mouse mouse;
    private Vector2 mouseAxis;
    public Action<GameObject> OnCollectObj;



    // private Keyboard keyboard;
    // public float speed = 3;

    void Start()
    {
#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_EDITOR || UNITY_STANDALONE_LINUX
        // keyboard = Keyboard.current;
        mouse = Mouse.current;
#endif
        
    }

    void Update()
    {
        if (mouse.leftButton.wasPressedThisFrame)
        {
            mouseAxis = mouse.position.ReadValue(); 
            positionClick = Camera.main.ScreenToWorldPoint(mouseAxis);
            positionClick = new Vector3(positionClick.x, positionClick.y, 0);
        }

        Move(CalculateSeek(positionClick, false), false, false);
        
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<CollectableObj_Tarea3>())
        {
            OnCollectObj?.Invoke(col.gameObject);
            print("Add to list");
        }
    }
    
    
    // void MovePlayer()
    // {
        // if (keyboard.aKey.isPressed)
        // {
            // transform.position += Vector3.left * speed * Time.deltaTime;
        // }
        // if (keyboard.dKey.isPressed)
        // {
            // transform.position += Vector3.right * speed * Time.deltaTime;   
        // }

        // if (keyboard.wKey.isPressed)
        // {
            // transform.position += Vector3.forward * speed * Time.deltaTime;  
        // }

        // if (keyboard.sKey.isPressed)
        // {
            // transform.position += Vector3.back * speed * Time.deltaTime;  
        // }
        
    // }
}
