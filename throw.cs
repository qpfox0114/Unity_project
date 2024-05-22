using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public float duration; // ����ɶ��A�Ω��ĤH�y���ĪG
    public float DisappearTime; // �����ɶ��A����b�Ӯɶ���P��
    public Vector2 startSpeed; // ��l�t�סA�Ω�]�w�ߪ����t�שM��V
    public Transform target; // �ؼС]���a�^�� Transform �ե�
    private Rigidbody2D rb2d; // ���󪺭���ե�

    void Start()
    {
        // ������a�� Transform �ե�
        target = GameObject.FindGameObjectWithTag("Player").transform;
        // ������󪺭���ե�
        rb2d = GetComponent<Rigidbody2D>();
        // �]�w��l�t�שM��V
        if (target.localScale.x > 0)
        {
            // �p�G�ؼЪ� x �b�Y��j�� 0�A�]�m����V�k�W�貾��
            rb2d.velocity = transform.up * startSpeed.y + transform.right * (startSpeed.x + target.localScale.x);
        }
        else
        {
            // �p�G�ؼЪ� x �b�Y��p�� 0�A�]�m����V���W�貾��
            rb2d.velocity = transform.up * startSpeed.y - transform.right * (startSpeed.x - target.localScale.x);
        }
        // �b���w�ɶ���P������
        Invoke("DestroyThisItem", DisappearTime);
    }

    void Update()
    {

    }

    // ����i�J2D�I��Ĳ�o���ɽեΦ���k
    void OnTriggerEnter2D(Collider2D other)
    {
        // �ˬd�I����H�O�_�� "Enemy" ����
        if (other.gameObject.CompareTag("Enemy"))
        {
            // ��ĤH�y���ˮ`�èϨ����ĪG
            other.GetComponent<Enemy>().TakeDamage(duration);
        }
    }

    // �P�����󪺤�k
    void DestroyThisItem()
    {
        // �P����e����
        Destroy(gameObject);
    }
}
