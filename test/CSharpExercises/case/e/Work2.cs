class Work2
{
    /* 2. **学生成绩管理**
    - 使用 List<Student> 保存数据，可以：添加学生、显示全部、查询最高分。 */
    public void Run()
    {
        List<Stu> students = new List<Stu>
        {
            new Stu("xiaoxiao",85),
            new Stu("wawa",98),
            new Stu("lili",78),
            new Stu("eiei",60),
        };
        students.Add(new Stu("aby", 100));
        students.Select(s =>
        {
            System.Console.WriteLine(s);
            return s;
        });
    
        
    }
}
class Stu
{
    public string Name { get; set; }
    public double Score { get;private set; }
    public Stu(string name, double score)
    {
        Name = name;
        Score = score;
    }
    public override string ToString()
    {
        return $"{Name}同学的成绩是{Score}，{(Score>=85?"还可以，再接再厉":"加油努力，相信自己")}";
    }
}