using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeArea : MonoBehaviour
{
    public float radius = 5;

    private Health _health;

    [SerializeField] PersistentData persistent;

    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Health health = collision.GetComponent<Health>();
            health.immortality = true;
            _health = health;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && _health != null)
        {
            _health.immortality = persistent.immortality;
            _health = null;
        }
    }

    private void OnDestroy()
    {
        if (_health != null)
        {
            _health.immortality = persistent.immortality;
            _health = null;
        }
    }

}
