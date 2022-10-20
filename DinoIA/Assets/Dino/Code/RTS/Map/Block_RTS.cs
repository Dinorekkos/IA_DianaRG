using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_RTS : MonoBehaviour
{
    private int _x;
    private int _y;
    private SpriteRenderer _renderer;
    private Color _color;
    private MapManager_RTS _manager;
    private int _obstacle;
    private int _moveCost;

    public Vector2Int Coordinates
    {
        get
        {
            Vector2Int coordinates = Vector2Int.zero;
            coordinates.x = _x;
            coordinates.y = _y;
            return coordinates;
        }
        set
        {
            Vector2Int coordinates = Vector2Int.zero;

            _x = coordinates.x;
            _y = coordinates.y;
            coordinates = value;
        }
    }

    private void Awake()
    {
    }

    void Update()
    {
        
    }

    public void SetCoordinates(int x, int y)
    {
        _x = x;
        _y = y;
    }
   
    
}
