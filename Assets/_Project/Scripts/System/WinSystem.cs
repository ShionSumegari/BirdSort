using System.Linq;

public class WinSystem
{
    public bool Check(GameState state)
    {
        foreach (var branch in state.Branches)
        {
            if(branch.isEmpty) continue;
            
            var birdId = branch.Peek().BirdId;

            if (branch.GetBirds().Any(bird => bird.BirdId != birdId))
                return false;
        }
        return true;
    }
}
