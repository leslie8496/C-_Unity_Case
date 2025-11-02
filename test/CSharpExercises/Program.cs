using System;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("请输入要运行的 case，例如：dotnet run -- case1");
            return;
        }
        int d = getArgsParam(args);
        switch (args[0].ToLower())
        {
            case "case1":
                if (d == 0)
                {
                    return;
                }
                new Case1().Run(d);
                break;
            case "case2":
                new Case2().Run();
                break;
            case "case3":
                if (d == 0)
                {
                    return;
                }
                new Case3().Run(d);
                break;
            case "case4":
                new Case4().Run();
                break;
            case "case5":
                new Case5().Run();
                break;
            case "case6":
                new Case6().Run();
                break;
            case "case7":
                new Case7().Run();
                break;
            default:
                Console.WriteLine($"未找到 {args[0]} 对应的test");
                break;
        }
    }
    private static int getArgsParam(string[] args)
    {
        if (args.Length == 1)
        {
            return 0;
        }
        int.TryParse(args[1], out var d);
        return d;
    }
}
