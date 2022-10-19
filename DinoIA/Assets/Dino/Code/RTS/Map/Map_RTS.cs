using System;
using UnityEngine;
using UnityEngine.InputSystem;


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
    
    private Vector2 _mousePos;
    private Mouse _mouse;

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
                block.transform.parent = gridParent.transform;
                block.transform.position = new Vector3(y+(0.5f * block.transform.localScale.magnitude), x + (0.5f*block.transform.localScale.magnitude),0);
                block.name = $"{x}-{y}";
                _map[x, y] = block;
                
                AddComponents(block);
                Block_RTS myBlock = block.GetComponent<Block_RTS>();
                // myBlock.Coordinates = new Vector2Int()

                if (iso)
                {
                    _rotX = new Vector2(0.5f * (renderer.bounds.size.x + _offset),
                        0.25f * (renderer.bounds.size.y + _offset));
                    _rotY = new Vector2(-0.5f * (renderer.bounds.size.x + _offset),
                        0.25f *(  renderer.bounds.size.y + _offset));

                    _order--;
                    renderer.sortingOrder = _order;
                    Vector2 rotation = (x * _rotX) + (y * _rotY);
                    block.transform.position = rotation;
                }
            }
        }

        gridParent.transform.position = new Vector3(_width * -0.5f, _height * -0.5f, 0);

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
        
    }

    private void Start()
    {
      _mouse = Mouse.current;
     
    }
    private void Update()
    {
        if (_mouse.leftButton.wasPressedThisFrame)
        {
            SelectBlock();
        }
    }


    void SelectBlock()
    {
        _mousePos = _mouse.position.ReadValue();
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(_mousePos);
        if (Physics.Raycast(ray, out hit))
        {
            print("sale raycast" + ray.direction);

            Block_RTS block = hit.collider.GetComponent<Block_RTS>();
            if (block != null)
            {
                SetStart(block);
            }
        }
    }
    
    
    void SetStart(Block_RTS block)
    {
        print(block.name);
    }
    
    
}
