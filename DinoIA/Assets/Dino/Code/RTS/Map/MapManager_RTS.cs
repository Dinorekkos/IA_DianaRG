using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        Map_RTS mapRts = GetComponent<Map_RTS>();
        Fields_RTS fieldsRts = GetComponent<Fields_RTS>();
        mapRts.Height = size.y;
        mapRts.Width = size.x;
        
        GameObject[,] map = mapRts.CreateMap(prefab, fieldsRts.GetSprite(0), true);
    }

    void Update()
    {
        
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
    
    
    
}
