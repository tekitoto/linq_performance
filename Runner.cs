using UnityEngine;
using System.Collections.Generic;
using System;
using System.Threading;

public class Runner : MonoBehaviour
{
    List<Tuple<int, int>> sizeAndTimes = new List<Tuple<int, int>>()
    {
        new Tuple<int, int>(10, 10000),
        new Tuple<int, int>(100, 10000),
        new Tuple<int, int>(1000, 1000),
    };

    public class TestAll
    {
        private Dictionary<string, ICalculateProcessingTime> dic = new Dictionary<string, ICalculateProcessingTime>();

        private int times = 0;

        public TestAll(int _dataSize, int _times)
        {
            times = _times;

            dic.Add(nameof(WhereSelectByLinq), new WhereSelectByLinq(_dataSize));
            dic.Add(nameof(WhereSelectByForeach), new WhereSelectByForeach(_dataSize));
            dic.Add(nameof(WhereSelectByForLoop), new WhereSelectByForLoop(_dataSize));
            dic.Add(nameof(OrderByLinq), new OrderByLinq(_dataSize, 8, 8));
            dic.Add(nameof(OrderBySort), new OrderBySort(_dataSize, 8, 8));
        }

        public Dictionary<string, double> Run()
        {
            var results = new Dictionary<string, double>();
            var calculator = new ProcessingTimeCalculator();

            foreach (var target in dic)
            {
                calculator.Reset();

                // 初回は重たくなりがちなので，一回空実行してもよいかも
                // target.Value.ProcessMain();

                for (int i = 0; i < times; ++i)
                {
                    calculator.Calculate(target.Value);
                }

                results[target.Key] = calculator.Elapsed().TotalMilliseconds;
            }

            return results;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"Frequency = {ProcessingTimeCalculator.Frequency()}");

        foreach ((int size, int times) in sizeAndTimes)
        {
            string output = $"name\ttotal_ms\tavg_ms\t#size = {size}, times = {times}\n";

            var runAll = new TestAll(size, times);
            var results = runAll.Run();

            foreach (var result in results)
            {
                output += $"{result.Key}\t{result.Value}\t{result.Value / times}\n";
            }

            Debug.Log(output);
        }
    }

}
