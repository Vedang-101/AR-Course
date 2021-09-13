using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    public Attributes player;

    public GameObject target;
    public GameObject burst;

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Animator>().SetBool("Dead", true);
        other.tag = "dead";
        player.attacked = false;
        player.gameObject.GetComponent<Collider>().enabled = true;
        GameObject a = Instantiate(burst, transform.position, transform.rotation);
        Destroy(a, 2);
        Destroy(gameObject);
    }

    public void play()
    {
        StartCoroutine(chase());
    }

    public IEnumerator chase() {
        while(true)
        {
            yield return new WaitForSeconds(0.01f);
            if (transform.position == target.transform.position)
                break;
            else
            {
                transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * 5);
            }
        }
    }
}
