using System.Collections.Generic;
using UnityEngine;

public class GameController
{
    private GameState _state;
    
    private MoveSystem _moveSystem;
    private WinSystem _winSystem;
    private LoseSystem _loseSystem;

    private List<BranchView> _views;
    private int _selected = -1;

    public GameController(GameState state, List<BranchView> views)
    {
        _state = state;
        _views = views;
        
        _moveSystem = new MoveSystem();
        _winSystem = new WinSystem();
        _loseSystem = new LoseSystem();
        
    }

    public void Select(int index)
    {
        if (_selected == -1)
        {
            _selected = index;
            return;
        }

        if (!_moveSystem.TryMove(_state, _selected, index)) return;
        Render();
        if(_winSystem.Check(_state))
            Debug.Log("WIN!");
        else if(_loseSystem.Check(_state))
            Debug.Log("LOSE!");
    }

    private void Render()
    {
        for (var i = 0; i < _views.Count; i++)
            _views[i].Render(_state.Branches[i].GetBirds());
    }
}
