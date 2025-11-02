class Case7
{
  /*  **List / Dictionary**
  - 创建 List<int>，添加/删除/遍历。
  - 创建 Dictionary<string,int>，存储学生姓名和分数。
  - 试题：输入一组分数，存进 List，计算平均分和最高分。 */
  public void Run()
  {
    Demo3();
  }
  public void Demo3()
  {
    System.Console.WriteLine("开始输入各位分数 \n");
    List<int> nums = new List<int>();
    int count = 1;
    while (true)
    {
      System.Console.WriteLine($"请输入第{count}个分数");
      string inputNum = Console.ReadLine();
      if (int.TryParse(inputNum, out int score))
      {
        if (score < 0)
        {
          break;
        }
        nums.Add(score);
        count++;
        System.Console.WriteLine("添加成功");
      }
      else
      {
        System.Console.WriteLine($"{inputNum}不是数字");
      }
    }
    double avaCount = nums.Average();
    System.Console.WriteLine($"当前成绩总数为{nums.Sum()},平均分为{avaCount:F2},最高分为{nums.Max()}");
  }

  public void Demo2()
  {
    System.Console.WriteLine("用Dictionary<string,int>，存储学生姓名和分数 \n");
    Dictionary<string, double> data = new Dictionary<string, double>();
    //添加
    System.Console.WriteLine("现在去添加几个学生对应的分数");
    data.Add("lili", 99);
    data.Add("mingming", 98.5);
    data.Add("tiantian", 97);
    data.Add("xiaoxiao", 97.5);
    data.Add("didi", 98);
    data["nana"] = 100;
    System.Console.WriteLine($"添加了{data.Count}个学生分数,平均分是{data.Values.Average()}");
    System.Console.WriteLine($"最高分是{data.Values.Max()} \n");
    //遍历
    System.Console.WriteLine("现在点名成绩");
    foreach (KeyValuePair<string, double> item in data)
    {
      System.Console.WriteLine($"{item.Key},{item.Value}分{(item.Value == data.Values.Max() ? "是最高分" : "")}");
    }
    System.Console.WriteLine($"\n 分别点名");
    foreach (string name in data.Keys)
    {
      System.Console.WriteLine($"{name}");
      System.Console.WriteLine($"到!");
    }
  }
  public void Demo1()
  {
    Console.WriteLine("====List<int>====演示");
    List<int> nums = new List<int>();
    //添加元素
    Console.WriteLine("自动添加元素");
    nums.Add(10);
    nums.Add(20);
    nums.Add(30);
    nums.Add(40);
    nums.Add(50);
    //遍历
    Console.WriteLine("\n 使用foreach遍历");
    foreach (int num in nums)
    {
      Console.WriteLine($"List元素:{num}");
    }
    Console.WriteLine("\n 使用for遍历");
    for (int i = 0; i < nums.Count; i++)
    {
      Console.WriteLine($"索引为{i}的List元素为:{nums[i]}");
    }
    //删除两个元素
    Console.WriteLine("把40删掉");
    nums.Remove(30);
    Console.WriteLine("把索引为2的删掉");
    nums.RemoveAt(2);
    //删除后遍历
    Console.WriteLine("删除之后的列表");
    foreach (int num in nums)
    {
      Console.WriteLine($"{num}到！");
    }
    // 其他
    Console.WriteLine($"20还在不在列表里:{nums.Contains(20)}");
    Console.WriteLine($"还有多少兵？{nums.Count}个");
    Console.WriteLine($"ok 我要全部清掉");
    nums.Clear();
    Console.WriteLine($"还有多少兵？{nums.Count}个");

  }
}