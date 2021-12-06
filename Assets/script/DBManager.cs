using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DBManager : MonoBehaviour
{
    public static DBManager instance=null;
    public List<InputField> login_field;
    public List<InputField> Sign_field;
    public GameObject waiting_menu;
    public InputField Search_field;
    public Text search_result;
    public Text signin_result;
    public string IP = "http://192.168.0.2:9090/";
    public string player1_ID;
    public string player1_name;
    public string player2_ID;
    public string player2_name;
    public Text score;
    public string winner;
    public GameObject error_log;
    // Start is called before the first frame update
    void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void DB_Event(string tmp)
    {

        StartCoroutine(tmp);
    }
    IEnumerator login()
    {
        WWWForm sendform = new WWWForm();
        for (int i = 0; i < login_field.Count; i++)
        {
            if (login_field[i].text.Equals(""))
            {
                Debug.Log("field empty");
                error_log.transform.GetChild(0).GetComponent<Text>().text = "빈칸이 있습니다.";
                error_log.SetActive(true);
            }
        }
        sendform.AddField("PlayerID", login_field[0].text);
        sendform.AddField("PlayerPW", login_field[1].text);
        WWW www = new WWW(IP + "Bomberlogin.php", sendform);
        yield return www;
        string[] tmp = www.text.Split(',');
        if (tmp[1]=="Error")
        {
            Debug.Log("false");
            error_log.transform.GetChild(0).GetComponent<Text>().text = "아이디 또는 비밀번호가 맞지 않습니다.";
            error_log.SetActive(true);
            StopCoroutine("login");
        }
        else
        {
            player1_ID = tmp[1];
            player1_name = tmp[2];
            score.text = "1P보유 점수:"+tmp[3];


        }
        sendform = new WWWForm();
        sendform.AddField("PlayerID", login_field[2].text);
        sendform.AddField("PlayerPW", login_field[3].text);
        www = new WWW(IP + "Bomberlogin.php", sendform);
        yield return www;
        tmp = www.text.Split(',');
        if (tmp[1] == "Error")
        {
            Debug.Log("false");
            error_log.transform.GetChild(0).GetComponent<Text>().text = "아이디 또는 비밀번호가 맞지 않습니다.";
            error_log.SetActive(true);
            StopCoroutine("login");
        }
        else
        {
            player2_ID = tmp[1];
            player2_name = tmp[2];
            score.text+="\n2P보유 점수:"+tmp[3];
            waiting_menu.SetActive(true);
        }
    }
        IEnumerator signin()
    {
        WWWForm sendform = new WWWForm();
        bool empty = false;
        for (int i = 0; i < Sign_field.Count; i++)
        {
            if (Sign_field[i].text.Equals(""))
            {
                Debug.Log("field empty");
                error_log.transform.GetChild(0).GetComponent<Text>().text = "빈칸이 존재합니다.";
                error_log.SetActive(true);
                empty = true;
            }
        }
        if (empty == false)
        {
            sendform.AddField("ID", Sign_field[0].text);
            sendform.AddField("PW", Sign_field[1].text);
            sendform.AddField("NickName", Sign_field[2].text);
            sendform.AddField("Email", Sign_field[3].text);
            WWW www = new WWW(IP + "BomberSignIn.php", sendform);
            yield return www;
            signin_result.text = www.text;
        }
    }
    IEnumerator search_ID()
    {
        WWWForm sendform = new WWWForm();
        if (Search_field.text.Equals(""))
        {
            Debug.Log("field empty");
            yield return null;
        }
        sendform.AddField("Email", Search_field.text);
        WWW www = new WWW(IP + "BomberSearch.php", sendform);
        yield return www;
        string[] tmp = www.text.Split(',');
        if (tmp[1] == "Error")
        {
            search_result.text = "결과:등록된 아이디가 없음";
        }
        else
        {
            search_result.text = "결과:" + tmp[1].ToString();
        }
    }
    public IEnumerator update_score()
    {
        WWWForm sendform = new WWWForm();
        if (winner == "1P")
        {
            sendform.AddField("ID", player1_ID);
        }
        else
        {
            sendform.AddField("ID", player2_ID);
        }
        WWW www = new WWW(IP + "BomberUpdate.php", sendform);
        yield return www;
        SceneManager.LoadScene(0);
        Destroy(this.gameObject);
    }
    public void sceneload()
    {
        SceneManager.LoadScene(1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
