using UnityEngine;
using UnityEngine.InputSystem;
using static Unity.Collections.AllocatorManager;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Move : MonoBehaviour
{
    Vector3 mousePosition;
    private Rigidbody2D _rb;
    [SerializeField] private float speed;
    private bool isGrounded;
    private bool jump;
    private float horizontal;
    [SerializeField]private float jumpForce;

    private void Start()
    {
        _rb=GetComponent<Rigidbody2D>();
        isGrounded=true;
        jump=false;
        horizontal=0;
    }
    private void FixedUpdate()
    {
        _rb.linearVelocityX = (horizontal * speed * Time.fixedDeltaTime);
        if (jump)
        {
            _rb.AddForceX(jumpForce);    
            jump = false;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Floor")
            isGrounded = true;
    }
    public void Movement(InputAction.CallbackContext context)
    {
        Debug.Log("IN");
        horizontal = context.ReadValue<Vector2>().x;
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed&&isGrounded)
        {
            jump= true;
        }
    }
}
