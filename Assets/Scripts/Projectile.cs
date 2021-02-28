using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Collider playerCollider = player.GetComponent<Collider>();
        Collider projectileCollider = GetComponent<Collider>();
        Physics.IgnoreCollision(playerCollider, projectileCollider, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
