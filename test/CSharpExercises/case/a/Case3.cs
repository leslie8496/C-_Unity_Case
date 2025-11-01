class Case3
{
    /* 3. **方法**
    - 定义、重载方法。
    - 参数传递方式：值传递、ref、out。
    - 试题：写一个函数，输入整数 n，返回 1+2+...+n。 */
    public void Run(int x)
    {
        int sum;
        calcSum(x, out sum);
        Console.WriteLine($"{x}的累加和是{sum}");
    }
    private void calcSum(int x, out int sum)
    {
        sum = 0;
        for (int i = 0; i < x; i++)
        {
            sum += i;
        }
    }
}