using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamenController : MonoBehaviour
{
    [SerializeField] private List<int> myList;

    private Elimination _elimination;



    void Start()
    {
        _elimination = new Elimination();
        _elimination.New(myList);
        // _elimination.Show(myList, 0);

        print(_elimination.Count);
    }


}

