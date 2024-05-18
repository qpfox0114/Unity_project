using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int score;
    public int blinks;
    public float time;
    private Renderer myRender;

    // Start is called before the first frame update
    void Start()
    {
        myRender = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DamegePlayer(int damage)
    {
        score -= damage;
        if (score <= 0)
        {
            score = 0;
        }
        BlinkPlayer(blinks, time);
    }

    void BlinkPlayer(int numBlinks, float seconds)
    {
        StartCoroutine(DoBlinks(numBlinks, seconds));
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