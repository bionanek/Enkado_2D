using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public float lockedpostion;
    public float maxSpeed = 1f;
    public float speed = 50f;
    public float jumpRange = 500f;

    public int curHealth;
    public int maxHealth=20;

    public int curEssenceEarth;
    public int maxEssenceEarth = 1;
    public float cdEssenceEarth = 5f;


    public GameObject water;
    public int curEssenceWater;
    public int maxEssenceWater = 1;
    public float cdEssenceWater = 5f;

    public GameObject tornado;
    public Vector2 velocityTornado;
    public int curEssenceWind;
    public int maxEssenceWind = 1;
    public float cdEssenceWind = 5f;


    public GameObject fireBall;
    public Vector2 velocityFireBall;
    public Vector2 offsetFireBall = new Vector2(0.1f, -0.1f);
    public int curEssenceFire;
    public int maxEssenceFire = 1;
    public float cdEssenceFire = 5f;

    public int curFlash;
    public int maxFlash = 1;
    public float cdFlash= 5f;

    public bool grounded;
    public bool canDoubeJump;

    private Rigidbody2D _rgdb2;
    private Animator _anim;

    private float _horizontal;

    private GameMaster gm;

    public AudioClip[] musicArray;

	// Use this for initialization

    void Awake()
    {
        _rgdb2 = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }
	void Start ()
	{
	    gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>(); //pobranie skyrptu gamemaster 


        //ustawianie warotsci poczatkowych
        curHealth = maxHealth;
	    curEssenceEarth = maxEssenceEarth;
	    curEssenceFire = maxEssenceFire;
	    curEssenceWater = maxEssenceWater;
	    curEssenceWind = maxEssenceWind;
	    curFlash = maxFlash;
	}

    void Update()
    {
        if (transform.position.x < lockedpostion) //nasza postac nie moze byc wzdloz osi X < 4,5
            gameObject.transform.position = new Vector3(lockedpostion, transform.position.y, 0);
        
        _horizontal = Input.GetAxis("Horizontal");
        _anim.SetFloat("speed",Mathf.Abs(_horizontal)); //zaokrgalnie i przekazywnie arguentu do animacji
        _anim.SetBool("grounded",grounded); //przekazywanie argumentu do animacji

        if (_horizontal > 0.1f)
        {
            transform.localScale=new Vector3(7,7,7); //ustawianie keirunku postaci
        }
        if (_horizontal < -0.1f)
        {
            transform.localScale = new Vector3(-7, 7, 7); //ustawianei keirunku psotaci
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                _rgdb2.AddForce(Vector2.up*jumpRange);
                canDoubeJump = true;
                AudioSource.PlayClipAtPoint(musicArray[1], transform.position);
            }
            else
            {
                if (canDoubeJump) //podwojny skok
                {
                    canDoubeJump = false;
                    _rgdb2.velocity=new Vector2(_rgdb2.velocity.x,0);
                    _rgdb2.AddForce(Vector2.up * jumpRange);
                    AudioSource.PlayClipAtPoint(musicArray[1], transform.position);

                }
            }
        }

        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }

        if (curHealth <= 0) //wywalanie funkcji smierc gdy zginiemy
        {
            Die();
        }
        if (curEssenceEarth < maxEssenceEarth) //cooldawn na zakelcie nizej jest to samo 
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

        if (curFlash < maxFlash)
        {
            cdFlash -= Time.deltaTime;
            if (cdFlash <= 0)
            {
                curFlash = maxFlash;
                cdFlash = 5f;
            }
        }

        if (Input.GetKeyDown("z")) //earth wywalnei zkalecia nizej tez sa wywolania
        {
            if (curEssenceEarth == maxEssenceEarth)
            {
                curEssenceEarth = 0;
                AudioSource.PlayClipAtPoint(musicArray[3], transform.position);
            }
        }
        if (Input.GetKeyDown("x"))//water
        {
            if (curEssenceWater == maxEssenceWater)
            {
                int direction = 0;
                if (transform.localScale.x > 0)
                {
                    direction = 5;
                }
                else if (transform.localScale.x < 0)
                {

                    direction = -5;
                }

                Vector3 waterDirection = new Vector3(transform.position.x + direction, transform.position.y, transform.position.z);
                GameObject go = (GameObject)Instantiate(water, waterDirection, Quaternion.identity); //stworzneie obiekty tornado i ustawienei mu pozycji i rotacji 
                curEssenceWater =0;
                AudioSource.PlayClipAtPoint(musicArray[3], transform.position);
            }
        }
        if (Input.GetKeyDown("c"))//wind
        {
            if (curEssenceWind == maxEssenceWind)
            {
                int direction=0;
                if (transform.localScale.x > 0)
                {
                    direction = 1;
                }
                else if(transform.localScale.x<0)
                {
                    
                    direction = -1;
                }

                Vector3 torrnadoDirection= new Vector3(transform.position.x + direction, transform.position.y + 1f, transform.position.z); 
                GameObject go = (GameObject)Instantiate(tornado, torrnadoDirection, Quaternion.identity); //stworzneie obiekty tornado i ustawienei mu pozycji i rotacji 
                go.GetComponent<Rigidbody2D>().velocity = new Vector2(velocityTornado.x * direction *3, velocityTornado.y);//nadanie predkosci tornadowi
                curEssenceWind = 0;
                AudioSource.PlayClipAtPoint(musicArray[3], transform.position);
            }
        }
        if (Input.GetKeyDown("v"))//fire
        {
            if (curEssenceFire == maxEssenceFire)
            {
                GameObject go = (GameObject)Instantiate(fireBall, (Vector2)transform.position + offsetFireBall * transform.localScale.x,
                Quaternion.identity);
                go.GetComponent<Rigidbody2D>().velocity = new Vector2(velocityFireBall.x * transform.localScale.x, velocityFireBall.y); //to samo co wyzej
                curEssenceFire = 0;
                AudioSource.PlayClipAtPoint(musicArray[3], transform.position);
            }
        }
        if (Input.GetKeyDown("f"))//flash
        {
            if (curFlash == maxFlash)
            {
                curFlash = 0;
                AudioSource.PlayClipAtPoint(musicArray[3], transform.position);
            }
        }

    }

	void FixedUpdate ()
	{
	    Vector3 easyVelocity = _rgdb2.velocity; //sztuczne tarcie zeby masza postac sie nei slizgala
	    easyVelocity.y = _rgdb2.velocity.y;
	    easyVelocity.z = 0.00f;
	    easyVelocity.x *= 0.75f;
	    if (grounded)
	    {
	        _rgdb2.velocity = easyVelocity; //usatwainei sztucznego tarcia
	    }



	    float h = Input.GetAxis("Horizontal");
        _rgdb2.AddForce(Vector2.right*speed*h);

	    if (_rgdb2.velocity.x > maxSpeed) // ustawianie stala predkosc naszego bohatera
	    {
	        _rgdb2.velocity = new Vector2(maxSpeed,_rgdb2.velocity.y);
	    }

        if (_rgdb2.velocity.x < -maxSpeed) //ustawianei stalej rpedkosci naszeog bohaera w przeciwynym kierunku niz wyzej
        {
            _rgdb2.velocity = new Vector2(-maxSpeed, _rgdb2.velocity.y);
        }
    }

    void Die() //co ma sie stac gdy zginiesz
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //zaladowanie ponownie obecnej sceny
    }

   public void Damage(int dmg)
    {
        curHealth -= dmg; //dostawanie obrazen
        gameObject.GetComponent<Animation>().Play("player_RedFlash");//aniamcja ze dosatjemy dmg
    }

    public IEnumerator KnockBack(float knockDur,float knockBackPvr,Vector3 knockBackDir) //skrypt do podrzucanai gdy dotkneisz kolcow
    {
        float timer = 0;
        
        _rgdb2.velocity=new Vector2(_rgdb2.velocity.x,0); //predkosc

        while (knockDur > timer) //do poki trwa knockdur 
        {
            timer += Time.deltaTime; //zwieksza sie timer o 1
            _rgdb2.AddForce(new Vector3(knockBackDir.x -100,knockBackDir.y+100,transform.position.z)); //podrzuca -100 w lewo i +100 do gory
        }
        yield return 0; //interfejs wymaga zwracania czego kolwiek yeilda
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
                curHealth += 1;
            AudioSource.PlayClipAtPoint(musicArray[4], transform.position); //wlaczanie piosenki o indexie 4 z tablicy
        }
        if (col.CompareTag("RedPotion"))
        {
            Destroy(col.gameObject);
            gm.hpPotion += 1;
            AudioSource.PlayClipAtPoint(musicArray[4], transform.position);
        }
        if (col.CompareTag("EssenceEarth"))
        {
            Destroy(col.gameObject);
            gm.earthPotion += 1;
            AudioSource.PlayClipAtPoint(musicArray[4], transform.position);
        }
        if (col.CompareTag("EssenceWater"))
        {
            Destroy(col.gameObject);
            gm.waterPotion += 1;
            AudioSource.PlayClipAtPoint(musicArray[4], transform.position);
        }
        if (col.CompareTag("EssenceWind"))
        {
            Destroy(col.gameObject);
            gm.windPotion += 1;
            AudioSource.PlayClipAtPoint(musicArray[4], transform.position);
        }
        if (col.CompareTag("EssenceFire"))
        {
            Destroy(col.gameObject);
            gm.firePotion += 1;
            AudioSource.PlayClipAtPoint(musicArray[4], transform.position);
        }
        if (col.CompareTag("Key"))
        {
            Destroy(col.gameObject);
            gm.keys += 1;
            AudioSource.PlayClipAtPoint(musicArray[4], transform.position);
        }
    }

    public void Sound() //funkcja wywylywana e evencie w animacji atatku
    {
        AudioSource.PlayClipAtPoint(musicArray[2], transform.position);
    }
}
