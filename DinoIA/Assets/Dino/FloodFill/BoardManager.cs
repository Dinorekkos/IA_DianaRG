
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BoardManager : MonoBehaviour
{

    [Header("Tile Selected")]
    public Vector2 selectedTilePos;

    [Header("Tilemap")]
    [SerializeField] private GameObject prefabTile;
    [SerializeField] private GameObject gridParent;
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private float delay;

    private Mouse _mouse;
    private Vector2 mouseAxis;
    private Keyboard _keyboard;

    private GameObject[,] tilemap;
    public GameObject[,] MyTilemap
    {
        get => tilemap;
    }
    void Start()
    {
#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_EDITOR || UNITY_STANDALONE_LINUX
        _mouse = Mouse.current;
        _keyboard = Keyboard.current;
#endif
        CreateBoard();
    }

    private void Update()
    {
        if (_mouse.leftButton.wasPressedThisFrame )
            SelectTileWithMouse(false);
        

        if (_mouse.rightButton.wasPressedThisFrame) 
            SelectTileWithMouse(true);

        if (_keyboard.spaceKey.wasPressedThisFrame)
        {
           if(selectedTilePos!=null) StartCoroutine(DoFloodFill(selectedTilePos));

        }
        
    }

    void SelectTileWithMouse(bool isObstacle)
    {
        mouseAxis = _mouse.position.ReadValue();
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(mouseAxis);
        if (Physics.Raycast(ray, out hit))
        {
            if (isObstacle) SetSeed(hit, true);
            else SetSeed(hit, false);
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
    
    void SetSeed(RaycastHit hit, bool isObstacle)
    {
        GameObject myTile = hit.transform.gameObject;
        Tile tile = myTile.GetComponent<Tile>();
        var coord = tile.name.Split("-");
        selectedTilePos.x = float.Parse(coord[0]);
        selectedTilePos.y = float.Parse(coord[1]);
        if (isObstacle) tile.SetGreen();
        else tile.SetSeed();
        
        // StartCoroutine(DoFloodFill(selectedTilePos));
    }

    IEnumerator DoFloodFill(Vector2 posTile)
    {
   
        if (posTile.x >= 0 && posTile.x < width && posTile.y >= 0 && posTile.y < height)
        { 
            Tile tileFill = tilemap[(int)(posTile.x), (int)(posTile.y)].GetComponent<Tile>();

            yield return new WaitForSeconds(delay);
            // if (!tileFill.isRed && !tileFill.isGreen)
            if (!tileFill.isRed && !tileFill.isGreen)
            {
                if(!tileFill.isSeed) tileFill.SetRed();
                if (posTile.x + 1 < width ) StartCoroutine(DoFloodFill(new Vector2((posTile.x + 1), posTile.y)));
                if (posTile.x - 1 <= width ) StartCoroutine(DoFloodFill(new Vector2((posTile.x - 1), posTile.y)));
                if (posTile.y + 1 < height) StartCoroutine(DoFloodFill(new Vector2(posTile.x , (posTile.y + 1))));
                if (posTile.y - 1 <= height)  StartCoroutine(DoFloodFill(new Vector2(posTile.x , (posTile.y - 1))));
            }
        }
    }
    
    
    
    
}
