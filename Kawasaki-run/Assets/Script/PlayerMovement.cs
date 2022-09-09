using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public GameObject Animation;
    public Rigidbody hips;
    AudioSource audioData;


    public float speed;
    public float strafespeed;
    public float jumpForce;
    public float Turnsmoothtime = 0.1f;
    float turnSmoothVelocity;

    public bool isGrounded = false;
    public Transform cam;
    

    // Start is called before the first frame update
    void Start()
    {
        hips = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
   
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, Turnsmoothtime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Animation.GetComponent<Animator>().SetBool("isWalk", true);
        }
        else
        {
            Animation.GetComponent<Animator>().SetBool("isWalk", false);
        }
        PlayerMoverment();

    }
    private void PlayerMoverment()
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            
            hips.AddForce(hips.transform.forward * speed);   
        }
        if (Input.GetKey(KeyCode.A))
        {
         
            hips.AddForce(-hips.transform.right * strafespeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
           
            hips.AddForce(hips.transform.forward * speed * 1.5f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            
            hips.AddForce(hips.transform.right * strafespeed);
        }
        if (Input.GetAxis("Jump") > 0)
        {
            if (isGrounded != true)
            {
                return;
            }
            hips.AddForce(new Vector3(0, jumpForce, 0));
            isGrounded = false;
            Animation.GetComponent<Animator>().SetBool("Jump", true);
        }
        else {
            Animation.GetComponent<Animator>().SetBool("Jump", false);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
       
        
        if (other.CompareTag("Coin"))
        {
            audioData = GetComponent<AudioSource>();
            audioData.Play();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Plane"))
        {
            isGrounded = true;
        }

    }
}
