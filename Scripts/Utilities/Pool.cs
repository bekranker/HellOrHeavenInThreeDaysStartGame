using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T : MonoBehaviour
{
    private Stack<T> _stacked = new();


    public void Spawn(T v, int SpawnCount)
    {
        for (int i = 0; i < SpawnCount; i++)
        {
            Object.Instantiate(v);
        }
    }
    public void AddToPool(T v)
    {
        if (_stacked.Contains(v))
        {
            _stacked.Push(v);
        }
    }
    public T GetFromPool(T v)
    {
        T tempObj;
        if (_stacked != null || _stacked.Peek() != null)
        {
            tempObj = _stacked.Pop();
        }
        else
        {
            tempObj = Object.Instantiate(v);
        }
        return tempObj;
    }

}