using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public static int score;
    public int blinks;
    public float time;
    public float cd;
    private Renderer myRender;
    private screenflash sf;
    private CapsuleCollider2D cc2d;
    [SerializeField] private Text textscore;

    void Start()
    {
        score = 100;
        myRender = GetComponent<Renderer>();
        sf = GetComponent<screenflash>();
        cc2d = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {

    }

    public void DamegePlayer(int damage)
    {
        sf.FlashScreen();
        score -= damage;
        if (score <= 0)
        {
            score = 0;
        }
        BlinkPlayer(blinks, time);
        cc2d.enabled = false;
        StartCoroutine(InvincibleTime());
        textscore.text = "" + score;
    }

    void BlinkPlayer(int numBlinks, float seconds)
    {
        StartCoroutine(DoBlinks(numBlinks, seconds));
    }

    IEnumerator InvincibleTime()
    {
        yield return new WaitForSeconds(cd);
        cc2d.enabled = true;
    }
    IEnumerator DoBlinks(int numBlinks, float seconds)
    {
        for (int i = 0; i < numBlinks * 2; i++)
        {
            myRender.enabled = !myRender.enabled;
            yield return new WaitForSeconds(seconds);
        }
        myRender.enabled = true;
    }
}