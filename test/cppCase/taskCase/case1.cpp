/*
题目 1：数组最值与平均数
目标： 熟悉原生数组的遍历、累加逻辑。 要求：
在 main 函数中定义一个包含 5 个整数的数组：int scores[5] = {85, 92, 73, 99, 60};
使用 for 循环遍历数组。
找出并打印数组中的最大值。
计算并打印这 5 个数的平均值（注意整数除法的问题）。
 */
#include <iostream>
#include <string>
using namespace std;
int main()
{
    //这个int数组命名也和c#里面是不可变的吗
    /* 
        是的，但在 C++ 中更“死板
        在 C++ 原生数组中：数组名 scores 就像一个长在地上的桩子（常量指针）。它死死地钉在那块内存上。
        int scores[5];
        // scores = {1, 2, 3}; // ❌ 报错！你不能让它指向别的地方
        C++ 的原生数组名不能被重新赋值，它代表那就是那块固定的内存地址。
    */
    int scores[5] = {85, 92, 73, 99, 60};
    int maxVal = scores[0];
    int sum = 0;
    for (int i = 0; i < 5; i++)
    {
        //这个里面有类似于js里面的那种Math.max吗？
        /* 
            有！而且用法很灵活。
            C++ 的标准库提供了一个强大的工具箱叫 <algorithm>（算法）。
            比较两个数：std::max(a, b)
            你需要引入头文件：#include <algorithm>
            你的代码可以简写为：maxVal = max(maxVal, scores[i]);
            比较整个数组（高阶用法）：
            如果你懒得写循环，C++ 甚至可以直接帮你找出一个数组里的最大值：
            *max_element(begin(scores), end(scores)) （这个目前先了解即可，以后刷 LeetCode 会用到）。
        */
        if (scores[i] > maxVal)
        {
            maxVal = scores[i];
        }
        sum += scores[i];
    }
    cout << "最大值是" << maxVal << endl;
    //这个计算是把double括起来啊，我接触过的其他的好像都是double()这种
    /* 
    C++ 是个“缝合怪”，这两种写法它都支持！
    1、C 语言风格（你的写法）：(double)sum
    这是最古老、最暴力的写法。把括号放在类型外面。
    特点：霸道，不管能不能转，先转了再说。C# 继承的就是这种写法。
    2、函数风格（你见过的写法）：double(sum)
    这看起来像是在调用一个函数。在 C++ 里，这也是合法的，它等同于上面的写法。
    3、C++ 现代风格（特种兵专用）：static_cast<double>(sum)
    这是最安全、最推荐（在生产环境中）的写法。它会在编译时检查转换是否合理。

    但在刷题和练习时，用现在的 (double)sum 完全没问题
    */
    cout << "平均值是" << (double)sum / 5 << endl;
    return 0;
}