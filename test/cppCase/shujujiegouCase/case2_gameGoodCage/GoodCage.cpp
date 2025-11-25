
#include <string>
#include <unordered_map>
#include <iostream>
using namespace std;
struct ItemData
{
    string name;
    int price;
};
// 为什么我前面没有引入这个头文件才能使用无序映射（哈希表）后面也能用？
/* 
    在某些编译器（比如 MSVC 或某些版本的 GCC）中，
    <iostream> 可能会偷偷在内部引入 <string> 或其他库。
    但这是一种非标准行为,是运气？不过也可以看编辑器报不报错，报错的话修复红波浪线的内容就行了
*/
unordered_map<int, ItemData> itemDataBase;
void printItemInfo(int itemID)
{
    cout << "-----------find方法开始查找------------" << endl;
    // find 方法会返回一个迭代器。如果找到了，指向该元素；如果没找到，指向 .end()
    /* 
        不仅告诉你有没有，如果“有”的话，
        还顺便把东西的位置（迭代器）给你。这样你就可以直接读取数据，
        不需要像 count 之后再查一次，效率最高。
    */
    auto it = itemDataBase.find(itemID);
    if (it != itemDataBase.end())
    {
        cout << "查找成功，itemID[" << it->first << "]" << endl;
        cout << "名称为:" << it->second.name << endl;
        cout << "售价为:" << it->second.price << endl;
    }
    else
    {
        // 没找到
        cout << "find没有找到这个物品ID喔" << endl;
    }
    cout << "-----------find方法查找结束------------" << endl;
}
void printItemInfo1(int itemID)
{
    cout << "-----------count方法开始查找------------" << endl;
    // count(key)逻辑简单，适合只判断是否存在
   
    if (itemDataBase.count(itemID) > 0)
    {
        // 那这里为啥不直接用item来判空呢？非要用count才行吗？count返回的是下标吗？没有找到就返回-1?
        /* 
            如果你用 [] 去读取一个不存在的 ID（比如 itemDatabase[404]），
            C++ 会非常“热心”地帮你凭空创建一个 ID 为 404 的空物品放进去！
            这通常不是我们想要的（会导致数据库被垃圾数据污染）
            原则： 只有在写入/修改数据时才用 []，读取时尽量不用。

            在 C++ 里，ItemData item 是实实在在存在栈上的数据。
            就像你买了一个空钱包，钱包本身是存在的，只是里面没钱。
            你不能问“这个钱包是不是不存在”。
            如果你写 if (item == nullptr)，编译器会直接报错，因为它不是指针。

            count(key) 返回的是出现的次数。
            但在 unordered_map（无序映射）里，Key 是唯一的，所以返回值只能是 1（有）或者 0（无）。它不返回下标。
         */
        ItemData item = itemDataBase[itemID];
        cout << "查找成功，itemID[" << itemID << "]" << endl;
        cout << "名称为:" << item.name << endl;
        cout << "售价为:" << item.price << endl;
    }
    else
    {
        // 没找到
        cout << "count没有找到这个物品ID喔" << endl;
    }
    cout << "-----------count方法查找结束------------" << endl;
}
int main()
{
    itemDataBase[101] = {"药水", 150};
    itemDataBase[102] = {"法书", 300};
    itemDataBase[102] = {"法书1", 300};//这里会插入成功

    // 使用 .insert() 或 .emplace() (更严谨，Key 重复时不会覆盖)
    // 那么问题就来了，key重复的时候会咋样？
    /* 
        插入失败，静默处理，保留旧值。
        itemDataBase[103] = ... (下标法)：如果不存就创建，如果存在就覆盖（霸道总裁）。
        itemDataBase.insert(...) (函数法)：如果不存在就创建，如果存在就放弃操作，保留原来的值（保守派）。
    */
    itemDataBase.insert({103, {"铁剑", 250}});
    itemDataBase.insert({103, {"铁剑1", 250}});//那这里会插入失败
    // emplace咋用啊
    /* 
        需要显式地告诉它这是个 ItemData
        emplace 是为了减少内存拷贝而生的，它比较“傲娇”，
        不支持 {} 这种初始化列表的自动推导（除非你有特定的构造函数）
    */
     itemDataBase.emplace(104,ItemData{"绿宝石",100});
     itemDataBase.emplace(104,ItemData{"绿宝石1",100});//这里也会插入失败
    printItemInfo(101);
    printItemInfo(103);
    printItemInfo1(102);
    printItemInfo1(103);

    printItemInfo(104);
    printItemInfo1(104);

    printItemInfo(105);
    printItemInfo1(105);
    return 0;
}