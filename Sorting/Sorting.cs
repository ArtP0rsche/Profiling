using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using ReyRom;

BenchmarkRunner.Run<Sorting>();

namespace ReyRom
{
    public class Sorting
    {
        public int[] Data { get; set; }
        [Params(0)]
        public int Left { get; set; }
        [Params(100)]
        public int Right { get; set; }

        [Benchmark]
        public void RunBubbleSort()
        {
            BubbleSort(Data);
        }

        [Benchmark]
        public void RunQuickSort()
        {
            QuickSort(Data, Left, Right);
        }

        public static void BubbleSort(int[] data)
        {
            for (int i = 0; i < data.Length - 1; i++)
            {
                for (int j = 0; j < data.Length - i - 1; j++)
                {
                    if (data[j] > data[j + 1])
                    {
                        int temp = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = temp;
                    }
                }
            }
        }

        public static void QuickSort(int[] data, int left, int right)
        {
            int i = left, j = right;
            int pivot = data[(left + right) / 2];
            while (i <= j)
            {
                while (data[i] < pivot) i++;
                while (data[j] > pivot) j--;
                if (i <= j)
                {
                    int tmp = data[i];
                    data[i] = data[j];
                    data[j] = tmp;
                    i++;
                    j--;
                }
            }
            if (left < j) QuickSort(data, left, j);
            if (i < right) QuickSort(data, i, right);
        }
    }
}
