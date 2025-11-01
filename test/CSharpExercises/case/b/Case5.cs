class Case5
{
    /* 2. **继承与多态**
    - virtual、override、new。
    - 试题：定义一个 `Animal` 基类，Dog 和 Cat 继承并重写 `Speak()` 方法。 */
    public void Run()
    {
        Dog dog = new Dog("队长", "汪汪");
        dog.Speck();
        Miao miao = new Miao("黄金毛", "喵呜");
        miao.Speck();
        RobotDog robotDog = new RobotDog("机械狗", "呜哇");
        robotDog.Speck();
        Dog rdAsDog = robotDog;
        rdAsDog.Speck();
    }
}
class Animal
{
    private string _name;
    public string Name
    {
        get { return _name; }
        set
        {
            // if (string.IsNullOrEmpty(_name))
            // {
            //     throw new ArgumentException("名字不能为空");
            // }
            _name = value;
        }
    }
    private string SpeakStr;
    protected string _hint;
    public Animal(string name, string speak)
    {
        Name = name;
        SpeakStr = speak;
    }
    public virtual void Speck()
    {
        Console.WriteLine($"听，有声音在{SpeakStr},是{Name}!");
        setHint();
        Console.WriteLine($"提示{_hint}");
    }
    protected virtual void setHint()
    {
        _hint = "";
    }
}
class Dog : Animal
{
    public Dog(string name, string speak) : base(name, speak)
    {
        
    }
    override protected void setHint()
    {
        _hint = "dog是人类最好的朋友,是修勾啊";
    }
}
class Miao : Animal
{
    public Miao(string name, string speak) : base(name, speak) { }
    override protected void setHint()
    {
        _hint = "是哈基米，我们有救了!";
    }
}
class RobotDog : Dog
{
    public RobotDog(string name, string speak) : base(name, speak)
    {
    }
    public new void Speck()
    {
        Console.WriteLine("呜哇汤 呜哇汤");
    }
    protected new void setHint()
    {
        _hint = "机械修勾";
    }
}