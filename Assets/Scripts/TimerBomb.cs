using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TimerBomb : MonoBehaviour
{
    [SerializeField] AudioSource explosionSound;
    [SerializeField] float radius;
    [SerializeField] float impulse;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor")) return;
        Collider[] targets = Physics.OverlapSphere(transform.position, radius);
        StartCoroutine(TimeToExplode(targets));
        
        
    }

    public IEnumerator TimeToExplode(Collider[] targets)
    {
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i].TryGetComponent<Rigidbody>(out Rigidbody rb))
                rb.AddExplosionForce(impulse, transform.position, radius);
        }
        explosionSound.Play();
        Destroy(gameObject);
    }
}
