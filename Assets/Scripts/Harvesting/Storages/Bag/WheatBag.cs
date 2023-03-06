using System;
using System.Collections.Generic;
using UnityEngine;

public class WheatBag : MonoBehaviour, ILimitedItemBag<WheatBlock>
{
    [SerializeField] private int _capacity;
    
    public int Count => _stack.Count;
    public int Capacity => _capacity;
    public WheatBlock Last => _stack.Peek();
    public event Action<WheatBlock, ContentAction> ContentChanged;

    private readonly Stack<WheatBlock> _stack = new Stack<WheatBlock>();

    public bool Add(WheatBlock item)
    {
        if (_stack.Count == _capacity)
            return false;

        ContentChanged?.Invoke(item, ContentAction.Add);
        _stack.Push(item);

        return true;
    }

    public bool Pop(out WheatBlock item)
    {
        item = null;
        if (_stack.Count == 0)
            return false;

        item = _stack.Pop();
        ContentChanged?.Invoke(item, ContentAction.Pop);

        return true;
    }
}