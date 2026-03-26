using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private List<BranchView> branchViews;
    private GameController _gameController;

    private void Start()
    {
        Layout();

        var state = CreateLevel();
        _gameController = new GameController(state, branchViews);

        SetupInput();
    }

    private void SetupInput()
    {
        for (var i = 0; i < branchViews.Count; i++)
        {
            var bi = branchViews[i].GetComponent<BranchInput>();
            bi.Index = i;
            bi.InputManager = inputManager;
        }
    }

    public void OnClick(int index)
    {
        _gameController.Select(index);
    }

    private void Layout()
    {
        const float spacing = 2.5f;
        var startX = -(branchViews.Count - 1) * spacing * 0.5f;

        for (var i = 0; i < branchViews.Count; i++)
        {
            var pos = branchViews[i].transform.position;
            pos.x = startX + i * spacing;
            branchViews[i].transform.position = pos;
        }
    }

    private GameState CreateLevel()
    {
        const int cap = 4;

        var b1 = new Branch(cap);
        b1.Push(new Bird(0));
        b1.Push(new Bird(1));
        b1.Push(new Bird(0));
        b1.Push(new Bird(0));

        var b2 = new Branch(cap);
        b2.Push(new Bird(1));
        b2.Push(new Bird(0));
        b2.Push(new Bird(1));

        var b3 = new Branch(cap);
        var b4 = new Branch(cap);

        return new GameState(new List<Branch> { b1, b2, b3, b4 });
    }
}