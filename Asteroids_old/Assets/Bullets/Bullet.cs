using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bullet_speed;
    public float life_time;
    private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnShot(Vector3 direction)
    {
        //controls what the bullet does when ir is initially shot.
        rigidbody = GetComponent<Rigidbody>();
        transform.forward = direction;
        rigidbody.AddForce (transform.forward * bullet_speed, ForceMode.Impulse);
        Destroy(gameObject, life_time);


    }

}
