class Case3
{
    public void Run(int x)
    {
        int sum;
        calcSum(x, out sum);
        Console.WriteLine($"{x}的累加和是{sum}");
    }
    private void calcSum(int x, out int sum)
    {
        sum = 0;
        for (int i = 0; i < x; i++)
        {
            sum += i;
        }
    }
}