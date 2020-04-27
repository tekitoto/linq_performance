using System.Collections.Generic;
using System.Linq;

public static class Extensions
{
    public static void Shuffle<T>(this IList<T> _list)
    {
        for (int i = _list.Count - 1; i > 0; --i)
        {
            int j = UnityEngine.Random.Range(0, i + 1);
            var temp = _list[i];
            _list[i] = _list[j];
            _list[j] = temp;
        }
    }
}

public static class OrderByUtil
{
    public static List<DataClass> RandomDataSet(int _dataSize, int _valueLength, int _maxId)
    {
        return Enumerable.Range(0, _dataSize).Select(_ => new DataClass(UnityEngine.Random.Range(0, _maxId), RandomValue(_valueLength))).ToList();
    }

    public static string RandomValue(int _length)
    {
        return System.Guid.NewGuid().ToString("N").Substring(0, _length);
    }
}

public class OrderByLinq : ICalculateProcessingTime
{
    private List<DataClass> data = null;
    private int dataSize;
    private int valueLength;
    private int maxId;

    public OrderByLinq(int _dataSize, int _valueLength, int _maxId)
    {
        dataSize = _dataSize;
        valueLength = _valueLength;
        maxId = _maxId;
    }

    public void Preprocess()
    {
        data = OrderByUtil.RandomDataSet(dataSize, valueLength, maxId);
    }

    public void ProcessMain()
    {
        var sorted = data.OrderBy(_x => _x.Id).ThenBy(_x => _x.Value).ToList();
    }
}

public class OrderBySort : ICalculateProcessingTime
{
    private List<DataClass> data = null;
    private int dataSize;
    private int valueLength;
    private int maxId;

    public OrderBySort(int _dataSize, int _valueLength, int _maxId)
    {
        dataSize = _dataSize;
        valueLength = _valueLength;
        maxId = _maxId;
    }

    public void Preprocess()
    {
        data = OrderByUtil.RandomDataSet(dataSize, valueLength, maxId);
    }

    public void ProcessMain()
    {
        data.Sort((_x, _y) =>
        {
            if (_x.Id == _y.Id)
            {
                return string.Compare(_x.Value, _y.Value);
            }

            return _y.Id - _x.Id;
        });
    }
}