using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolElementBehaviour : MonoBehaviour
{
    public ObjectPool pool;
    // Start is called before the first frame update
    public void ReturnToPool()
    {
        pool.RetrieveBullet(gameObject);
    }
}
