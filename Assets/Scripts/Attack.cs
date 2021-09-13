using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public DefaultTrackableEventHandler[] dteh;
    public GameObject[] players;
    public GameObject[] playerhands;
    public GameObject flames;

    public int time = 5;

    void Update()
    {
        GameObject player1 = null;
        GameObject player2 = null;


        GameObject hand1 = null;
        GameObject hand2 = null;

        for (int i = 0; i < dteh.Length; i++)
        {
            if (dteh[i].Tracked == true && players[i].tag != "dead")
            {
                if (player1 == null)
                {
                    player1 = players[i];
                    hand1 = playerhands[i];
                }
                else if (player2 == null)
                {
                    player2 = players[i];
                    hand2 = playerhands[i];
                }
            }
        }
        if(player2 != null)
        {
            player1.transform.LookAt(player2.transform,player1.transform.up);
            player2.transform.LookAt(player1.transform, player2.transform.up);
            Attributes p1 = player1.GetComponent<Attributes>();
            Attributes p2 = player2.GetComponent<Attributes>();
            if(((p1.health+p1.mana)/200.0f > (p2.health+p2.mana)/200.0f) && p1.attacked == false)
            {
                p1.attacked = true;
                player1.GetComponent<Animator>().SetTrigger("Attack");
                p1.gameObject.GetComponent<Collider>().enabled = false;
                hand1.SetActive(true);
                StartCoroutine(waitforsecods(hand1,p1,player2));
            }
            else if(((p1.health + p1.mana) / 200.0f < (p2.health + p2.mana) / 200.0f) && p2.attacked == false)
            {
                p2.attacked = true;
                player2.GetComponent<Animator>().SetTrigger("Attack");
                p2.gameObject.GetComponent<Collider>().enabled = false;
                hand2.SetActive(true);
                StartCoroutine(waitforsecods(hand2,p2,player1));
            }
        }
    }

    IEnumerator waitforsecods(GameObject hand, Attributes p, GameObject player)
    {
        yield return new WaitForSeconds(time);
        hand.SetActive(false);
        GameObject flame = Instantiate(flames, hand.transform.position, hand.transform.rotation);
        flame.GetComponent<Flame>().target = player;
        flame.GetComponent<Flame>().player = p;
        flame.GetComponent<Flame>().play();

    }
}
