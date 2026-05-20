using UnityEngine;

public class InfiniteParallax : MonoBehaviour
{
    public float scrollSpeed = 0.1f;

    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        float x = Time.time * scrollSpeed;
        rend.material.mainTextureOffset = new Vector2(x, 0);
    }
}
