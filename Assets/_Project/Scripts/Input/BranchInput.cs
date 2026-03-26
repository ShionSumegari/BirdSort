using System;
using UnityEngine;

public class BranchInput : MonoBehaviour
{
    public InputManager InputManager { get; set; }
    public int Index { get; set; }

    public void OnMouseDown()
    {
        InputManager.Click(Index);
    }
}