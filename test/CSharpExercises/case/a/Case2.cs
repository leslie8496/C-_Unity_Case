class Case2
{
    /* 
    2. **流程控制**
    - if/else, switch 的写法。
    - for, while, do-while, foreach。
    - 试题：写九九乘法表（用 for 和 foreach 各实现一次）。
     */
    private const int maxCount = 9;
    private const int minCount = 1;
    private List<int> nums = new List<int>();//List<T>是可以动态扩展元素的，但是数组T[]是固定长度的，定义之后就不能被扩展了
    public void Run()
    {
        nums = new List<int>();
        chengFaBiaoFunc();
        chengFaBiaoFunc1();
    }

    private void chengFaBiaoFunc()
    {
        Console.WriteLine("chengFaBiaoFunc_____________for");
        for (int i = minCount; i <= maxCount; i++)
        {
            nums.Add(i);
            for (int j = minCount; j <= i; j++)
            {
                Console.Write($"{j}*{i}={i * j,-2} ");//,2是一个格式说明符，表示这个{}里面的输出最少是两个字符宽度，不足的话就会在前面补空格，如果是-2的话就是在后面补空格
            }
            Console.WriteLine("");
        }
    }
    private void chengFaBiaoFunc1()
    {
        Console.WriteLine("chengFaBiaoFunc1____________foreach");
        foreach (int i in nums)
        {
            foreach (int j in nums)
            {
                if (j > i) break;
                Console.Write($"{j}*{i}={j * i,-2} ");
            }
            Console.WriteLine();
        }
    }
}