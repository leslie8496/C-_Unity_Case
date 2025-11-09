/*一些通用的LINQ方法集*/
// 示例数据模型
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string City { get; set; }
    public List<string> Skills { get; set; }
}
public class Work3
{
    private List<Person> people = new List<Person>
    {
        new Person { Name = "张甲", Age = 30, City = "云南", Skills = new List<string> { "C#", "SQL" } },
        new Person { Name = "赵乙", Age = 25, City = "广东", Skills = new List<string> { "Java", "Python" } },
        new Person { Name = "李丙", Age = 30, City = "四川", Skills = new List<string> { "C#" } },
        new Person { Name = "丁丁", Age = 45, City = "广东", Skills = new List<string> { "React", "Node" } }
    };
    // --- 示例方法 ---
    public void Run()
    {
        // Console.WriteLine("--- A. 筛选 (Filtering) ---");
        // Example_Where();
        // Example_OfType();
        // Console.WriteLine("\n--- B. 排序 (Ordering) ---");
        // Example_OrderBy();
        // Example_ThenBy();
        //
        // Console.WriteLine("\n--- C. 投影/转换 (Projection) ---");
        // Example_Select();
        // Example_SelectMany();
        //
        // Console.WriteLine("\n--- D. 聚合/计数 (Aggregation) ---");
        // Example_Count();
        // Example_SumAndAverage();
        // Example_MinAndMax();
        //
        Console.WriteLine("\n--- E. 分组 (Grouping) ---");
        Example_GroupBy();
    }

    public void Example_GroupBy()
    {
        // 按城市 (City) 分组
        var group = people.GroupBy(ietm => ietm.City);
        Console.WriteLine("GroupBy City:");
        foreach (var item in group)
        {
            Console.WriteLine($"  City: {item.Key} (Count: {item.Count()})");
            foreach (var person in item)
            {
                Console.WriteLine($"      -{person.Name}");
            }
        }
    }
    
    public void Example_Count()
    {
        // 统计总共有多少人
        int allNum = people.Count;
        // 统计有多少人住在 广东
        int inGdCount = people.Count(item => item.City == "广东");
        Console.WriteLine($"Total People:{allNum}=====People in GD:{inGdCount}");
    }

    public void Example_SumAndAverage()
    {
        // 计算所有人的年龄总和
        int sum = people.Sum(item => item.Age);
        // 计算平均年龄
        double avaAge = people.Average(item => item.Age);
        Console.WriteLine($"Sum of Ages:{sum}======Average Age{avaAge}");
    }

    public void Example_MinAndMax()
    {
        // 找到最年轻的年龄
        int minAge = people.Min(item => item.Age);
        
        // 找到年龄最大的 Person (需要先获取年龄，再使用 Where 查找)
        var oldestPerson = people.OrderByDescending(item => item.Age).FirstOrDefault()?.Name;
        Console.WriteLine($"Minimum Age:{minAge}=======Oldest Person:{oldestPerson}");
    }
    public void Example_Select()
    {
        // 将 Person 对象转换为一个匿名类型，只包含 Name 和 City
        var result = people.Select(item => new { item.Name, Location = item.City });
        Console.WriteLine($"Select (Name & City):{string.Join(',', result)}");
    }

    public void Example_SelectMany()
    {
        // 将 List<Person> 转换成一个 List<string> (所有人的所有技能)
        //focus:Distinct是去重的
        var result = people.SelectMany(item => item.Skills).Distinct();
        Console.WriteLine($"SelectMany (All Skills):{string.Join(',', result)}");
    }
    public void Example_OrderBy()
    {
        // 按年龄升序排序
        var ages = people.OrderBy(item => item.Age).Select(item => item.Age);
        Console.WriteLine($"OrderBy Age:{string.Join(",",ages)}");
        //降序就是把OrderBy换成OrderByDescending，自行想象
    }

    public void Example_ThenBy()
    {
        // 1. 先按年龄升序排序 (Age)
        // 2. 如果年龄相同，再按名字升序排序 (Name)
        var agesSort = people.OrderBy(item => item.Age)
            .ThenBy(item => item.Name)
            .Select(item => $"{item.Name}:{item.Age}");
        Console.WriteLine($"OrderBy Age, ThenBy Name:{string.Join(",",agesSort)}");
    }
    

    private void Example_Where()
    {
        // 筛选出所有年龄大于 28 岁的 Person
        var result = people.Where(item => item.Age > 28);
        Console.WriteLine($"Where (Age > 28):{string.Join(',',result.Select(item=>item.Name))}");
    }

    private void Example_OfType()
    {
        List<object> data = new List<object>{1,"nihao",2,"shijie"};
        //筛选出列表中的所有 string
        var result = data.OfType<string>();
        Console.WriteLine($"OfType<string>:{string.Join(',',result)}");
    }
}