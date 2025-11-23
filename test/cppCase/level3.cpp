/*
### **第 3 关：装备系统（结构体 struct）**

**目标：** 理解 C++ 的 `struct`（它和 C# 的 class 用法很像，但在 C++ 里默认是公开的）。
**知识点：** 把数据打包。

**题目：**

1. 在 `main` 函数**外面**，定义一个 `struct Weapon`（武器）。
2. 它有两个属性：`string name`（名字），`int damage`（攻击力）。
3. 在 `main` 函数里，创建一个 `Weapon` 变量，名字叫 "AK47"，攻击力是 30。
4. 打印出：“我捡到了一把 [名字]，攻击力是 [攻击力]。”

*/
#include <iostream>
#include <string>
using namespace std;
struct Weapon
{
    string name;
    int damage;
};

int main()
{
    //这里的myGun是不用new的吗？
    /* 
    这是 C++ 和 Java/C# 最大的区别之一：
    在 C# / Java 中：
    如果你写 Weapon myGun;，你只得到了一个空壳（引用/指针），它是 null。
    你必须写 myGun = new Weapon(); 才能真正在内存里造出一个对象来。
    在 C++ 中：
    当你写 Weapon myGun; 时，编译器立刻、马上就在**栈（Stack）**上为你造好了一个完整的、实实在在的 Weapon 对象。
    它已经出生了，占用了内存，可以直接使用了。
    */
   /* 
   什么时候才用 new？ 如果你写 Weapon* myGun = new Weapon();（注意那个星号 *），这时候：
    对象被创建在了**堆（Heap）**上（仓库里）。
    你手里拿到的 myGun 只是一个指针（仓库钥匙）。
    代价： 用完后，你必须亲手写 delete myGun; 把它销毁，否则就会内存泄漏（C# 有 GC 帮你收垃圾，C++ 没有）。
    战术总结： 初学阶段，能不用 new 就绝不用 new。直接定义变量（栈上分配），用完自动销毁，既快又安全。
   */
    Weapon myGun;
    myGun.name = "AK47";
    myGun.damage = 30;
    //我这里要是写成cout>>会咋样？
    /* 编译器会当场报错，拒绝编译
    cout (Console Out) 是个大喇叭。
    我们要把数据“推”给它，让它喊出来。
    所以箭头必须指向左边：cout << "你好" （数据 流向 屏幕）。
    cin (Console In) 是个吸尘器。
    我们要让它把键盘敲的数据“吸”进变量里。
    所以箭头必须指向右边：cin >> name （数据 流向 变量）。
    */
    cout << "我这有一把伤害为" << myGun.damage << "的" << myGun.name<<endl;
}
