#include <iostream>
using namespace std;
queue<string> taskQueue;
void addTask(const string &task)
{
    taskQueue.push(task);
}
void processNextTask()
{
    if (taskQueue.empty())
    {
        cout << "所有任务已完成" << endl;
        return;
    }
    string taskName = taskQueue.front();
    cout << "正在执行：[" << taskName << "]" << endl;
    taskQueue.pop();
}
int main()
{
    addTask("1");
    addTask("2");
    processNextTask();
    processNextTask();
    processNextTask();
    return 0;
}
/* 
队列，std::queue，FIFO (First In First Out)，先进先出；
栈，std::stack，LIFO (Last In First Out)，后进先出；
*/