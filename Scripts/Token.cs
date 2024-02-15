using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{
    public Gamemanager manager;
    public Rigidbody2D rigid;
    Animator anim;
    CircleCollider2D circleCollider;
    SpriteRenderer renderer;
    public bool isDrag;
    public int level;
    public ParticleSystem particle;

    int[] score = { 1, 3, 6, 10, 15, 21, 28, 36, 45, 55, 66, 77 };

    public bool isMerge;

    float DeadTime;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        circleCollider = GetComponent<CircleCollider2D>();
        renderer = GetComponent<SpriteRenderer>();
    }
    void OnEnable()
    {
        anim.SetInteger("Level", level);
    }
    private void OnDisable()
    {
        level = 0;
        isDrag = false;
        isMerge = false;

        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        transform.localScale = Vector3.zero;

        rigid.simulated = false;
        rigid.velocity = Vector2.zero;
        rigid.angularVelocity = 0;
        circleCollider.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (isDrag)
            Move();
    }
    private void Move()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float leftBorder = -2.38f + transform.localScale.x / 2f;
        float rightBorder = 2.38f - transform.localScale.x / 2f;

        if (mousePos.x < leftBorder)
            mousePos.x = leftBorder;
        else if (mousePos.x > rightBorder)
            mousePos.x = rightBorder;

        mousePos.y = 4;
        mousePos.z = 0;
        transform.position = Vector3.Lerp(transform.position, mousePos, 0.2f);
    }
    public void Drag()
    {
        isDrag = true;
    }
    public void Drop()
    {
        isDrag = false;
        rigid.simulated = true;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Token")
        {
            Token other = collision.gameObject.GetComponent<Token>();
            if(level == other.level && !isMerge && !other.isMerge )
            {
                float myX = transform.position.x;
                float myY = transform.position.y;
                float otherX = other.transform.position.x;
                float otherY = other.transform.position.y;

                if(myY<otherY||(myY==otherY&&myX>otherX))
                {
                    if (level >= 11)
                    {
                        other.Hide(transform.position);
                        Hide(transform.position);
                        Soundmanager.instance.Playfirst(0);
                        ParticlePlay();
                    }
                    else
                    {
                        other.Hide(transform.position);
                        LevelUp();
                    }
                }
            }
        }
    }
    public void Hide(Vector3 targetPos)
    {
        isMerge = true;
        rigid.simulated = false;
        circleCollider.enabled = false;
        if (targetPos == Vector3.up * 100)
            ParticlePlay();
        StartCoroutine(HideRoutine(targetPos));
    }
    IEnumerator HideRoutine(Vector3 targetPos)
    {
        int frameCnt = 0;
        while(frameCnt < 20)
        {
            frameCnt++;
            if (targetPos != Vector3.up * 100)
                transform.position = Vector3.Lerp(transform.position, targetPos, 0.5f);
            else if (targetPos == Vector3.up * 100)
                transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, 0.2f);
            yield return null;
        }
        manager.score += score[level];
        isMerge = false;
        gameObject.SetActive(false);
    }
    void LevelUp()
    {
        isMerge = true;
        rigid.velocity = Vector2.zero;
        rigid.angularVelocity = 0;
        StartCoroutine(LevelUpRoution());
    }
    IEnumerator LevelUpRoution()
    {
        yield return new WaitForSeconds(0.2f);

        anim.SetInteger("Level", level + 1);
        Soundmanager.instance.Playfirst(0);
        ParticlePlay();
        yield return new WaitForSeconds(0.3f);
        level++;
        manager.MaxLevel = Mathf.Max(level, manager.MaxLevel);
        isMerge = false;
    }
    void ParticlePlay()
    {
        particle.transform.position = transform.position;
        particle.transform.localScale = transform.localScale;
        particle.Play();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Finish")   
            DeadTime += Time.deltaTime;

        if (DeadTime > 2)
            renderer.color = Color.red;

        if (DeadTime > 5)
            manager.GameOver();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Finish")
        {
            DeadTime = 0;
            renderer.color = Color.white;
        }
    }
}
