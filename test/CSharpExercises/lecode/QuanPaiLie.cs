namespace CSharpExercises.lecode;

public class QuanPaiLie
{
    public void Run()
    {
        int[] nums = { 1, 2, 3};
        IList<IList<int>> list = Permute(nums);
        Console.WriteLine("\n--- 最终结果 ---");
        Console.WriteLine($"输出：{ListOfListsToString(list)}");
    }
    /*
     * 给定一个不含重复数字的整数数组 nums ，返回其 所有可能的全排列 。可以 按任意顺序 返回答案。
     * 示例 1：

       输入：nums = [1,2,3]
       输出：[[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]
       示例 2：

       输入：nums = [0,1]
       输出：[[0,1],[1,0]]
     */
    private List<IList<int>> newList = new List<IList<int>>();
    private bool[] used;

    public IList<IList<int>> Permute(int[] nums)
    {
        if (nums == null || nums.Length == 0) return newList;
        used = new bool[nums.Length];
        List<int> path = new List<int>();
        Backtrack(nums, path);
        return newList;
    }
    private int runCount = 0;
    private int forcount = 1;
    private void Backtrack(int[] nums,List<int> path)
    {
        runCount++;
        Console.WriteLine($"运行了Backtrack{runCount}次");
        if (nums.Length == path.Count)
        {
            newList.Add(new List<int>(path));
            Console.WriteLine($"==============又得一行======{ListToString(path)}==现在总队列是：{ListOfListsToString(newList)}");
            return;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (used[i]) continue;
            path.Add(nums[i]);
            Console.WriteLine($"======> 做出选择：加上元素 {nums[i]}，当前路径：{ListToString(path)},当前i是{i}");
            used[i] = true;
            Backtrack(nums, path);
            // 回溯操作的日志
            int removedItem = path[path.Count - 1];
            path.RemoveAt(path.Count - 1);
            used[i] = false;
            Console.WriteLine($"<====== 撤销选择：减去元素 {removedItem}，当前路径恢复为：{ListToString(path)},当前i是{i}");
        
        }
    }
    private string ListToString(IList<int> list)
    {
        // 使用 string.Join() 将列表元素用逗号和空格连接起来，并加上方括号
        return $"[{string.Join(", ", list)}]";
    }

    private string ListOfListsToString(IList<IList<int>> list)
    {
        // 格式化二维列表的输出
        var innerStrings = new List<string>();
        foreach (var innerList in list)
        {
            innerStrings.Add(ListToString(innerList));
        }
        return $"[{string.Join(", ", innerStrings)}]";
    }
}