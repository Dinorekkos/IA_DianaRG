using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Keyboard keyboard;
    public float speed = 3;
    private Vector3 prevPosition;

    public Vector3 currentVelocity;
    private Mouse mouse;
    private Vector2 mouseAxis;
    void Start()
    {
#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_EDITOR || UNITY_STANDALONE_LINUX
        keyboard = Keyboard.current;
        mouse = Mouse.current;
#endif
        
    }

    void Update()
    {
        mouseAxis = mouse.position.ReadValue();
        Vector3 position = Camera.main.ScreenToWorldPoint(mouseAxis);
        transform.position = new Vector3(position.x, position.y, 0);
        
    }
    
    void MovePlayer()
    {
        if (keyboard.aKey.isPressed)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        
        
        if (keyboard.dKey.isPressed)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;   
        }

        if (keyboard.wKey.isPressed)
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;  
        }

        if (keyboard.sKey.isPressed)
        {
            transform.position += Vector3.back * speed * Time.deltaTime;  
        }
        
    }
}
