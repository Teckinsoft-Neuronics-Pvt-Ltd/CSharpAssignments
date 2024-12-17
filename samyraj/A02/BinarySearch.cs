
namespace A02
{
    internal static class BinarySearch
    {
        static int min = 1, max = 100, noofGuess = default(int);
        static bool isSuccess = default(bool);
        internal static int Search(int target)
        {
            while (!isSuccess) {
                int mid = MiddleNumber(min, max);
                if (target == mid) isSuccess = true;
                else if(target < mid)
                {
                    max = mid;
                }
                else if(target > mid)
                {
                    min = mid;
                }
                noofGuess++;
            }
            return noofGuess;
        }
        static int MiddleNumber(int num1,int num2) => (num1 + num2) / 2;
    }
}
