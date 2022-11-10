using UnityEngine;
using UnityEngine.InputSystem;


public class MapManager_RTS : MonoBehaviour
{
    [SerializeField] private Vector2Int size;
    [SerializeField] private GameObject prefab;
    [SerializeField] private bool isIso;
    [SerializeField] private Color selectedBlock;
    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;
    [SerializeField] private float offset;

    private Map_RTS _mapRts;
    private Fields_RTS _fieldsRts;
    private FloodPath_RTS _floodPathRts;
    private bool _goalSelected;
    private Vector2 _mousePos;
    private Mouse _mouse;
    private Keyboard _keyboard;
    
    void Start()
    {
        _mouse = Mouse.current;
        _keyboard =Keyboard.current;
        _mapRts = GetComponent<Map_RTS>();
        _fieldsRts = GetComponent<Fields_RTS>();
        _floodPathRts = GetComponent<FloodPath_RTS>();
        _mapRts.Height = size.y;
        _mapRts.Width = size.x;
        
        GameObject[,] map = _mapRts.CreateMap(prefab, _fieldsRts.GetSprite(0), true);
    }

    private void Update()
    {
        if (_mouse.leftButton.wasPressedThisFrame)
        {
            SelectBlock(true);
        }

        if (_mouse.rightButton.wasPressedThisFrame)
        {
            SelectBlock(false);
        }

        if (_keyboard.rKey.wasPressedThisFrame)
        {
            RestartMap();
        }

        if (_keyboard.spaceKey.wasPressedThisFrame)
        {
            _floodPathRts.GetPath();
        }
        
    }


    void SelectBlock(bool isStart)
    {
        _mousePos = _mouse.position.ReadValue();
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(_mousePos);
        if (Physics.Raycast(ray, out hit))
        {
            Block_RTS block = hit.collider.GetComponent<Block_RTS>();
            if (block != null)
            {
                if (isStart)
                {
                    if (_mapRts.Start != null) return;
                    SetStart(block);   
                }
                else
                {
                    if(_mapRts.Goal != null) return;
                    SetEnd(block);
                    
                }
                
            }
        }
    }

    public void RestartMap()
    {
        if (_mapRts.Start != null ||_mapRts.Goal != null)
        {
            Sprite spriteBlock = _fieldsRts.GetSprite(0);
            _mapRts.Start.GetComponent<SpriteRenderer>().sprite = spriteBlock;
            _mapRts.Goal.GetComponent<SpriteRenderer>().sprite = spriteBlock; 
        }
        _floodPathRts.ClearPath(_mapRts.Start,  _mapRts.Goal);
        _mapRts.Start = null;
        _mapRts.Goal = null;
    }

    public void UpdatePoints(Vector2Int block)
    {
        
    }

    public void UpdateObstacle(Vector2Int block)
    {
        
    }
    
    void SetStart(Block_RTS blockStart)
    {
        _mapRts.Start = blockStart;
        Sprite spriteBlock = _fieldsRts.GetSprite(2);
        blockStart.gameObject.GetComponent<SpriteRenderer>().sprite = spriteBlock;
    }

    void SetEnd(Block_RTS blocKEnd)
    {
        _mapRts.Goal = blocKEnd;
        Sprite spriteBlock = _fieldsRts.GetSprite(2);
        blocKEnd.gameObject.GetComponent<SpriteRenderer>().sprite = spriteBlock;

    }
    

    
}
