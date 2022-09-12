using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    private Keyboard keyboard;
    public float speed = 3;
    private Vector3 prevPosition;

    public Vector3 currentVelocity;
    private Mouse mouse;
    void Start()
    {
#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_EDITOR || UNITY_STANDALONE_LINUX
        keyboard = Keyboard.current;
        mouse = Mouse.current;
#endif
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        transform.position = position;
        
        GetVelocity();  
    }

    void GetVelocity()
    {
        currentVelocity = transform.position - prevPosition / Time.deltaTime;
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
