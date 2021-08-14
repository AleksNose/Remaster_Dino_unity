using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject Player;
    public float distance;
    void FixedUpdate()
    {
        if (Player.GetComponent<Player>().move_player)
        {
            this.transform.position = new Vector3(Player.transform.position.x + distance, this.transform.position.y, -10);
        }
    }
}
