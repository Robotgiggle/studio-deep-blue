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

    public GameObject trailEffect;
    private CharacterController myController;

    public int whatIsGround = 1 << 3;
    Transform _transform;
    Rigidbody _rigidbody;
    public bool isGrounded = false;
    int _playerLayer;

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
        myController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
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

    void PlaySound(AudioClip clip)
    {
        _audio.PlayOneShot(clip);
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("token")){
            TokenManager t = transform.GetChild(0).GetComponent<TokenManager>();
            if(t.tokens<99){
                Destroy(other.transform.parent.gameObject);
                t.tokens++;
            }
        }
    }
}
