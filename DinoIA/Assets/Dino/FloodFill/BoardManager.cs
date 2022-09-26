
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{

    [SerializeField] private GameObject prefabTile;
    [SerializeField] private GameObject gridParent;
    public int width;
    public int height;
    private GameObject[,] tilemap;

    public GameObject[,] MyTilemap
    {
        get => tilemap;
    }
    void Start()
    {
        CreateBoard();
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



    GameObject SelectGameObjectSeed()
    {
        GameObject myTile = new GameObject();

        // if (Physics.Raycast())
        // {
            
        // }

        return myTile;
    }
    
    
    
}
