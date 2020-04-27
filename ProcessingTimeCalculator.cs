using System;

public interface ICalculateProcessingTime
{
    void Preprocess();
    void ProcessMain();
}

public class ProcessingTimeCalculator
{
    private System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();

    public void Calculate(ICalculateProcessingTime _process)
    {
        _process.Preprocess();

        stopWatch.Start();
        _process.ProcessMain();
        stopWatch.Stop();
    }

    public static long Frequency()
    {
        return System.Diagnostics.Stopwatch.Frequency;
    }

    public TimeSpan Elapsed()
    {
        return stopWatch.Elapsed;
    }

    public long ElapsedMilliSeconds()
    {
        return stopWatch.ElapsedMilliseconds;
    }

    public void Reset()
    {
        stopWatch.Reset();
    }

}
