using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            this.disappear();
        }
    }
    public void disappear()
    {
        Destroy(this.transform.parent.gameObject);
    }
}
