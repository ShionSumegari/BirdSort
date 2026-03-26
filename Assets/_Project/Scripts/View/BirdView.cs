using UnityEngine;
using UnityEngine.Serialization;

public class BirdView : MonoBehaviour
{
   [SerializeField] private SpriteRenderer spriteRenderer;
   
    public void Setup(Bird bird)
    {
        spriteRenderer.color = GetColor(bird.BirdId);
    }

    private Color GetColor(int id)
    {
        var colors = new[]{ Color.red, Color.green, Color.blue, Color.yellow };
        return colors[id];
    }
}
