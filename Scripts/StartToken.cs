using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartToken : MonoBehaviour
{
    public Startmanager manager;
    public Rigidbody2D rigid;
    Animator anim;
    CircleCollider2D circleCollider;
    SpriteRenderer renderer;
    public bool isDrag;
    public int level;
    public ParticleSystem particle;

    int[] score = { 1, 3, 6, 10, 15, 21, 28, 36, 45, 55, 66 };

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
        isMerge = false;

        transform.localPosition = Vector3.zero;
        Vector3 Pos = new Vector3(Random.Range(-2.38f, 2.38f), 0, 0);
        transform.localPosition += Pos;
        float leftBorder = -2.38f + transform.localScale.x / 2f;
        float rightBorder = 2.38f - transform.localScale.x / 2f;

        if (Pos.x < leftBorder)
            Pos.x = leftBorder;
        else if (Pos.x > rightBorder)
            Pos.x = rightBorder;

        transform.localRotation = Quaternion.identity;
        transform.localScale = Vector3.zero;

        rigid.simulated = false;
        rigid.velocity = Vector2.zero;
        rigid.angularVelocity = 0;
        circleCollider.enabled = true;
    }
    // Update is called once per frame
    public void Drop()
    {
        rigid.simulated = true;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Token")
        {
            StartToken other = collision.gameObject.GetComponent<StartToken>();
            if(level == other.level && !isMerge && !other.isMerge && level<11)
            {
                float myX = transform.position.x;
                float myY = transform.position.y;
                float otherX = other.transform.position.x;
                float otherY = other.transform.position.y;

                if(myY<otherY||(myY==otherY&&myX>otherX))
                {
                    other.Hide(transform.position);
                    LevelUp();
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
        ParticlePlay();
        yield return new WaitForSeconds(0.3f);
        level++;
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
        if (collision.tag == "Finish")
            DeadTime += Time.deltaTime;

        if (DeadTime > 5)
            manager.Stop();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Finish")
        {
            DeadTime = 0;
        }
    }
}
