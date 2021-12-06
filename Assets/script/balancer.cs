using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class balancer : MonoBehaviour
{
    public List<GameObject> items;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(this.drop_item());
    }

    IEnumerator drop_item()
    {
        yield return new WaitForSeconds(Random.Range(5, 10));
        Instantiate(items[Random.Range(0, items.Count)], new Vector3(Random.Range(-3,3),Random.Range(-4,4),0), Quaternion.identity);
        StartCoroutine(this.drop_item());
    }
    // Update is called once per frame
    
    public void send_data(Text tmp)
    {
        string[] str = tmp.text.Split(' ');
        DBManager.instance.winner = str[0];
        StartCoroutine(DBManager.instance.update_score());
        
    }
}
