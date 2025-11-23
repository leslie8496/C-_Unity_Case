/*
### **题目 3：进阶用法 —— `std::vector` (动态数组)**

**说明：** 这是你必须掌握的高阶用法。原生数组长度固定，`vector` 可以通过 `push_back` 动态添加数据。
**知识点：** 需要 `#include <vector>`。
**要求：**

1. 声明一个存整数的 vector：`vector<int> numbers;`
2. 使用 `while(true)` 循环，提示用户输入数字。
3. 如果用户输入 `1`，则 `break` 跳出循环。
4. 否则，使用 `numbers.push_back(输入的值)` 把数据加进去。
5. 循环结束后，打印出用户一共输入了多少个数字（使用 `numbers.size()`）。
6. 遍历打印所有数字。
*/
#include <iostream>
#include <string>
#include <vector>
using namespace std;
int main()
{
    vector<int> numbers;
    int input;
    while (true)
    {
        cout << "输入数字存进数组，输入1暂停输入且输出数组长度" << endl;
        cin >> input;
        if (input == 1)
            break;
        numbers.push_back(input);
    }
    cout << "你一共输入了" << numbers.size() << "个数字" << endl;
    cout << "他们分别是：";
    for (int num : numbers)
    {
        cout << num << " ";
    }
    cout << endl;
    return 0;
}