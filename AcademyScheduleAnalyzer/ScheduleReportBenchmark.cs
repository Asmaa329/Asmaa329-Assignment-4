using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyScheduleAnalyzer
{
    [MemoryDiagnoser]
    [ShortRunJob]
    public class ScheduleReportBenchmark
    {
        [Params(100, 1000, 10000, 100000)]
        public int Iterations;

        private const string SampleText = "C# Basics - 10/09/2026 06:00 PM - 180 minutes\n";

        [Benchmark]
        public string StringConcatenation()
        {
            string result = "";
            int limit = Iterations > 10000 ? 10000 : Iterations; 
            for (int i = 0; i < limit; i++)
            {
                result += SampleText;
            }
            return result;
        }

        [Benchmark]
        public string StringBuilderConcatenation()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Iterations; i++)
            {
                sb.Append(SampleText);
            }
            return sb.ToString();
        }
    }
}
