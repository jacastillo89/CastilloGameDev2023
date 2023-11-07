using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
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

    //Controls what bullet does when spawned
    public void OnShot(Vector3 direction)
    {
        rigidbody = GetComponent<Rigidbody>();
        transform.forward = direction;
        rigidbody.AddForce(transform.forward * bullet_speed, ForceMode.Impulse);
        Destroy(gameObject,life_time);
    }
    
}
