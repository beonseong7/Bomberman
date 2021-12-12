using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;

namespace Tests
{
    

    public class NewTestScript
    {
        public GameObject error_log;
        public Text signin_result;
        public string IP;
        public List<InputField> login_field;
        public List<InputField> Sign_field;
        [UnityTest]
        public IEnumerator Move_Test()
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
    }
}
