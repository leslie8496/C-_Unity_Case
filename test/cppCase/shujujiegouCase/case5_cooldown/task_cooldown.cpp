#include <iostream>
#include <string>
#include <queue>      // 优先队列在这里
#include <vector>     // priority_queue 底层通常依赖 vector
#include <functional> // 为了使用 std::greater
using namespace std;
struct SkillCooldown
{
    string skillName;
    double readyTime;
    // 你说的重载也就是>大于符号，这里面的用法是什么意思？你需要详细的逐一的给我解释一下？
    // 为啥后面又有一个const？重载是啥意思？里面是个函数吗？return后面的->又是啥意思？
    //你说的顶堆是什么东西？operator是固定参数吗？大顶堆和小顶堆都是跟排序有关的？类似于js里面的sort？
    /* 
        运算符重载 (Operator Overloading)。C++ 中最“独有”的特性之一
        1、什么是“重载” (Overload)？
            在 C# 或 JS 里，> (大于号) 只能用来比较数字（1 > 0）。
                你不能拿两个“对象”来比，比如 技能A > 技能B，
                编译器会懵逼：“技能怎么比大小？比名字长度？还是比威力？”
            重载的意思就是：赋予这个符号（>）新的含义。
            这段代码的意思是：告诉编译器，以后如果看到两个 SkillCooldown 放在 > 的两边，请自动调用这个函数来判断结果。
        2、operator> 是什么？
            这就是一个函数名！只是它的名字有点怪，叫 operator>。你完全可以把它看作一个叫 IsLargerThan 的函数。      
            它是固定写法，你想改变哪个符号的行为，就写 operator 加上那个符号。
        3、那个 const (放在参数里) 是啥？
            const SkillCooldown &other：
            & (引用)：表示“我不复制一份新的，我直接看一眼原件”。（省内存，快！）
            const：表示“我只看不摸”。我保证在这个函数里，绝对不会修改 other 里面的数据。这是一个安全承诺。
        4、那个 const (放在函数屁股后面) 是啥？
            这是 C++ 特有的！
            它修饰的是 this (我自己)。
            它的意思是：这个函数只是用来“比较”的，我保证在这个函数里，绝对不会修改我自己（this）的数据。
            为什么要有它？ 
                因为在 C++ 的 priority_queue 里，为了保证数据安全，
                它拿出来的对象往往被视为“只读”的。如果你的函数不敢承诺“我不改数据”（不加 const），编译器就不敢调用你。
        5、this->readyTime 是啥？
            this 是一个指针，指向“我自己”。
            在 C++ 指针里，访问属性不用点 .，而是用箭头 ->。
            this->readyTime 等价于 (*this).readyTime，或者在类内部直接写 readyTime。
            你这里直接写 readyTime > other.readyTime 也是对的，写 this-> 是为了显式强调“我的”。
        6、什么是“顶堆” (Heap)？
            这是一种数据结构，你可以把它想象成一个金字塔。
            大顶堆 (Max-Heap)：金字塔顶端永远是最大的那个数。（默认情况）
            小顶堆 (Min-Heap)：金字塔顶端永远是最小的那个数。
            跟排序有关吗？ 是的！它是一种“时刻保持有序”的结构。无论你什么时候往里扔数据，它都会自动调整，保证顶端永远是你想要的那个（最大或最小）。
    */
    bool operator>(const SkillCooldown &other) const
    {
        return this->readyTime > other.readyTime;
    }
};

int main()
{
    // priority_queue这个名字好长，怎么记啊，这是啥意思来着？
    // vector是啥意思来着？我记得as里面也有一个vector，类似于数组的样子
    // greater又是啥意思？最优选？
    /* 
        1、名字怎么记？
            Priority = 优先 / 优先级 (比如 VIP)。
            Queue = 队列 (排队)。
            Priority Queue = 优先队列。意思就是：不是先来后到，而是谁最重要（优先级最高），谁先排到最前面。
        2、vector 是啥？
            你说得对！它就是 动态数组。
            跟 AS3 的 Vector、JS 的 Array、C# 的 List 是一回事。
            在这里，它是 priority_queue 的**“容器”**。就像你买个“弹夹”（队列逻辑），
                你还得告诉它是装在“木盒子”里还是“铁盒子”里。vector 就是那个底层存数据的盒子。
        3、greater 是啥？
            默认情况下，priority_queue 是大顶堆（谁大谁在前面）。
            但在我们的场景里，我们要找**“冷却时间最早结束”**的技能（时间数值最小）。
            所以我们加了 greater（C++ 内置的一个规则），
                强行把规则反转成了：“虽然叫 greater，但配合优先队列，它会让‘小’的那个排在前面”。
                （这是 C++ STL 的一个经典反直觉设计，死记硬背即可：想做小顶堆，就加 greater）。
    */
    priority_queue<SkillCooldown, vector<SkillCooldown>, greater<SkillCooldown>> cdQueue;
    cout << "=== 战斗开始 (Time = 0.0) ===" << endl;
    cout << "[Time 1.0] 释放【火球术】，6.0秒后冷却完毕" << endl;
    // 这个也能这么用啊？跟前面的queue和stack有点像
    cdQueue.push({"火球术", 6.0});
    cout << "[Time 2.0] 释放【闪现】，5.0秒后冷却完毕" << endl;
    cdQueue.push({"闪现", 5.0});
    cout << "-----------------------------" << endl;
    // 模拟时间流逝 (每 0.5秒 检查一次)
    // 假设游戏运行了 8 秒
    for (double curTime = 0; curTime <= 8; curTime += 0.5)
    {
        // 为什么因为同一时刻可能有多个技能同时冷却好，才必须要用while啊？
        /* 
            场景模拟： 假设现在时间 curTime = 5.0 秒。 你的队列顶端有以下技能：
            Q技能：4.9秒冷却好。
            W技能：5.0秒冷却好。
            E技能：5.0秒冷却好。
            R技能：8.0秒冷却好。
            如果你用 if：
            检查队头（Q技能）：4.9 <= 5.0，成立！弹出Q。
            结束了！ 这一帧代码跑完了。
            后果： W 和 E 明明也冷却好了，但这一帧没放出来，要等下一帧甚至下下帧。这在快节奏游戏里就是操作延迟！
            如果你用 while：
            检查 Q (4.9) <= 5.0？是！ 弹出 Q。
            (循环继续) 检查新的队头 W (5.0) <= 5.0？是！ 弹出 W。
            (循环继续) 检查新的队头 E (5.0) <= 5.0？是！ 弹出 E。
            (循环继续) 检查新的队头 R (8.0) <= 5.0？否！ 停下。
            完美！ 这一帧把所有该处理的都处理了。
        
        */
        while (!cdQueue.empty() && cdQueue.top().readyTime <= curTime)
        {
            SkillCooldown readySkill = cdQueue.top();
            cout << ">>> [Time " << curTime << "] 叮！技能【"
                 << readySkill.skillName << "】已冷却！可以再次释放。" << endl;
            // 咦，cdQueue里面的东西自动排好序了吗？因为那个重载？
            /* yes */
            cdQueue.pop();
        }
    }
    return 0;
}

/* 
    总结：
        struct 的重载：就是教 C++ 怎么比较两个“技能包”的大小。
        priority_queue：是一个自动排序的VIP通道。你把东西扔进去（push），它自动把最紧急（最小）的放在门口（top）。
        vector：是它的底层仓库。
        greater：是让它变成“小顶堆”（数值小的优先）的魔法咒语。
        while：是为了**“清空积压”**，确保当前时刻所有就绪的任务都被立刻执行，不留过夜粮。

*/