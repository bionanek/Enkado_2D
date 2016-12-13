using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{

    private float fireSpellStart = 0f;
    private float fireSpellCooldown = 5f; // 2 = two seconds 

    public float maxSpeed = 1f;
    public float speed = 50f;
    public float jumpRange = 500f;

    public int curHealth;
    public int maxHealth=5;

    public int curEssenceEarth;
    public int maxEssenceEarth = 1;
    public float cdEssenceEarth = 5f;
    public int curEssenceWater;
    public int maxEssenceWater = 1;
    public float cdEssenceWater = 5f;
    public int curEssenceWind;
    public int maxEssenceWind = 1;
    public float cdEssenceWind = 5f;

    public GameObject fireBall;
    public Vector2 velocityFireBall;
    public Vector2 offsetFireBall = new Vector2(0.1f, -0.1f);
    public int curEssenceFire;
    public int maxEssenceFire = 1;
    public float cdEssenceFire = 5f;

    public bool grounded;
    public bool canDoubeJump;

    private Rigidbody2D _rgdb2;
    private Animator _anim;

    private float _horizontal;

    private GameMaster gm;

	// Use this for initialization

    void Awake()
    {
        _rgdb2 = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }
	void Start ()
	{
	    gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();

        curHealth = maxHealth;
	    curEssenceEarth = maxEssenceEarth;
	    curEssenceFire = maxEssenceFire;
	    curEssenceWater = maxEssenceWater;
	    curEssenceWind = maxEssenceWind;
	}

    void Update()
    {
        if (transform.position.x < -4.5f)
            gameObject.transform.position = new Vector3(-4.5f, transform.position.y, 0);
        
        _horizontal = Input.GetAxis("Horizontal");
        _anim.SetFloat("speed",Mathf.Abs(_horizontal));
        _anim.SetBool("grounded",grounded);

        if (_horizontal > 0.1f)
        {
            transform.localScale=new Vector3(7,7,7);
        }
        if (_horizontal < -0.1f)
        {
            transform.localScale = new Vector3(-7, 7, 7);
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                _rgdb2.AddForce(Vector2.up*jumpRange);
                canDoubeJump = true;
            }
            else
            {
                if (canDoubeJump)
                {
                    canDoubeJump = false;
                    _rgdb2.velocity=new Vector2(_rgdb2.velocity.x,0);
                    _rgdb2.AddForce(Vector2.up * jumpRange);
                    
                 }
            }
        }

        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }

        if (curHealth <= 0)
        {
            Die();
        }
        if (curEssenceEarth < maxEssenceEarth)
        {
            cdEssenceEarth -= Time.deltaTime;
            if (cdEssenceEarth <= 0)
            {
                curEssenceEarth = maxEssenceEarth;
                cdEssenceEarth = 5f;
            }
        }

        if (curEssenceWater < maxEssenceWater)
        {
            cdEssenceWater -= Time.deltaTime;
            if (cdEssenceWater <= 0)
            {
                curEssenceWater = maxEssenceEarth;
                cdEssenceWater= 5f;
            }
        }

        if (curEssenceWind < maxEssenceWind)
        {
            cdEssenceWind -= Time.deltaTime;
            if (cdEssenceWind <= 0)
            {
                curEssenceWind = maxEssenceWind;
                cdEssenceWind = 5f;
            }
        }

        if (curEssenceFire < maxEssenceFire)
        {
            cdEssenceFire -= Time.deltaTime;
            if (cdEssenceFire <= 0)
            {
                curEssenceFire = maxEssenceFire;
                cdEssenceFire = 5f;
            }
        }

        if (Input.GetKeyDown("z")) //earth
        {
            if (curEssenceEarth == maxEssenceEarth)
            {
                curEssenceEarth = 0;
            }
        }
        if (Input.GetKeyDown("x"))//water
        {
            if (curEssenceWater == maxEssenceWater)
            {
                curEssenceWater = 0;
            }
        }
        if (Input.GetKeyDown("c"))//wind
        {
            if (curEssenceWind == maxEssenceWind)
            {
                curEssenceWind = 0;
            }
        }
        if (Input.GetKeyDown("v"))//fire
        {
            if (curEssenceFire == maxEssenceFire)
            {
                GameObject go = (GameObject)Instantiate(fireBall, (Vector2)transform.position + offsetFireBall * transform.localScale.x,
                Quaternion.identity);
                go.GetComponent<Rigidbody2D>().velocity = new Vector2(velocityFireBall.x * transform.localScale.x, velocityFireBall.y);
                curEssenceFire = 0;
            }
        }
    }

	void FixedUpdate ()
	{
        //fake friction
	    Vector3 easyVelocity = _rgdb2.velocity;
	    easyVelocity.y = _rgdb2.velocity.y;
	    easyVelocity.z = 0.00f;
	    easyVelocity.x *= 0.75f;
	    if (grounded)
	    {
	        _rgdb2.velocity = easyVelocity;
	    }



	    float h = Input.GetAxis("Horizontal");
        _rgdb2.AddForce(Vector2.right*speed*h);

	    if (_rgdb2.velocity.x > maxSpeed)
	    {
	        _rgdb2.velocity = new Vector2(maxSpeed,_rgdb2.velocity.y);
	    }

        if (_rgdb2.velocity.x < -maxSpeed)
        {
            _rgdb2.velocity = new Vector2(-maxSpeed, _rgdb2.velocity.y);
        }
    }

    void Die()
    {
        SceneManager.LoadScene(0);
    }

   public void Damage(int dmg)
    {
        curHealth -= dmg;
        gameObject.GetComponent<Animation>().Play("player_RedFlash");
    }

    public IEnumerator KnockBack(float knockDur,float knockBackPvr,Vector3 knockBackDir)
    {
        float timer = 0;
        
        _rgdb2.velocity=new Vector2(_rgdb2.velocity.x,0);

        while (knockDur > timer)
        {
            timer += Time.deltaTime;
            _rgdb2.AddForce(new Vector3(knockBackDir.x -100,knockBackDir.y+300,transform.position.z));
        }
        yield return 0;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("coin"))
        {
            Destroy(col.gameObject);
            gm.point += 1;
        }
        if (col.CompareTag("Heart"))
        {
            Destroy(col.gameObject);
            if (curHealth < 5)
                curHealth +=1;
        }
        if(col.CompareTag("RedPotion"))
        {
            Destroy(col.gameObject);
            curHealth = maxHealth;
        }
    }
}
