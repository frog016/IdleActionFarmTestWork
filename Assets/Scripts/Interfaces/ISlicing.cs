using System;

public interface ISlicing
{
    event Action Sliced;
    void Slice();
}