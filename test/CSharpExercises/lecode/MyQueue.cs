namespace CSharpExercises.lecode;

public class MyQueue
{
    private List<int> _queue;

    public MyQueue()
    {
        _queue = new List<int>();
    }
    public void Push(int x) {
        _queue.Add(x);
    }
    
    public int Pop() {
        int value = _queue[0];
        _queue.RemoveAt(0);
        return value;
    }
    
    public int Peek()
    {
        return _queue[0];
    }
    
    public bool Empty()
    {
        return _queue.Count <= 0;
    }
}