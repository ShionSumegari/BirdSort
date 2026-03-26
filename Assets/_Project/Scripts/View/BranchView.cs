using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BranchView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Transform container;
    [SerializeField] private GameObject birdPrefab;

    public void Render(IEnumerable<Bird> birds)
    {
        foreach (Transform c in container)
            Destroy(c.gameObject);

        var i = 0;
        foreach (var b in birds)
        {
            var go = Instantiate(birdPrefab, container);
            go.transform.localPosition = new Vector3(0, i * 0.6f, 0);
            
            go.GetComponent<BirdView>().Setup(b);
            i++;
        }
    }
}
