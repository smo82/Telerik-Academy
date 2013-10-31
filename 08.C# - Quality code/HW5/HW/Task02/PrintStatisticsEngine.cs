using System;

class PrintStatisticsEngine
{
    static void Main(string[] args)
    {
        double[] testDoubleArray = new double[] { 1, 2, 3, 4, 5, 6};

        Report testReport = new Report();
        testReport.PrintStatistics(testDoubleArray, testDoubleArray.Length);
    }
}