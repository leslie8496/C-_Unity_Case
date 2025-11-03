class Case12
{
    /* 1. try/catch/finally 的用法。
2. 试题：写一个除法函数，捕获除数为 0 的异常，提示“不能除以零”。 */
    public void Run()
    {
        System.Console.WriteLine($"=========开始执行10除以5,结果为{CalcChuFa(10, 5)}====");
        System.Console.WriteLine($"=========开始执行1除以3,结果为{CalcChuFa(1, 3):F2}====");
        System.Console.WriteLine($"=========开始执行7除以0,结果为{CalcChuFa(7, 0)}====");
    }
    public double CalcChuFa(int a, int b)
    {
        int val = 0;
        System.Console.WriteLine($"开始执行{a}除以{b}");
        try
        {
            val = a / b;
            System.Console.WriteLine($"除法执行成功");
        }
        catch (DivideByZeroException e)
        {

            System.Console.WriteLine($"除法执行错误:{e.Data}");
        }
        finally
        {
            System.Console.WriteLine("除法算术执行完成～～");
        }
        return val;
    }
}