using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCtr : MonoBehaviour
{
    public static PlayerCtr instance;

    private Vector3 clickPosition;
    SpriteRenderer spriterenderer;
    Animator ani;

    void Awake()
    {
        spriterenderer = GetComponentInChildren<SpriteRenderer>();
        ani = GetComponentInChildren<Animator>();
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        
        Vector3 next = transform.position;
        clickPosition = Input.mousePosition;
        // Z軸修正
        clickPosition.z = 10f;

        if (transform.position.x > Camera.main.ScreenToWorldPoint(clickPosition).x)
        {
            spriterenderer.flipX = true;
        }
        else
        {
            spriterenderer.flipX = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    public void setfly(bool flag)
    {
        ani.SetBool("fly", flag);
    }
    public void setfall(bool flag)
    {
        ani.SetBool("fall", flag);
    }
}