using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_script : MonoBehaviour
{
    public float speed;
    public GameObject Bomb;
    int Bomb_Count=1;
    int Bomb_range=1;
    public GameObject btn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = Vector2.zero;
        if (this.gameObject.name == "1P")
        {
            if (Input.GetKey(KeyCode.D))
            {
                move += Vector2.right;
            }
            if (Input.GetKey(KeyCode.A))
            {
                move += Vector2.left;
            }
            if (Input.GetKey(KeyCode.S))
            {
                move += Vector2.down;
            }
            if (Input.GetKey(KeyCode.W))
            {
                move += Vector2.up;
            }
            if (Input.GetKeyDown(KeyCode.Space) && Bomb_Count>0)
            {
                GameObject tmp= Instantiate(Bomb, this.transform.position, Quaternion.identity);
                tmp.gameObject.name = Bomb_range.ToString();
                Bomb_Count--;
                StartCoroutine(this.Bomb_colldown());
            }
        }
        else if (this.gameObject.name == "2P")
        {
            if (Input.GetKey(KeyCode.Keypad6))
            {
                move += Vector2.right;
            }
            if (Input.GetKey(KeyCode.Keypad4))
            {
                move += Vector2.left;
            }
            if (Input.GetKey(KeyCode.Keypad5))
            {
                move += Vector2.down;
            }
            if (Input.GetKey(KeyCode.Keypad8))
            {
                move += Vector2.up;
            }
            if (Input.GetKeyDown(KeyCode.RightShift) && Bomb_Count > 0)
            {
                GameObject tmp = Instantiate(Bomb, this.transform.position, Quaternion.identity);
                tmp.gameObject.name = Bomb_range.ToString();
                Bomb_Count--;
                StartCoroutine(this.Bomb_colldown());
            }
        }
        this.transform.Translate(move * Time.deltaTime * speed);
    }
    IEnumerator Bomb_colldown()
    {
        yield return new WaitForSeconds(2.51f);
        Bomb_Count++;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "explode")
        {
            btn.SetActive(true);
            if (this.gameObject.name == "1P")
            {
                btn.transform.GetChild(0).GetComponent<Text>().text = "2P 승리!";
            }
            else
            {
                btn.transform.GetChild(0).GetComponent<Text>().text = "1P 승리!";
            }
            Time.timeScale = 0f;
        }
        else if(collision.gameObject.tag == "plus")
        {
            Bomb_Count++;
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "gas")
        {
            Bomb_range++;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "speed")
        {
            speed += 0.4f;
            Destroy(collision.gameObject);
        }
        
    }
}
