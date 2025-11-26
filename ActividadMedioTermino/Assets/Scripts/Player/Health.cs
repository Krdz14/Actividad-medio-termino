using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth {get ; private set;}
    [SerializeField] private bool isPlayer;

    private Animator anim;
    private bool dead;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
        
        if (currentHealth > 0)
        {
            //player hurt
            anim.SetTrigger("hurt");

        }
        else
        {
            //player dead
            if(!dead)
            {
                anim.SetTrigger("die");
                dead = true;
                if (isPlayer)
                {
                    GetComponent<PlayerMovement>().enabled = false;
                    GetComponent<PlayerAttack>().enabled = false;
                }
                else
                {
                    GetComponent<RadialShotWeapon>().enabled = false;
                }
            }
            
        }

    }

    public void AddKey(float value)
    {
        currentHealth = Mathf.Clamp(currentHealth + value, 0, startingHealth);
    }

    public void DisableObject()
    {
        gameObject.SetActive(false);
    }

    
}
