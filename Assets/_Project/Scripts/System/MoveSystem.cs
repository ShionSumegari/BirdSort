public class MoveSystem
{
    public bool TryMove(GameState gameState, int from, int to)
    {
        var f = gameState.Branches[from];
        var t = gameState.Branches[to];

        if (f.isEmpty || t.isFull) return false;

        var group = f.GetTopGroup();
        if (group.Count <= 0) return false;

        var birdId = f.Peek().BirdId;

        if (!t.isEmpty && t.Peek().BirdId != birdId) return false;

        var space = t.GetAvailableSpace();
        if(space <= 0) return false;

        var moving = f.PopGroup(space);
        t.PushGroup(moving);

        return true;
    }
}
