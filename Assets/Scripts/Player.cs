using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    float speed = 17f;
    float jump = 17f;
    float lowjump = 500f;
    bool arewinner = true;
    bool stand = true;
    public bool can_i_jump = false;
    public bool move_player = true;
    public Text winner_game;
    public Text lose_game;
    BoxCollider2D m_Collider;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        GameObject[] dangers = GameObject.FindGameObjectsWithTag("lose");
        m_Collider = GetComponent<BoxCollider2D>();

        if (move_player)
        {
            transform.position += new Vector3(speed, 0) * Time.deltaTime;

            if (Input.GetButtonDown("Jump") && can_i_jump)
            {
                rb.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
                can_i_jump = false;
            }

            if (Input.GetButtonDown("Squat"))
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);
            }

            if (Input.GetButton("Squat"))
            {
                //m_Collider.size = new Vector3(0.5f, 0.5f);
                this.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                stand = false;
            }

            if(Input.GetButtonUp("Squat"))
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + 0.5f);
                //m_Collider.size = new Vector3(1f, 1f);
                this.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                stand = true;
            }

            if (!can_i_jump)
            {
                GetComponent<Animator>().SetFloat("jump", 2f);
                Debug.Log("cos");
            }
            else
            {
                GetComponent<Animator>().SetFloat("jump", 1.5f);
            }

        }

        else
        {
            GetComponent<Animator>().SetFloat("jump", 0f);
        }

        if(dangers.Length == 0 && !move_player)
        {
            lose_game.text = "Have you lost something?\nPress 'Space' to restart game!";
        }

        if(!move_player && arewinner)
        {
            winner_game.gameObject.SetActive(true);
            transform.position += new Vector3(speed, 0) * Time.deltaTime;

            if (Input.GetButtonDown("Understand"))
            {
                //SceneManager.LoadScene("Tetris");
            }
        }

        if (!move_player &&  !arewinner)
        {
            lose_game.gameObject.SetActive(true);

            if (Input.GetButtonDown("Understand"))
            {
                SceneManager.LoadScene("Game");
            }
        }
    }
    void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.tag == "floor")
        {
            can_i_jump = true;
        }

        if(col.gameObject.tag == "winner")
        {
            move_player = false;
            arewinner = true;
        }

        if (col.gameObject.tag == "lose")
        {
            move_player = false;
            arewinner = false;
        }
    }
}
