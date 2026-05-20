using UnityEngine;
using UnityEngine.InputSystem;
using static Unity.Collections.AllocatorManager;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Move : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float speed;
    private Camera cam;
    private bool isGrounded;
    private bool jump;
    private float horizontal;
    [SerializeField]private float jumpForce;
    Vector2 iniPos;

     void Start()
    {
        _rb=GetComponent<Rigidbody2D>();
        isGrounded=true;
        jump=false;
        horizontal=0;
        cam=Camera.main;
        iniPos = transform.position;
    }
    void FixedUpdate()
    {
          cam.transform.position=new Vector3(_rb.position.x+5, cam.transform.position.y,cam.transform.position.z);
        _rb.linearVelocityX = (speed * Time.fixedDeltaTime);
        if (jump)
        {
            _rb.AddForceY(jumpForce);    
            jump = false;
        }
        isGrounded = false;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Floor")
            isGrounded = true;
    }
    public void Movement(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed&&isGrounded)
        {
            jump= true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<TPToInitialPos>() != null) {
            transform.position = iniPos;
        }
    }
}
