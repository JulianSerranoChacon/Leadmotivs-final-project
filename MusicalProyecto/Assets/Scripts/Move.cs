using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
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
    [SerializeField] GameObject portalPrefab;
    private bool portalInstanciado = false;
    MusicPlayer musicPlayer;

    public void RegisterMP(MusicPlayer mp)
    {
        musicPlayer = mp;
    }

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
        if (!portalInstanciado && collision.GetComponent<TPToInitialPos>() != null) {
            transform.position = iniPos;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (!musicPlayer.getIsplaying() && !portalInstanciado)
        {
            GameObject portal = Instantiate(portalPrefab);
            portal.transform.position = transform.position + new Vector3(12, 0, 0);
            portal.GetComponent<Portal>().setNextScene((SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings);
            portalInstanciado = true;
        }
    }
}
