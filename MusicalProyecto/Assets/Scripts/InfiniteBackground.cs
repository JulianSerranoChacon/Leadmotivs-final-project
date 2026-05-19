using UnityEngine;

public class InfiniteBackground : MonoBehaviour
{
    private float spriteWidth;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        spriteWidth = sr.bounds.size.x;
    }

    void Update()
    {
        float distance = cam.transform.position.x - transform.position.x;

        if (distance >= spriteWidth)
        {
            transform.position += Vector3.right * spriteWidth * 2;
        }
    }
}
