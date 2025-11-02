class Case9
{
    /* 
    1. **委托 delegate**
    - 定义一个委托，指向不同的方法。
    - 试题：写一个委托 `MathOp`，分别实现加法和乘法。
     */
    public delegate double MathOp(double a, double b);
    public void Run()
    {
        MathOp onAdd = Add;
        MathOp onMuti = Muti;
        double a = 2.5;
        int b = 10;
        System.Console.WriteLine("使用委托调用方法");
        System.Console.WriteLine($"{a}+{b}={WeiTuoOp(a, b, onAdd)}");
        System.Console.WriteLine($"{a}*{b}={WeiTuoOp(a, b, onMuti)}");

        System.Console.WriteLine("\n 匿名方法创建委托");
        MathOp onSub = delegate (double a, double b) { return a - b; };
        System.Console.WriteLine($"{a}-{b}={WeiTuoOp(a, b, onSub)}");

        System.Console.WriteLine("\n 箭头函数创建委托");
        MathOp onChu = (a, b) => b != 0 ? a / b : 0;
        System.Console.WriteLine($"{a}/{b}={onChu(a, b)}");

    }
    public double WeiTuoOp(double arg1, double arg2, MathOp op)
    {
        return op(arg1, arg2);
    }
    private double Add(double a, double b)
    {
        return a + b;
    }
    private double Muti(double a, double b)
    {
        return a * b;
    }
}