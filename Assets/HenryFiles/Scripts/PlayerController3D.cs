using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3D : MonoBehaviour
{

    public float moveSpeed = 5.0f;
    public float gravity = 9.81f;
    float _vy;
    public float jumpForce = 10f;

    private CharacterController myController;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    Transform _transform;
    Rigidbody _rigidbody;
    public bool canJump = false;
    public bool isGrounded = false;
    int _playerLayer;

    // Start is called before the first frame update
    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody>();
        _playerLayer = this.gameObject.layer;
    }

    void Start()
    {
        myController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Tests if player object is touching ground
        isGrounded = Physics.Linecast(_transform.position, groundCheck.position, whatIsGround);

        if (isGrounded)
        {
            canJump = true;
        }

        _vy = _rigidbody.velocity.y;

        //Player jump key-response
        if (Input.GetButtonDown("Jump") && _vy == 0f && canJump)
        {
            DoJump();
        }

        //Jump function
        void DoJump()
        {
            _rigidbody.AddForce(new Vector3(0, jumpForce));
            canJump = false;
        }

        //Directional ground movement, applies basic earth gravity
        Vector3 movementZ = Input.GetAxis("Vertical") * Vector3.forward * moveSpeed * Time.deltaTime;
        Vector3 movementX = Input.GetAxis("Horizontal") * Vector3.right * moveSpeed * Time.deltaTime;
        Vector3 movement = transform.TransformDirection(movementZ + movementX);
        movement.y -= gravity * Time.deltaTime;
        myController.Move(movement);
    }
}
