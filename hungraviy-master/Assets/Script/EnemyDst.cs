using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDst : MonoBehaviour
{
    Animator ani;
    // Use this for initialization
    void Start()
    {
        ani = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject target = GameObject.FindGameObjectWithTag("BlackHole");
        if (target == null)
        {
            return;
        }
        float dist = Vector3.Distance(target.transform.position, transform.position);
        if (dist < 1)
        {
            ani.SetTrigger("out");
            Destroy(gameObject, 1);
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<CapsuleCollider2D>().enabled = false;
          
        }
    }
}
