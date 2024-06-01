
using UnityEngine;


public class Bullet : MonoBehaviour, IBullet
{
    [SerializeField] float speed;
    [SerializeField] protected int damage;
    protected Transform enemyTarget;
     Rigidbody rb;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        damage = 1;
    }

    public void SetTarget(Transform target) => enemyTarget = target;
    
    private void FixedUpdate()
    {
        if (enemyTarget != null && enemyTarget.gameObject.activeInHierarchy)
        {
            Vector3 direction = (enemyTarget.position - rb.position).normalized;
            rb.velocity = direction * speed;
        }
        else gameObject.SetActive(false);
    }



    public virtual void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.TryGetComponent(out IDamageable damageable))
        {
            damageable.GetDamage(damage);
            gameObject.SetActive(false);
        }
    }

   
}
