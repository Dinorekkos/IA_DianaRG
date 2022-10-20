using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloodPath_RTS : MonoBehaviour
{
    private Queue<Block_RTS> _frontier;
    private Dictionary<Block_RTS, Block_RTS> _comeFrom;
    private Map_RTS _map;
    private MapManager_RTS _manager;
    
    void Start()
    {
        _map = GetComponent<Map_RTS>();
        _manager = GetComponent<MapManager_RTS>();
        _frontier = new Queue<Block_RTS>();
        _comeFrom = new Dictionary<Block_RTS, Block_RTS>();
    }

    void Update()
    {
        
    }

    public void GetPath()
    {

        if (_map.Start == null && _map.Goal == null) return;
        if (_map.Start == null || _map.Goal == null) return;
            
        Debug.Log("<color=#33FFE6>Start Path</color>");

        
        Block_RTS startBlock = _map.Start;
        Block_RTS goalBlock = _map.Goal;
       
        _frontier.Enqueue(startBlock);
        _comeFrom[startBlock] = null;

        while (_frontier.Count > 0)
        {
            Block_RTS currentBlock = _frontier.Dequeue();
            GetNeighbours(currentBlock);
        }





    }

    private void GetNeighbours(Block_RTS block)
    {

        if (CheckLimits(block.Coordinates.x + 1, block.Coordinates.y))
            AddNext(block, block.Coordinates.x + 1 , block.Coordinates.y);

        if (CheckLimits(block.Coordinates.x - 1, block.Coordinates.y))
            AddNext(block, block.Coordinates.x - 1 , block.Coordinates.y);
        

        if (CheckLimits(block.Coordinates.x, block.Coordinates.y + 1))
            AddNext(block, block.Coordinates.x , block.Coordinates.y +1);
        

        if (CheckLimits(block.Coordinates.x, block.Coordinates.y - 1))
             AddNext(block, block.Coordinates.x , block.Coordinates.y - 1);

        Debug.Log("entra a getneighboors" + block.Coordinates);



    }

    private bool CheckLimits(int x, int y)
    {
        if (x >= 0 && x < _map.Width && y >= 0 && y < _map.Height)
        {
            return true;
        }
        
        return false;
    }

    private void AddNext(Block_RTS currentBlock, int x, int y)
    {
        Block_RTS nextBlock = _map.Map[x,y].GetComponent<Block_RTS>();

        if (_comeFrom.ContainsValue(nextBlock))
        {
            Debug.Log("entra a getneighboors" );

        }

    }

    private void PrintPath()
    {
        
    }
}
