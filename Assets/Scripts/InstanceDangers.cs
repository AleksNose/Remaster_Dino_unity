using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceDangers : MonoBehaviour
{
    float timer = 0f;
    public float maxtime;
    public GameObject graves;
    GameObject newgrave;
    GameObject newbird;
    public GameObject birds;
    int number_random_objects;
    public float max_y;
    public float min_y;
    public GameObject Player;

    void Start()
    {

    }
    void Update()
    {
        if(timer > maxtime && Player.GetComponent<Player>().move_player && transform.position.x < 380f)
        {
            number_random_objects = (int)Random.RandomRange(1f, 2.99f);
            timer = 0f;

            if(number_random_objects == 1)
            {
                newgrave = Instantiate(graves);
                newgrave.transform.position = new Vector2(transform.position.x, 1.07f);
                //Ten bład w kodzie jest zamierzony 
                Destroy(newgrave, 10f);
            }

            if (number_random_objects == 2)
            {
                newbird = Instantiate(birds);
                newbird.transform.position = new Vector2(transform.position.x, Random.RandomRange(min_y, max_y));
                //Ten bład w kodzie jest zamierzony 
                Destroy(newbird, 10f);
            }
        }
        timer += Time.deltaTime;
    }
}
