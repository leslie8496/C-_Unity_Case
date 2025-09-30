class Case1
{
    
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