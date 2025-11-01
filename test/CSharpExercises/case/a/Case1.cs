class Case1
{
    /*  
        1. **变量与常量**
    - 定义不同类型的变量（int、double、string、bool、char）。
    - 定义 const 和 readonly 的区别。
    - 试题：写一个程序，声明一个圆的半径常量，计算面积。
    */
    public void Run(int num)
    {
        double count = calcCircle(num);

        Console.WriteLine($"圆半径为{num}的面积大约为{count}");
    }
    private double calcCircle(int num)
    {
        double area = Math.PI * num * num;
        area = Math.Round(area, 2);
        return area;
    }
}