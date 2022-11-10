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
        
        Block_RTS startBlock = _map.Start;
        Block_RTS goalBlock = _map.Goal;
       
        _frontier.Enqueue(startBlock);
        _cameFrom[startBlock] = null;

        while (_frontier.Count > 0)
        {
            Block_RTS currentBlock = _frontier.Dequeue();
            GetNeighbours(currentBlock);

        }
        PrintPath(startBlock, goalBlock);

    }

    private void GetNeighbours(Block_RTS currentBlock)
    {
        int x = currentBlock.Coordinates.x;
        int y = currentBlock.Coordinates.y;
        

        if (CheckLimits(x + 1, y)) AddNext(currentBlock, x + 1 , y);

        if (CheckLimits(x - 1, y)) AddNext(currentBlock, x - 1 , y);
        

        if (CheckLimits(x, y + 1)) AddNext(currentBlock, x , y + 1);
        

        if (CheckLimits(x, y - 1)) AddNext(currentBlock, x , y - 1);
        
    }

    private bool CheckLimits(int x, int y)
    {
        if (x >= _map.Width | y>= _map.Height | x < 0 | y <0)
        {
            return false;
        }
        return true;
    }

    private void AddNext(Block_RTS currentBlock, int x, int y)
    {
        Block_RTS nextBlock = _map.Map[x,y].GetComponent<Block_RTS>();
        if (!_cameFrom.ContainsKey(nextBlock))
        {
            _frontier.Enqueue(nextBlock);
            _cameFrom[nextBlock] = currentBlock;
        }
    }

    private void PrintPath(Block_RTS startBlock, Block_RTS goalBlock)
    {
        Block_RTS current = _cameFrom[goalBlock];

        while (current != startBlock)
        {
            current.Renderer.sprite = _fieldsRts.GetSprite(2);
            current = _cameFrom[current];
        }
    }

    public void ClearPath(Block_RTS startBlock, Block_RTS goalBlock)
    {
        Block_RTS current = _cameFrom[goalBlock];
        if (!_cameFrom.ContainsKey(current)) return;

        while (current != startBlock)
        {
            current.Renderer.sprite = _fieldsRts.GetSprite(0);
            current = _cameFrom[current];
        }
        
        _frontier.Clear();
        _cameFrom.Clear();
        _frontier = new Queue<Block_RTS>();
        _cameFrom = new Dictionary<Block_RTS, Block_RTS>();
    }
}
