/*
### **第 2 关：战斗模拟（循环与判断）**

**目标：** 找回 `while` 循环和 `if` 判断的手感（和 C# 99% 一样）。
**知识点：** 逻辑控制。

**题目：**
你遇到了一个敌人，他的血量是 100。你有一把枪，每次扣动扳机（输入 'a'）造成 20 点伤害。

1. 定义 `enemyHP = 100`。
2. 进入一个循环，只要敌人活着（HP > 0）就一直执行：
    - 程序提示：“敌人还剩 [HP] 血，输入 'a' 进行攻击：”
    - 如果你输入了 'a'，敌人扣 20 血，打印 “砰！击中敌人！”
    - 如果你输入了别的，打印 “未开火...”。
3. 当循环结束（敌人死了），打印 “敌人已被消灭！”
*/
#include <iostream>
#include <string>
using namespace std;

int main()
{
    int enemyHp = 100;
    char input;

    while (enemyHp > 0)
    {
        cout << "敌人还剩" << enemyHp << "血，按a进行攻击";
        cin >> input;
        if (input == 'a')
        {
            enemyHp -= 20;
            cout << "击中敌人" << endl;
        }
        else
        {
            cout << "瞄边大师" << endl;
        }
    }
    cout << "敌人消灭，任务完成" << endl;
    return 0;
}