using UnityEngine;

public class InputManager :MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    public void Click(int index)
    {
        gameManager.OnClick(index);
    }
}
