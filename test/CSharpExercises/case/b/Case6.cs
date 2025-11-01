class Case6
{
    /* 
    - interface、abstract class。
- 试题：写一个 `IShape` 接口，定义 GetArea()，然后让 Circle, Rectangle 实现它。
     */
    public void Run()
    {
        List<IShape> shapes = new List<IShape>();
        shapes.Add(new Circle(5));
        shapes.Add(new Rectangle(3, 4));
        foreach (var shape in shapes)
        {
            Console.WriteLine($"{shape.GetType().Name}的面积为{shape.GetArea()}");
        }

    }
}
interface IShape
{
    double GetArea();
};
public class Circle : IShape
{
    private int _r;
    private int R
    {
        get
        {
            return _r;
        }
        set
        {
            _r = value;
        }
    }
    public Circle(int r)
    {
        R = r;
    }
    double IShape.GetArea()
    {
        return Math.PI * R * R;
    }

}
public class Rectangle : IShape
{
    public int Width { get; }
    public int Height { get; }
    public Rectangle(int w, int h)
    {
        Width = w;
        Height = h;
    }
    public double GetArea()
    {
        return Width*Height;
    }
}