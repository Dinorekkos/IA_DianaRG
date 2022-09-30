
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BoardManager : MonoBehaviour
{

    [Header("Tile Selected")]
    public GameObject selectedTile;
    public Vector2 selectedTilePos;

    [Header("Tilemap")]
    [SerializeField] private GameObject prefabTile;
    [SerializeField] private GameObject gridParent;
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private float delay;

    private Mouse _mouse;
    private Vector2 mouseAxis;    


    private GameObject[,] tilemap;
    public GameObject[,] MyTilemap
    {
        get => tilemap;
    }
    void Start()
    {
#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_EDITOR || UNITY_STANDALONE_LINUX
        _mouse = Mouse.current;
#endif
        CreateBoard();
    }

    private void Update()
    {
        if (_mouse.leftButton.wasPressedThisFrame )
        {
            mouseAxis = _mouse.position.ReadValue();
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(mouseAxis);
            
            if (Physics.Raycast(ray, out hit))
            {
                selectedTile = SelectGameObjectSeed(hit, false);
                StartCoroutine(FloodFill(selectedTilePos));
            }
        }

        if (_mouse.rightButton.wasPressedThisFrame)
        {
            mouseAxis = _mouse.position.ReadValue();
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(mouseAxis);
            if (Physics.Raycast(ray, out hit))
            {
                selectedTile = SelectGameObjectSeed(hit, true);
                
            }
        }
    }
    

    public void CreateBoard()
    {
        tilemap = new GameObject[width, height];

        for (int y = 0; y < width; y++)
        {
            for (int x = 0; x < height; x++)
            {
               GameObject cellTile = Instantiate(prefabTile);
               cellTile.transform.parent = gridParent.transform;
               cellTile.transform.position = new Vector3(y + (0.5f * cellTile.transform.localScale.magnitude), x + (0.5f * cellTile.transform.localScale.magnitude),0);
               cellTile.name = $"{x}-{y}";
               tilemap[x,y] = cellTile;
            }
        }

        gridParent.transform.position = new Vector3(width * -0.5f, height * -0.5f, 0);
    }
    
    GameObject SelectGameObjectSeed(RaycastHit hit, bool isObstacle)
    {
        GameObject myTile = hit.transform.gameObject;
        Tile tile = myTile.GetComponent<Tile>();

        if (isObstacle)
        {
            tile.SetGreen();
        }
        
        var coord = tile.name.Split("-");
        selectedTilePos.x = float.Parse(coord[0]);
        selectedTilePos.y = float.Parse(coord[1]);
        
        return myTile;
    }

    IEnumerator FloodFill(Vector2 posTile)
    {
   
        if (posTile.x >= 0 && posTile.x < width && posTile.y >= 0 && posTile.y < height)
        { 
            Tile tileFill = tilemap[(int)(posTile.x), (int)(posTile.y)].GetComponent<Tile>();

            yield return new WaitForSeconds(delay);
            if (!tileFill.isRed && !tileFill.isGreen)
            {
                tileFill.ChangeColor();
                if (posTile.x + 1 < width ) StartCoroutine(FloodFill(new Vector2((posTile.x + 1), posTile.y)));
                if (posTile.x - 1 <= width ) StartCoroutine(FloodFill(new Vector2((posTile.x - 1), posTile.y)));
                if (posTile.y + 1 < height) StartCoroutine(FloodFill(new Vector2(posTile.x , (posTile.y + 1))));
                if (posTile.y - 1 <= height)  StartCoroutine(FloodFill(new Vector2(posTile.x , (posTile.y - 1))));
            }
        }
    }
    
    
    
    
}
