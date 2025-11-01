class Case4
{
    /* 
     **类与对象**
    - 定义类、构造函数、属性（get/set）。
    - 试题：写一个 `Person` 类，包含 Name, Age，写一个方法 `Introduce()` 打印一句话。 */
    public void Run()
    {
        Person person = new Person("leslie", 18);
        person.Introduce();
    }
};
public class Person
{
    private string _name;
    public string Name
    {
        get { return _name; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("名字不能为空");
            }
            _name = value;
        }
    }
    int Age;
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
    public void Introduce()
    {
        Console.WriteLine($"这人的年龄是{Age}，叫做{Name}");
    }
}