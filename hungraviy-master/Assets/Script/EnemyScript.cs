using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public static EnemyScript instance;
    Animator ani;

    new Rigidbody2D  rigidbody2D;
    public float speed;//移動速度

    public Vector3 asimoto = new Vector3(-1.5f,-1.7f,0f);
    public float asimotohankei = 0.2f;

    void Awake()
    {
        ani = GetComponentInChildren<Animator>();
        instance = this;
    }

    // Use this for initialization
    void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
       
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 p = transform.position + new Vector3(asimoto.x * transform.localScale.x, asimoto.y);
        RaycastHit2D hit = Physics2D.CircleCast(p, asimotohankei, Vector2.right, 0);
        if (hit.collider == null)
        {
            p = transform.position + new Vector3((asimoto.x + asimotohankei * 1.5f) * transform.localScale.x, asimoto.y);
            hit = Physics2D.CircleCast(p, asimotohankei, Vector2.right, 0);
            if(hit.collider != null)
            {
              
                hanten();
            }
        }
        
        //敵の移動
        //rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
        //local=親のいる座標を中心座標とした座標
        rigidbody2D.velocity = new Vector2(transform.localScale.x * speed ,
                                                    rigidbody2D.velocity.y);
      
	}
    private void OnCollisionEnter2D(Collision2D other)
    {
        //Tag.Wallと衝突判定が起こったら
        if(other.gameObject.CompareTag("Wall"))
        {
            
            hanten();
        }
    }
    void hanten()
    {
        Vector2 dire = transform.localScale;
        dire.x *= -1;
        transform.localScale = dire;
    }
    /*private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            //向きの反転 -1をかけると反転
            Vector2 dire = transform.localScale;
            dire.x *= -1;
            transform.localScale = dire;
        }
    }*/
    public void setout(bool flag)
    {
        ani.SetBool("out", flag);
    }
}
