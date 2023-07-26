using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] AudioSource explosionSound;
    [SerializeField] float radius;
    [SerializeField] float impulse;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor")) return;
        Collider[] targets = Physics.OverlapSphere(transform.position, radius);
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i].TryGetComponent<Rigidbody>(out Rigidbody rb))
            rb.AddExplosionForce(impulse, transform.position, radius);
        }
        explosionSound.Play();
        Destroy(gameObject);
    }
}
