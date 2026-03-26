using System.Collections.Generic;
public class Branch
{
    private readonly Stack<Bird> _birds = new();
    public int Capacity {get; private set;}

    public Branch(int capacity)
    {
        Capacity = capacity;
    }
    
    public bool isEmpty => _birds.Count <= 0;
    public bool isFull => _birds.Count >= Capacity;
    public int count => _birds.Count;

    public Bird Peek() => _birds.Peek();
    
    public void Push(Bird bird) => _birds.Push(bird);
    public Bird Pop() => _birds.Pop();

    public List<Bird> GetTopGroup()
    {
        var result = new List<Bird>();
        
        if(isEmpty) return result;
        var birdId = Peek().BirdId;

        foreach (var b in _birds)
        {
            if(b.BirdId == birdId)
                result.Add(b);
            else break;
        }

        return result;
    }

    public List<Bird> PopGroup(int maxCount)
    {
        var group = GetTopGroup();
        var moveCount = System.Math.Min(group.Count, maxCount);
        
        var result = new List<Bird>();
        for (var i = 0; i < moveCount; i++)
        {
            result.Add(Pop());
        }
        return result;
    }

    public void PushGroup(List<Bird> group)
    {
        foreach (var b in group)
        {
            Push(b);
        }
    }
    
    public int GetAvailableSpace() => Capacity - count;

    public IEnumerable<Bird> GetBirds() => _birds;
}
