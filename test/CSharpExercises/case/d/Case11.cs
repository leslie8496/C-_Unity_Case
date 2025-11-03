class Case11
{
    /* 3. **Lambda 表达式**
    - (x)=>x*x 形式。
    - 试题：用 Lambda 实现一个 List 的平方转换。 */
    public void Run()
    {
        List<int> nums = new List<int>{ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        System.Console.WriteLine($"原始数据:{string.Join(',', nums)}");
        //进行转换
        List<int> bignums = nums.Select(num => num * num).ToList();
        System.Console.WriteLine($"转换完之后的数据:{string.Join(',',bignums)}");
    }
}