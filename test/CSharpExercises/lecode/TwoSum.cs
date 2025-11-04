class TwoSum
{
    /* 给定一个整数数组 nums 和一个整数目标值 target，请你在该数组中找出 和为目标值 target  的那 两个 整数，并返回它们的数组下标。

你可以假设每种输入只会对应一个答案，并且你不能使用两次相同的元素。

你可以按任意顺序返回答案。 */
    public void Run()
    {
        System.Console.WriteLine("输入一些整数,用英文逗号隔开");
        string writeData = Console.ReadLine();
        bool isHaveFalse = false;
        int[] numsAr = writeData.Split(',').Select(w =>
        {
            if (int.TryParse(w, out int newW))
            {
                return newW;
            }
            else
            {
                isHaveFalse = true;
                return 0;
            }

        }).ToArray();
        if (isHaveFalse || numsAr.Length < 2)
        {
            System.Console.WriteLine("需要纯数字整数数组，输入失败");
            return;
        }
        
        System.Console.WriteLine("再输入目标值");
        string inputTarget = Console.ReadLine();
        bool isFind = false;
        if(int.TryParse(inputTarget,out int targetNum))
        {
            Dictionary<int, int> saveDicData = new Dictionary<int, int>();
            for(int i = 0; i < numsAr.Length; i++)
            {
                int findCount = targetNum - numsAr[i];
                if(saveDicData.TryGetValue(findCount,out int findInd))
                {
                    System.Console.WriteLine($"找到咯，对应下标是{findInd}和{i}");
                    isFind = true;
                    break;
                }
                else
                {
                    saveDicData[numsAr[i]] = i;
                }
            }
        }
        else
        {
            System.Console.WriteLine("需要纯数字整数目标值，输入失败");
            
        }
    }

}