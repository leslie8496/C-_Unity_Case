using System;
using System.Collections.Generic;

class Program
{
    public static Dictionary<string, Action<int>> registData = new Dictionary<string, Action<int>>
        {
            {"case1",(d)=>{
                if(d==0)return;
                new Case1().Run(d);
                }},
            {"case3",(d)=>{
                if(d==0)return;
                new Case3().Run(d);
                }},
            {"case2",d=> new Case2().Run()},
            {"case4",d=> new Case4().Run()},
            {"case5",d=> new Case5().Run()},
            {"case6",d=> new Case6().Run()},
            {"case7",d=> new Case7().Run()},
            {"case8",d=> new Case8().Run()},
            {"case9",d=> new Case9().Run()},
            {"case10",d=> new Case10().Run()},
            {"case11",d=> new Case11().Run()},
            {"case12",d=> new Case12().Run()},
            {"work1",d=> new Work1().Run()},
            {"work2",d=> new Work2().Run()},
        };
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("请输入要运行的 case，例如：dotnet run -- case1");
            return;
        }

        int d = getArgsParam(args);
        string typeName = args[0].ToLower();
        if(registData.TryGetValue(typeName,out Action<int> runFunc))
        {
            runFunc(d);
        }
        
    }

    private static int getArgsParam(string[] args)
    {
        if (args.Length < 2) // 改为 < 2 更健壮
        {
            return 0;
        }
        int.TryParse(args[1], out var d);
        return d;
    }
}