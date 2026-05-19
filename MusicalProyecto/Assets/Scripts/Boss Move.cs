using UnityEngine;

public class BossMove : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Transform transgender;
    void Start()
    {
        transgender= GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transgender.position=new Vector3(player.transform.position.x+12,transgender.position.y,transgender.position.z);
    }
}
