using System;
using UnityEngine;


public class Map_RTS : MonoBehaviour
{
    [SerializeField] private GameObject gridParent;
    
    private GameObject[,] _map;
    private int _height;
    private int _width;
    private Vector2 _rotX;
    private Vector2 _rotY;
    private float _offset;
    private bool _isIso;
    private int _order = 50;
    
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
                GameObject block = Instantiate(prefab, gridParent.transform);
                SpriteRenderer renderer = block.GetComponent<SpriteRenderer>();

                float halfSizeBlock = block.transform.localScale.magnitude * 0.5f;
                block.transform.position = new Vector3(y+ halfSizeBlock , x + halfSizeBlock,0);
                block.name = $"{x}-{y}";
                _map[x, y] = block;
                
                AddComponents(block);
                Block_RTS myBlock = block.GetComponent<Block_RTS>();
                // myBlock.Coordinates = new Vector2Int()

                if (iso)
                {
                    Vector2 sizeSprite = renderer.bounds.size;
                    
                    _rotX = new Vector2(0.5f * (sizeSprite.x + _offset),
                        0.25f * (sizeSprite.y + _offset));
                    _rotY = new Vector2(-0.5f * (sizeSprite.x + _offset),
                        0.25f *(sizeSprite.y + _offset));

                    _order--;
                    renderer.sortingOrder = _order;
                    Vector2 rotation = (x * _rotX) + (y * _rotY);
                    block.transform.position = rotation;
                }
            }
        }
        
        CenterMap();
        return _map;
    }

    public void AddComponents(GameObject component)
    {
        component.AddComponent<Block_RTS>();
    }

    public void CreateIsoMap(GameObject map, SpriteRenderer render, float width, float height)
    {
        
    }

    public void CenterMap()
    {
        gridParent.transform.position = new Vector3(0, _height * -0.5f, 0);
    }

    
}
