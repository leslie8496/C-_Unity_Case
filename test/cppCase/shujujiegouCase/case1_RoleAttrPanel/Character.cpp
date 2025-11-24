/*
定长用 Array，变长用 Vector
为什么这里用std::array存核心属性，而用std::vector存Buff是最佳选择？如果都用vector会怎样？
这不仅是语法选择，更是内存管理和语义表达的区别。
定死数量的小数据 -> 必须用 std::array。
数量未知、随时增减的数据 -> 必须用 std::vector。
*/
/* 
    两个&的意思：
    类型 & 新名字 = 。。。   （引用【绰号】）
    。。。 = &旧变量        （取地址【找门牌】）
*/
#include <iostream>
#include <string>
#include <vector>
#include <array>
using namespace std;
struct Buff
{
    string name;
    int value;
    bool isPer;
};
struct Character
{
    array<int, 4> baseAttr;
    vector<Buff> buffAttr;
};
// 这个函数里面的参数是啥意思，为啥要这么写啊？跟指针有关吗？意思是参数c类型为Character，然后这个参数c其实是对应传参的指针？
void displayCharacter(const Character &c)
{
    cout << "------角色面板-------" << endl;
    const string statName[4] = {"力量", "敏捷", "智力", "体力"};
    cout << "【核心属性值】" << endl;
    for (int i = 0; i < c.baseAttr.size(); i++)
    {
        //"\t"是啥意思来着？跟"\n"是一个类型的东西吗？通用的那种吗？
        /* 
        它们是亲兄弟，都叫“转义字符”
        \t (Tab)：制表符。相当于按了一下键盘上的 Tab 键。
        */
        cout << statName[i] << ":" << c.baseAttr[i] << "\t";
    }
    cout << endl;
    cout << "【buff列表】" << endl;
    if (c.buffAttr.empty())
    {
        cout << "木有buff" << endl;
    }
    else
    {
        // 又来了一个这个auto &b又是啥意思？拿到c.buffAttr里面子项的指针吗？auto又是个啥啊？
        /* 
            自动告诉b你是个什么类型
            auto (自动推导)
            总结： const auto &b = “我要遍历这里面的东西，请编译器自动识别类型，直接让我看原件，别复印，我保证不改。”
        */
        for (const auto &b : c.buffAttr)
        {
            cout << "--->" << b.name << ":" << (b.value > 0 ? "+" : "") << b.value << (b.isPer ? "%" : "") << endl;
        }
    }
    cout << "-------------------" << endl;
}
int main()
{
    Character player;
    player.baseAttr = {88,99,39,45};
    player.buffAttr.push_back({"攻击百分比",10,true});
    player.buffAttr.push_back({"防御",60,false});
    player.buffAttr.push_back({"闪避",10});
    displayCharacter(player);

    player.buffAttr.push_back({"狂暴",30,true});
    displayCharacter(player);
}