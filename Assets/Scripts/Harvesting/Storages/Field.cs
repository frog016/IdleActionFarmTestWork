using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField] private int _growUpTime;
    [SerializeField] private Vector3Int _fieldSize;
    [SerializeField] private Wheat _wheatPrefab;

    private void Start()
    {
        GrowWheat();
    }

    public void GrowWheat()
    {
        var initialPosition = GetLeftBottomPosition();
        var position = initialPosition;
        var size = _wheatPrefab.Size;
        var count = GetWheatCount();

        for (var x = 0; x < count.x; x++)
        {
            for (var z = 0; z < count.z; z++)
            {
                CreateWheat(position);
                position += new Vector3(size.x, 0, 0);
            }

            position.x = initialPosition.x;
            position += new Vector3(0, 0, size.z);
        }
    }

    private void CreateWheat(Vector3 position)
    {
        var wheat = Instantiate(_wheatPrefab, transform);
        wheat.transform.position = position;
        wheat.SetState(new GrowState(_growUpTime));
        wheat.Sliced += () => wheat.SetState(new GrowState(_growUpTime));
    }

    private Vector3Int GetWheatCount()
    {
        var wheatSize = _wheatPrefab.Size;
        return new Vector3Int(
            Mathf.FloorToInt(_fieldSize.x / wheatSize.x), 
            0, 
            Mathf.FloorToInt(_fieldSize.z / wheatSize.z));
    }

    private Vector3 GetLeftBottomPosition()
    {
        var fieldSize = new Vector3(_fieldSize.x, 0, _fieldSize.z);
        return transform.position - fieldSize / 2 + _wheatPrefab.Size / 2;
    }
}
