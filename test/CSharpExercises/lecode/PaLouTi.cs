namespace CSharpExercises.lecode;

public class PaLouTi
{
    public void Run()
    {
    }

    /*假设你正在爬楼梯。需要 n 阶你才能到达楼顶。
       每次你可以爬 1 或 2 个台阶。你有多少种不同的方法可以爬到楼顶呢？
       示例 1：

       输入：n = 2
       输出：2
       解释：有两种方法可以爬到楼顶。
       1. 1 阶 + 1 阶
       2. 2 阶
       示例 2：

       输入：n = 3
       输出：3
       解释：有三种方法可以爬到楼顶。
       1. 1 阶 + 1 阶 + 1 阶
       2. 1 阶 + 2 阶
       3. 2 阶 + 1 阶
    */
    public int ClimbStairs(int n)
    {
        if (n == 1) return 1;
        if (n == 2) return 2;
        //F(i) = F(i-1) + F(i-2)
        int preV2 = 1;
        int preV1 = 2;
        int current = 0;
        for (int i = 3; i <= n; i++)
        {
            current = preV2 + preV1;
            preV2 = preV1;
            preV1 = current;
        }

        return current;
    }
}