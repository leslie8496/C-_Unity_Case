class Case8
{
    /* 2. **LINQ**
    - 用 LINQ 查询 List 中大于某个值的元素。
    - 试题：有一个 List<Student>，找出分数 >= 80 的学生并按分数降序排列。 */
    public void Run()
    {
        Demo2();
    }

    private void Demo2()
    {
        List<Student> data =
        [
            new Student("lili", 89.5),
            new Student("nana", 90),
            new Student("mingming", 78),
            new Student("tiantian", 80),
            new Student("xixi", 95),
            new Student("dada", 77),
        ];
        System.Console.WriteLine($"学生开始点名 \n");
        foreach (Student stu in data)
        {
            System.Console.WriteLine(stu);
        }
        var highStu = data.Where(stu => stu.Score >= 80).OrderBy(stu => stu.Score);
        System.Console.WriteLine($"\n分数大于80的有哪些人\n");
        foreach(var stu in highStu)
        {
            System.Console.WriteLine(stu);
        }
    }
    private void Demo1()
    {
        System.Console.WriteLine($"输入对应分数\n");
        List<double> nums = new List<double>();
        int count = 0;
        while (true)
        {
            string inputData = Console.ReadLine();
            if (double.TryParse(inputData, out double score))
            {
                if (score <= 0)
                {
                    System.Console.WriteLine("input score is done～");
                    break;
                }
                nums.Add(score);
                count++;
                System.Console.WriteLine($"添加成功{count}个分数");
            }
            else
            {
                System.Console.WriteLine($"{inputData} is not a double number");
            }
        }
        var highScore = nums.Where(score => score >= 80).OrderByDescending(score => score);
        System.Console.WriteLine($"\n 大于80分的分数有:{highScore.Count()} \n");
        foreach (double score in highScore)
        {
            System.Console.WriteLine($"{score}分");
        }
    }
}
class Student
{
    public string Name { get; set; }
    public double Score { get; set; }
    public override string ToString()
    {
        return $"{Name}的分数是:{Score}";
    }
    public Student(string name, double score)
    {
        Name = name;
        Score = score;
    }
}