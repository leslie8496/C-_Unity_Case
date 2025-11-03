class Work1
{
    /* 1. **猜数字小游戏**
    - 系统随机生成 1~100，玩家输入数字，提示大/小/正确。 */
    public void Run()
    {
        int randomCount = new Random().Next(1, 101);
        string input;
        int count = 0;
        System.Console.WriteLine("现在开始我们的数字财迷游戏，请输入你心里所想的数字");
        while (true)
        {
            input = Console.ReadLine();
            if (int.TryParse(input, out int val))
            {
                count++;
                if (val == randomCount)
                {
                    System.Console.WriteLine($"恭喜你回答正确！你的有效回答次数是{count}次,表现为{(count <= 5 ? "优秀" : "一般")}");
                    break;
                }
                else
                {
                    System.Console.WriteLine($"不是{val}哦,目标数字比较{(randomCount>val?"大":"小")}，请继续输入");
                }
            }
            else
            {
                System.Console.WriteLine("请输入数字哦");
            }
        }
    }
}