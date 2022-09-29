
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BoardManager : MonoBehaviour
{

    [SerializeField] private GameObject prefabTile;
    [SerializeField] private GameObject gridParent;

    public GameObject selectedTile;
    
    public int width;
    public int height;

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
        if (_mouse.leftButton.wasPressedThisFrame)
        {

            mouseAxis = _mouse.position.ReadValue();
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(mouseAxis);
            
            
            if (Physics.Raycast(ray, out hit))
            {
                selectedTile = SelectGameObjectSeed(hit);
            }
            

        }
    }

    public void CreateBoard()
    {
        tilemap = new GameObject[width, height];

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
               GameObject cellTile = Instantiate(prefabTile);
               cellTile.transform.parent = gridParent.transform;
               // cellTile.transform.position = new Vector3(i + (prefabTile.transform.position.x/2), j + (prefabTile.transform.position.y/ 2),0);
               cellTile.transform.position = new Vector3(i + (0.5f * cellTile.transform.localScale.magnitude), j + (0.5f * cellTile.transform.localScale.magnitude),0);
               cellTile.name = $"{j}-{i}";
               tilemap[i,j] = cellTile;
            }
        }

        gridParent.transform.position = new Vector3(width * -0.5f, height * -0.5f, 0);
    }



    GameObject SelectGameObjectSeed(RaycastHit hit)
    {
        GameObject myTile = hit.transform.gameObject;
        Tile tile = myTile.GetComponent<Tile>();
        tile.ChangeColor();
        
        return myTile;
    }
    
    
    
}
