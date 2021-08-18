using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // public variables
    public float moveSpeed = 3.0f;
    public float gravity = 9.81f;
    public float boostRate = 25f;
    public float nextSpeedBoost;

    // Velocity y
    float _vy;
    public float jumpForce = 600;

    public GameObject trailEffect;
    private CharacterController myController;

    public LayerMask whatIsGround;
    public Transform groundCheck;
    Transform _transform;
    Rigidbody _rigidbody;
    public bool isGrounded = false;
    public bool canJump = false;
    int _playerLayer;
    public Vector3 jump;

    //SFX
    AudioSource _audio;
    public AudioClip jumpSFX;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        myController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        /**if(Input.GetButtonDown(""))
        {

        }*/

        isGrounded = Physics.Linecast(_transform.position, groundCheck.position, whatIsGround);
        if (isGrounded)
        {
            canJump = true;
        }

        //_vy = _rigidbody.velocity.y;

        if (Input.GetButtonDown("Jump") && _vy <= 0f && canJump)
        {
            DoJump();
            Debug.Log("Jump Should be Working");
        }
        //Key must be added titled "SpeedBoost" under input in project settings
        /**
        if(Time.time > nextSpeedBoost && (Input.GetButtonDown("SpeedBoost")))
        {
            nextSpeedBoost = Time.time + boostRate;
            moveSpeed = 7f;
            StartCoroutine(SpeedBoostEnd());
        }*/
        if (moveSpeed >= 7f)
        {
            if (trailEffect != null)
                Instantiate(trailEffect, transform.position, transform.rotation);
        }

        // Determine how much should move in the z-direction
        Vector3 movementZ = Input.GetAxis("Vertical") * Vector3.forward * moveSpeed * Time.deltaTime;

        // Determine how much should move in the x-direction
        Vector3 movementX = Input.GetAxis("Horizontal") * Vector3.right * moveSpeed * Time.deltaTime;

        // Convert combined Vector3 from local space to world space based on the position of the current gamobject (player)
        Vector3 movement = transform.TransformDirection(movementZ + movementX);

        // Apply gravity (so the object will fall if not grounded))
        movement.y -= gravity * Time.deltaTime;

        // Actually move the character controller in the movement direction
        myController.Move(movement);
    }

    IEnumerator SpeedBoostEnd()
    {
        yield return new WaitForSeconds(3f);
        moveSpeed = 3f;
    }

    // make the player jump
    void DoJump()
    {
        // reset current vertical motion to 0 prior to jump
        _vy = 0f;
        // add a force in the up direction
        _rigidbody.AddForce(jump * jumpForce, ForceMode.Impulse);
        //_rigidbody.AddForce(new Vector3(0, jumpForce));
        canJump = false;
        // play the jump sound
        if (jumpSFX != null)
            PlaySound(jumpSFX);
    }

    void PlaySound(AudioClip clip)
    {
        _audio.PlayOneShot(clip);
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("token")){
            Destroy(other.gameObject);
            transform.GetChild(0).gameObject.GetComponent<TokenManager>().tokens++;
        }
    }
}
