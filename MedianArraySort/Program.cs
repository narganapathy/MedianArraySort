using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedianArraySort
{
    class Program
    {
        public class Solution
        {
            public double FindMedianSortedArrays(int[] nums1, int[] nums2)
            {
                double median1 = GetMedian(nums1);
                double median2 = GetMedian(nums2);
                double avgMedian = (median1 + median2) / 2;
                do
                {
                    int index1 = GetIndexForMedian(nums1, avgMedian);
                    int index2 = GetIndexForMedian(nums2, avgMedian);

                    int numOnLeftOfMedian = index1 + index2;
                    int numOnRightOfMedian = (nums1.Length - index1) + (nums2.Length - index2);
                    if (Math.Abs(numOnRightOfMedian - numOnLeftOfMedian) <= 1)
                    {
                        // found the median
                        return avgMedian;
                    }
                    else
                    {
                        // shift to left or right depending on which has more elements
                        if (numOnLeftOfMedian > numOnRightOfMedian)
                        {
                            avgMedian = (avgMedian + median1) / 2;
                        }
                        else
                        {
                            avgMedian = (avgMedian + median2) / 2;
                        }
                    }
                } while (true) ;
            }

            int GetIndexForMedian(int[] nums, double medianVal)
            {
                int index = nums.Length / 2;
                if (medianVal > nums[nums.Length - 1]) return nums.Length;
                if (medianVal < nums[0]) return 0;

                while (true)
                {
                    if (nums[index] > medianVal)
                    {
                        index = index / 2;
                    }
                    else
                    {
                        index = (index + nums.Length) / 2;
                    }
                }
            }

            double GetMedian(int[] nums)
            {
                int medianIndex = nums.Length / 2;
                if ((nums.Length % 2) == 0)
                {
                    return ((double)nums[medianIndex - 1] + (double)nums[medianIndex]) / 2;
                }
                else
                {
                    return ((double)nums[medianIndex]);
                }
            }
}

        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] a1 = new int[] { 1, 2, 3 };
            int[] a2 = new int[] { 5, 6, 7 };
            Console.WriteLine("Median is {0}", solution.FindMedianSortedArrays(a1, a2));
        }
    }
}
