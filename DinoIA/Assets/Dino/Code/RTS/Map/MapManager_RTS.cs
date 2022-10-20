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

    private bool _goalSelected;
    private Vector2 _mousePos;
    private Mouse _mouse;
    
    void Start()
    {
        _mouse = Mouse.current;
        Map_RTS mapRts = GetComponent<Map_RTS>();
        Fields_RTS fieldsRts = GetComponent<Fields_RTS>();
        mapRts.Height = size.y;
        mapRts.Width = size.x;
        
        GameObject[,] map = mapRts.CreateMap(prefab, fieldsRts.GetSprite(0), true);
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
            Block_RTS block = hit.collider.GetComponent<Block_RTS>();
            if (block != null)
            {
               SetStart(block);
            }
        }
    }

    public void RestartMap()
    {
        
    }

    public void UpdatePoints(Vector2Int block)
    {
        
    }

    public void UpdateObstacle(Vector2Int block)
    {
        
    }
    
    public void SetStart(Block_RTS block)
    {
        Fields_RTS fieldsRts = GetComponent<Fields_RTS>();
        Sprite spriteBlock = fieldsRts.GetSprite(1);
        block.gameObject.GetComponent<SpriteRenderer>().sprite = spriteBlock;
    }

    
}
