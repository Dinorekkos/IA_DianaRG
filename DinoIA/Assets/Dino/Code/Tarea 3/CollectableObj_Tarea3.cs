using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollectableObj_Tarea3 : SteerinngBehaviors
{
    [Header("Collectable")]
    public int _indexList;
    public bool isCollected;
    public bool isFlee;
    public bool isPursuit;
    public bool isEvade;

    private SpriteRenderer renderer;
    [SerializeField] private Color _color = Color.red;

    void Start()
    {
        renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isCollected)
        {
            HandleFollowLeader();
        }

        if (isFlee)
        {
            HandleFlee();
        }

        if (isPursuit)
        {
            HandlePuruit();
        }

        if (isEvade)
        {
            HandleEvade();
        }
    }


    void HandleFollowLeader()
    {
        GameObject firstCollectable = Tarea3Controller.Instance.firstCollectable;
        if (firstCollectable.name == transform.name)
        {
            _target = PlayerMovement.Instance.transform.position;
            Move(CalculateSeek(_target, false), false,false); 
            return;
        }
            
        _target = Tarea3Controller.Instance.collectedObjects[_indexList].transform.position;
        Move(CalculateSeek(_target,false),false,false);
    }

    void HandleFlee()
    {
        _target = PlayerMovement.Instance.transform.position;
        _speed = PlayerMovement.Instance._speed / 2;
        Move(CalculateFlee(_target),false,false);
    }

    void HandleEvade()
    {
        _target = PlayerMovement.Instance.positionClick;
        _speed =  PlayerMovement.Instance._speed * 0.80f;
        
        Move(CalculateEvade(_target,false),false,false);
    }

    void HandlePuruit()
    {
        renderer.color = _color;
    }
    
}
