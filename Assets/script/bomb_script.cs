using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class bomb_script : MonoBehaviour
{
    public GameObject explode;
    int bomb_range=2;
    IEnumerator Start()
    {
        
        this.transform.position=new Vector3(Mathf.Round(this.transform.position.x), Mathf.Round( this.transform.position.y),0);
        yield return new WaitForSeconds(2.5f);
        bomb_range = int.Parse(this.gameObject.name.Replace("(Clone)", string.Empty));
        Instantiate(explode, this.transform.position + new Vector3(0, 0, 0), Quaternion.identity);
        for (int i = 1; i <= bomb_range; i++)
        {
            Instantiate(explode, this.transform.position + new Vector3(0, i, 0), Quaternion.identity);
            Instantiate(explode, this.transform.position + new Vector3(0, -i, 0), Quaternion.identity);
            Instantiate(explode, this.transform.position + new Vector3(i, 0, 0), Quaternion.identity);
            Instantiate(explode, this.transform.position + new Vector3(-i, 0, 0), Quaternion.identity);
        }
        Destroy(this.gameObject);
    }

}
