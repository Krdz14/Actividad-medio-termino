using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private bool hit;
    private float direction;
    private float lifetime;

    private BoxCollider2D boxCollider;
    private Animator anim;
    public Vector2 Velocity;

   
    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hit) return;
        transform.position += (Vector3)Velocity * Time.deltaTime;
        //float movementSpeed = speed * Time.deltaTime * direction;
        //transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > 1) 
            Deactivate();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxCollider.enabled = false;
        anim.SetTrigger("explode");

        if(collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }

    public void SetDirection(float _direction)
    {
        lifetime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
        {
            localScaleX = -localScaleX;
        }
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate()
    {
        lifetime = 0;
        hit = false;
        boxCollider.enabled = true;
        anim.ResetTrigger("explode");
        if (BulletPool.Instance != null)
            BulletPool.Instance.ReleaseBullet(this);
        else
            gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        BulletStats.AddEnemyBullet();
    }

    private void OnDisable()
    {
        BulletStats.RemoveEnemyBullet();
    }

}
