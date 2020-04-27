using System.Collections.Generic;
using System.Linq;


public class WhereSelectByLinq : ICalculateProcessingTime
{
    private List<DataClass> data = null;

    public WhereSelectByLinq(int _dataSize)
    {
        data = Enumerable.Range(0, _dataSize).Select(_x => new DataClass(_x, _x.ToString())).ToList();
    }


    public void Preprocess()
    {
    }

    public void ProcessMain()
    {
        var temp = data.Where(_x => _x.Id % 5 == 0).Select(_x => _x.Value).ToList();
    }
}

public class WhereSelectByForeach : ICalculateProcessingTime
{
    private List<DataClass> data = null;

    public WhereSelectByForeach(int _dataSize)
    {
        data = Enumerable.Range(0, _dataSize).Select(_x => new DataClass(_x, _x.ToString())).ToList();
    }
    public void Preprocess()
    {
    }

    public void ProcessMain()
    {
        var temp = new List<string>();
        foreach (var x in data)
        {
            if (x.Id % 5 == 0)
            {
                temp.Add(x.Value);
            }
        }
    }
}

public class WhereSelectByForLoop : ICalculateProcessingTime
{
    private List<DataClass> data = null;

    public WhereSelectByForLoop(int _dataSize)
    {
        data = Enumerable.Range(0, _dataSize).Select(_x => new DataClass(_x, _x.ToString())).ToList();
    }
    public void Preprocess()
    {
    }

    public void ProcessMain()
    {
        var temp = new List<string>();
        for (int i = 0; i < data.Count(); ++i)
        {
            if (data[i].Id % 5 == 0)
            {
                temp.Add(data[i].Value);
            }
        }
    }
}