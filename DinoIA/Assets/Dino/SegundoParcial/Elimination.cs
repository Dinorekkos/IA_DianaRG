using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elimination : MonoBehaviour
{
    private List<int> _myList = new List<int>();
    private List<int> _content;
    private int _count;
    private Order _order;
    private int _size;
    private int _interval;


    public List<int> Content
    {
        get { return _content; }
    }

    public int Count
    {
        get { return _count; }
    }

    public void New(List<int> newList)
    {
        _myList = newList;
        _content = _myList;
        _count = CountList(_myList, 0, 0,0);
        _size = _myList.Count;

    }

   

    public int Show(List<int>list, int index)
    {
        if (index < list.Count)
        {
            print(list[index]);
            return list[Show(list, index + 1)];
        }
        return 0;
    }

    public void Eliminate(List<int>list, Order order, int interval)
    {
        
    }
    
   
    
    private int CountList(List<int> list, int index, int count, int prevIndex)
    {
        if (index < list.Count)
        {
            if (list[index] == prevIndex)
            {
                count++;
            }
            return CountList(list, index + 1, count, list[index]);
        }

        return count;
    }
}

public enum Order
{
    Ascendente,
    Descendente,
}