
using UnityEngine;

public class HarryMovement : MonoBehaviour
{
    // Start is called before the first frame update
    //Movimientos
    public float JumpForce;
    public float Speed;
    private Rigidbody2D _rigidbody2D;
    private float _horizontal;
    private float _vertical;
    private bool Grounded;
    public bool canMove = true;
    
    //Combate
    public GameObject BoomerangPrefab;
    private bool hasBoomerang = true;
    private float boomerangTime;
    private bool isThrows = false;
    private GameObject boomerang;
    private Transform _transform;
    
    //Animaciones
    private Animator _animator;
    private string currentStep;
    private const string HARRY_QUIET = "Harry_Quiet";
    private const string HARRY_WALK = "Harry_Walk";
    private const string HARRY_THROWS = "Harry_Throws";
    private const string HARRY_WAIT_THROWS = "Harry_Wait_Throws";
    /*[SerializeField] private Vector2 reboundVelocity;*/

    void Start()
    {
        _transform = GetComponent<Transform>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento Horizontal
        _horizontal = Input.GetAxisRaw("Horizontal");
        
        Debug.DrawRay(transform.position, Vector3.down * 5f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 5f))
        {
            Grounded = true;
        }
        else
        {
            Grounded = false;
        }
        if (Input.GetKeyDown(KeyCode.W) && Grounded  && canMove)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (hasBoomerang)
            {
                isThrows = true;
                changeAnimationState(HARRY_THROWS);
            }
        }

        if (!hasBoomerang&&Time.time > boomerangTime + 1f)
        {
            returnBoomerang();
        }
        

    }

    private void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void FixedUpdate()
    {
        if (_horizontal != 0 && canMove)
        {
            _rigidbody2D.velocity = new Vector2(_horizontal*Speed, _rigidbody2D.velocity.y);
            if (_horizontal > 0)
            {
                isThrows = false;
                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                changeAnimationState(HARRY_WALK);
            }
            else if (_horizontal < 0)
            {
                isThrows = false;
                transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
                changeAnimationState(HARRY_WALK);
            }
        }
        else
        {
            if (!isThrows && hasBoomerang)
            {
                changeAnimationState(HARRY_QUIET);
            }
            else if(!hasBoomerang)
            {
                if (boomerang.GetComponent<Transform>().position.x>transform.position.x)
                    transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                else
                    transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
                changeAnimationState(HARRY_WAIT_THROWS);
            }
        }
    }

    public void changeAnimationState(string newState)
    {
        if(currentStep==newState) return;
        _animator.Play(newState);
        currentStep = newState;
        if (newState == "quiet")
        {
            _animator.Play((HARRY_QUIET));
            currentStep = newState;
        }
    }

    /*public void rebound(Vector2 hitPoint)
    {
        Rigidbody2D.velocity = new Vector2(reboundVelocity.x * hitPoint.x, reboundVelocity.y);
    }*/

    private void Shoot()
    {
        boomerangTime = Time.time;
        hasBoomerang = false;
        Vector3 direction;
        if (transform.localScale.x == 1.0f)
            direction = Vector3.right;
        else
        {
            direction = Vector2.left;
        }
        
        boomerang =
            Instantiate(BoomerangPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        boomerang.GetComponent<BoomerangScript>().SetDirection(direction);

    }

    private void returnBoomerang()
    {
        if (!hasBoomerang)
        {
            boomerang.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            boomerang.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            Vector2 direction = (Vector2)_transform.position - boomerang.GetComponent<Rigidbody2D>().position;
            direction.Normalize();
            float rotate = Vector3.Cross(direction, transform.up).z;
            boomerang.GetComponent<Rigidbody2D>().angularVelocity = -rotate * 1f;
            boomerang.GetComponent<Rigidbody2D>().velocity = transform.up * 15f;
            
            
            boomerang.GetComponent<BoomerangScript>().SetDirection(direction);
            isThrows = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasBoomerang && Time.time > boomerangTime + 1f)
        {
            if (collision.gameObject.tag == "Boomerang")
            {
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                Destroy(collision.gameObject);
                hasBoomerang = true;
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
}
