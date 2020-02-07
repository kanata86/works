using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackholeMove : MonoBehaviour {
    Rigidbody2D a;
    [SerializeField]
    float speed = 8;

    private void Awake()
    {
        a = GetComponent<Rigidbody2D>();
    }

  

    void Update () {
        if (!GameManager.CanMove)
        {
            return;
        }

       
        
        if (ClickPositionCreatePrefabScript.Isactive)
        {
            Vector3 move = ClickPositionCreatePrefabScript.Instance.transform.position - transform.position;
            a.velocity = move.normalized * speed;        
        }
      
    }
}
