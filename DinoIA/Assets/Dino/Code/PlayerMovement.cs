using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : SteerinngBehaviors
{

    public static PlayerMovement Instance;
    
    
    [Header("Player Movement")]
    public Vector3 positionClick;

    private Mouse mouse;
    private Vector2 mouseAxis;
    public Action<GameObject> OnCollectObj;
    public Action OnPursuiTouchPlayer;
    
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_EDITOR || UNITY_STANDALONE_LINUX
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
            CollectableObj_Tarea3 collectable = col.gameObject.GetComponent<CollectableObj_Tarea3>();

            if (collectable.isPursuit)
            {
                OnPursuiTouchPlayer?.Invoke();
                return;
            }
            col.isTrigger = false; 
            if (collectable.isFlee) collectable.isFlee = false;
            if (collectable.isEvade) collectable.isEvade = false;
            collectable.isCollected = true;
            OnCollectObj?.Invoke(col.gameObject);
            collectable._indexList = Tarea3Controller.Instance.collectedObjects.Count - 2;
           
        }
    }
}
