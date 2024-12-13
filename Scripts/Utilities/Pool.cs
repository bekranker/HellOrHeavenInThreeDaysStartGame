using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    private Stack<GameObject> _stacked = new();

    public void AddToPool(GameObject v)
    {
        if (_stacked.Contains(v))
        {
            _stacked.Push(v);
        }
    }
    public GameObject RemovePool(GameObject v)
    {
        GameObject tempObj;
        if (_stacked.Peek())
        {
            tempObj = _stacked.Pop();
        }
        else
        {
            tempObj = Instantiate(v);
        }
        return tempObj;
    }

}