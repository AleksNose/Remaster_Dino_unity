using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public GameObject player;
    public Text lose_text;
    bool ending_game = false;

    void Update()
    {
        if(ending_game)
        {
            lose_text.gameObject.SetActive(true);
            if (Input.GetButtonDown("Understand"))
            {
                SceneManager.LoadScene("Game");
            }
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            player.GetComponent<Player>().move_player = false;
            ending_game = true;
        }
    }
}
