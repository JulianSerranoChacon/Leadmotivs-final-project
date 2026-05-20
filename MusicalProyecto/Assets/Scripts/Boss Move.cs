using UnityEngine;

public class BossMove : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float offset;
    private Transform mTransform;

    void Start()
    {
        mTransform= GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        mTransform.position=new Vector3(player.transform.position.x+offset,mTransform.position.y,mTransform.position.z);
    }
}
