using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloodPath_RTS : MonoBehaviour
{
    private Queue<Block_RTS> _frontier;
    private Dictionary<Block_RTS, Block_RTS> _cameFrom;
    private Map_RTS _map;
    private MapManager_RTS _manager;
    private Fields_RTS _fieldsRts;
    
    void Start()
    {
        _map = GetComponent<Map_RTS>();
        _manager = GetComponent<MapManager_RTS>();
        _fieldsRts = GetComponent<Fields_RTS>();
        _frontier = new Queue<Block_RTS>();
        _cameFrom = new Dictionary<Block_RTS, Block_RTS>();
    }

    void Update()
    {
        
    }

    public void GetPath()
    {

        if (_map.Start == null && _map.Goal == null) return;
        if (_map.Start == null || _map.Goal == null) return;
            
        // Debug.Log("<color=#33FFE6>Start Path</color>");

        
        Block_RTS startBlock = _map.Start;
        Block_RTS goalBlock = _map.Goal;
       
        _frontier.Enqueue(startBlock);
        _cameFrom[startBlock] = null;

        while (_frontier.Count > 0)
        {
            Block_RTS currentBlock = _frontier.Dequeue();
            Debug.Log("<color=#33FFE6>CURRENT BLOCK WHILE= </color>" + currentBlock.Coordinates);

            GetNeighbours(currentBlock);
        }

        PrintPath(startBlock, goalBlock);
    }

    private void GetNeighbours(Block_RTS currentBlock)
    {
        Debug.Log("entra a getneighboors" + currentBlock.Coordinates);

        if (CheckLimits(currentBlock.Coordinates.x + 1, currentBlock.Coordinates.y))
            AddNext(currentBlock, currentBlock.Coordinates.x + 1 , currentBlock.Coordinates.y);

        if (CheckLimits(currentBlock.Coordinates.x - 1, currentBlock.Coordinates.y))
            AddNext(currentBlock, currentBlock.Coordinates.x - 1 , currentBlock.Coordinates.y);
        

        if (CheckLimits(currentBlock.Coordinates.x, currentBlock.Coordinates.y + 1))
            AddNext(currentBlock, currentBlock.Coordinates.x , currentBlock.Coordinates.y +1);
        

        if (CheckLimits(currentBlock.Coordinates.x, currentBlock.Coordinates.y - 1))
             AddNext(currentBlock, currentBlock.Coordinates.x , currentBlock.Coordinates.y - 1);
        
    }

    private bool CheckLimits(int x, int y)
    {
        if (x >= 0 && x < _map.Width && y >= 0 && y < _map.Height)
        {
            Debug.Log("Check limits true");

            return true;
        }
        
        return false;
    }

    private void AddNext(Block_RTS currentBlock, int x, int y)
    {
        Block_RTS nextBlock = _map.Map[x,y].GetComponent<Block_RTS>();

        if (!_cameFrom.ContainsValue(nextBlock))
        {
            Debug.Log("Agregar next" + nextBlock.Coordinates );
            _frontier.Enqueue(nextBlock);
            _cameFrom[nextBlock] = currentBlock;
        }

    }

    private void PrintPath(Block_RTS startBlock, Block_RTS goalBlock)
    {
        Block_RTS current = _cameFrom[goalBlock];
        if (current != startBlock)
        {
            Block_RTS prePrevious = _cameFrom[current];
            prePrevious.Renderer.sprite = _fieldsRts.GetSprite(2);

        }
        
    }
}
