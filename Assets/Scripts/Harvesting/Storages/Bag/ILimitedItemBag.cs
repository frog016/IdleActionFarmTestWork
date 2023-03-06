using System;

public interface ILimitedItemBag<TItem>
{
    int Count { get; }
    int Capacity { get; }
    event Action<TItem, ContentAction> ContentChanged;
    bool Add(TItem item);
    bool Pop(out TItem item);
}