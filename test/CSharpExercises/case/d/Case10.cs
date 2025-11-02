class Case10
{
    /* 
    2. **事件 event**
    - 定义事件，订阅和触发。
    - 试题：写一个 `Player` 类，HP 减少到 0 时触发 `OnDeath` 事件。
     */
    public void Run()
    {
        Player mainPlayer = new Player("主角小美", 100);
        //订阅事件
        mainPlayer.onDeath += p =>
        {
            System.Console.WriteLine("========GAMEOVERE=======");
            System.Console.WriteLine($"玩家{mainPlayer.Name}血量为{mainPlayer.hp},嗝屁了");
        };
        System.Console.WriteLine("伤害小连招");
        List<int> harmData = new List<int>();
        harmData.Add(50);
        harmData.Add(30);
        harmData.Add(40);
        foreach(int harmVal in harmData)
        {
            System.Console.WriteLine($"对玩家{mainPlayer.Name}造成{harmVal}伤害");
            mainPlayer.onHurt(harmVal);
            System.Console.WriteLine($"玩家剩余血量为{mainPlayer.hp}");
        }
    }

}
class Player
{
    public string Name { get; set; }
    public int hp { get; private set; }
    public event Action<Player> onDeath;
    public Player(string name, int allHp)
    {
        Name = name;
        hp = allHp;
    }
    public void onHurt(int harmVal)
    {
        if (hp <= 0) {
            System.Console.WriteLine("禁止鞭尸");
            return;
        }
        hp -= harmVal;
        if (hp <= 0)
        {
            hp = 0;
            onDeath?.Invoke(this);// 触发事件
        }
    }
}