public class LoseSystem
{
    public bool Check(GameState state)
    {
        var n = state.Branches.Count;

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if(i == j) continue;
                if (CanMove(state, i, j))
                    return false;
            }
        }
        return true;
    }

    private bool CanMove(GameState state, int from, int to)
    {
        var f = state.Branches[from];
        var t = state.Branches[to];
        
        if(f.isEmpty || t.isFull) return false;
        
        var group = f.GetTopGroup();
        if (group.Count <= 0) return false;
        
        var birdId = f.Peek().BirdId;
        return t.isEmpty || t.Peek().BirdId == birdId;
    }
}
