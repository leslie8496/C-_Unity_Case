namespace CSharpExercises.lecode;

public class SanShuZhiHe
{
    public void Run()
    {
    }

    /*给你一个整数数组 nums ，
     判断是否存在三元组 [nums[i], nums[j], nums[k]] 满足 i != j、i != k 且 j != k ，
     同时还满足 nums[i] + nums[j] + nums[k] == 0 。
     请你返回所有和为 0 且不重复的三元组。
       注意：答案中不可以包含重复的三元组。*/
    //排序加双指针
    //注意：CompareTo是一个比较器，a比较b得出的顺序应该是升序，反之就是降序
    //默认排序机制：如果是int那就是默认升序，如果是string那就是默认字母顺序,
    //所以其实下面那个可以省略成Array.Sort(num)就好了
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        List<IList<int>> data = new List<IList<int>>();
        if (nums == null || nums.Length <3) return data;

        Array.Sort(nums, (a, b) => a.CompareTo(b));
        int n = nums.Length;
        for (int i = 0; i < n - 2; i++)
        {
            if (nums[i] > 0) break; //因为已经升序了，然后再加上如果当前的数还是大于0的，那后面的数肯定就都大于0了
            if (i > 0 && nums[i] == nums[i - 1]) continue; //去重
            //双指针
            int L = i + 1;
            int R = n - 1;
            int targetVal = -nums[i];
            while (L < R)
            {
                int curVal = nums[L] + nums[R];
                if (curVal == targetVal)
                {
                    data.Add(new List<int> { nums[i], nums[L], nums[R] });
                    // 移动 L：跳过所有与当前 nums[L] 相同的元素
                    while (L < R && nums[L] == nums[L + 1])
                    {
                        L++; //L右移
                    }

                    // 移动 R：跳过所有与当前 nums[R] 相同的元素
                    while (L < R && nums[R] == nums[R - 1])
                    {
                        R--; //R左移
                    }

                    // 最终移动指针到下一个不同的元素
                    L++;
                    R--;
                }
                else if (curVal > targetVal) //数大了，r左移
                {
                    R--;
                }
                else if (curVal < targetVal) //数小了，l右移
                {
                    L++;
                }
            }
        }

        return data;
    }
}