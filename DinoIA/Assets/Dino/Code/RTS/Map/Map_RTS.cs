using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_RTS : MonoBehaviour
{
    private GameObject[,] _map;
    private int _height;
    private int _width;
    private Vector2 _rotX;
    private Vector2 _rotY;
    private float _offset;
    private bool _isIso;
    private int _order;

    private Block_RTS _start;
    private Block_RTS _goal;

    public int Height
    {
        get => _height;
        set => _height = value;
    }

    public int Width
    {
        get => _width;
        set => _width = value;
    }

public GameObject[,] CreateMap(GameObject prefab, Sprite sprite=null, bool iso = false)
    {
        _map = new GameObject[_width, _height];

        for (int y = 0; y < _width; y++)
        {
            for (int x = 0; x < _height; x++)
            {
                GameObject block = Instantiate(prefab);
                SpriteRenderer renderer = block.GetComponent<SpriteRenderer>();
                block.transform.parent = transform;
                block.name = $"{x}-{y}";
                _map[x, y] = block;
            }
        }
        

        return _map;
    }

    public void AddComponents(GameObject component)
    {
        
    }

    public void CreateIsoMap(GameObject map, SpriteRenderer render, float width, float height)
    {
        
    }

    public void CenterMap()
    {
        
    }







}
