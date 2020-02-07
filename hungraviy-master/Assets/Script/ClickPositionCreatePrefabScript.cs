using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClickPositionCreatePrefabScript : MonoBehaviour
{
    public static ClickPositionCreatePrefabScript Instance;
    public static bool Isactive = false;
    // クリックした位置座標
    private Vector3 clickPosition;
    // Use this for initialization
    Animator animator;
    Slider _slider;
    // Update is called once per frame
    Transform enemy;
void Awake()
    {
        Instance = this; 
    }
    void Start()
    {
        // スライダーを取得する
        _slider = GameObject.Find("Slider").GetComponent<Slider>();
        animator = GetComponent<Animator>();
    }

    float _hp = 1;
    void Update()
    {
        if (!GameManager.CanMove)
        {
            return;
        }
        if (Input.GetMouseButton(0) && _hp>=0)
        {
            _hp -= 0.02f;
            PlayerCtr.instance.setfly(true);
            PlayerCtr.instance.setfall(false);
        }
        if (Input.GetMouseButton(0) == false || _hp <= 0)
        {
            RaycastHit2D hit;
            hit = Physics2D.Raycast(PlayerCtr.instance.transform.position, Vector2.down, 1.5f, LayerMask.GetMask("map"));
            if (hit.collider)
            {
                PlayerCtr.instance.setfall(false);
            }
            else
            {
                PlayerCtr.instance.setfall(true);
            }
            PlayerCtr.instance.setfly(false);
            if (_hp < 1)
            {
                _hp += 0.005f;
            }
        }

        // マウス入力で左クリックをしてるとき
        if (Input.GetMouseButtonDown(0) && _hp > 0)
        {
            // ここでの注意点は座標の引数にVector2を渡すのではなく、Vector3を渡すことである。
            // Vector3でマウスがクリックした位置座標を取得する
            clickPosition = Input.mousePosition;
            // Z軸修正
            clickPosition.z = 10f;
            // オブジェクト生成 : オブジェクト(GameObject), 位置(Vector3), 角度(Quaternion)
            // ScreenToWorldPoint(位置(Vector3))：スクリーン座標をワールド座標に変換する
            transform.position= Camera.main.ScreenToWorldPoint(clickPosition);
            animator.SetBool("spawn",true);
            Isactive = true;
        }
        
        if (Input.GetMouseButtonUp(0) || _hp <= 0)
        {
            animator.SetBool("spawn", false);
            Isactive = false;
        }
        
        // HPゲージに値を設定
        _slider.value = _hp;
    }
}