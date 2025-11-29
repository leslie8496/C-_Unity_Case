#include <iostream>
using namespace std;
struct Position
{
    float x;
    float y;
};

struct Command
{
    string actionType;
    Position pos;
};
stack<Command> history;
stack<Command> redoStack;
void PlaceEnemy(float x, float y)
{
    cout << "[操作],在:" << x << "," << y << "位置放置了一个敌人" << endl;
    Command cmd;
    cmd.actionType = "PlaceEnemy";
    // 原来还可以用这种方式去存储设置Position呀
    /* 
        解析： 这叫 聚合初始化 (Aggregate Initialization)。
        因为你的 Position 结构体很简单，只有 x 和 y，没有复杂的构造函数，
        所以 C++ 允许你直接用花括号 {} 按顺序填入数据。
        这在 C++11 之后非常常用，写起来很爽。
    */
    cmd.pos = {x, y};
    history.push(cmd);
    // if(!redoStack.empty()){
        
    // }
    /* 
        不管你原来里面有什么（或者什么都没有），我现在都用一个新的空栈把你给替换掉
        如果栈里有东西：旧数据被销毁，替换成空的。
        如果栈本来就是空的：旧的空栈被替换成新的空栈（虽然听起来像是废话，但计算机执行起来非常快，几乎没有成本）。
    */
    redoStack = stack<Command>();
    
}


void Undo()
{
    cout << "尝试撤销。。。。。" << endl;
    if (history.empty())
    {
        cout << "没有可撤销的操作了" << endl;
        return;
    }
    Command lastCmd = history.top();
    redoStack.push(lastCmd);
    cout << "已经成功撤销操作：" << lastCmd.actionType << "位置(" << lastCmd.pos.x << "," << lastCmd.pos.y << ")" << endl;
    // 这个和上面那个push都很像js里面的，这个pop返回的是什么呢？不返回吗，还是返回的指针之内的？
    // 可以直接用pop替代上面的top吗？
    //这个pop不返回东西，要搭配上面的top一起使用
    history.pop();
}

void Redo()
{
    if(redoStack.empty()){
        cout<<"没有可以恢复的撤销操作"<<endl;
        return;
    }
    Command lastReCmd = redoStack.top();
    history.push(lastReCmd);
    cout << "已经成功恢复撤销操作：" << lastReCmd.actionType << "位置(" << lastReCmd.pos.x << "," << lastReCmd.pos.y << ")" << endl;
    redoStack.pop();
}
int main()
{
    PlaceEnemy(10, 10);
    PlaceEnemy(20, 20);
    PlaceEnemy(55, 66);
    Redo();
    cout << "-------------------" << endl;
    Undo();
    Undo();
    cout << "-------------------" << endl;
    PlaceEnemy(99, 99);
    Undo();
    Undo();
    Undo();
    Redo();
    return 0;
}