using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShowData : MonoBehaviour
{

    [SerializeField]
    Button m_userButton;
    [SerializeField]
    public Text m_name;
    [SerializeField]
    public Text m_marry;
    [SerializeField]
    public Text m_address;    
    [SerializeField]
    public Text m_age;
    [SerializeField]
    public Text m_job;
    [SerializeField]
    Toggle m_selectObj;

    bool m_isMarried;



    //user���� �����ֱ�
    public void SetUserData(int idx)
    {
        var user = UserData.Instance.UserList[idx];
        string marry;
        if (user.m_marry)
        {
            m_isMarried = true;
            marry = "��ȥ";
        }
        else
        {
            m_isMarried = false;
            marry = "��ȥ";
        }


        m_name.text = user.m_name;        
        m_marry.text = marry;
        m_address.text = user.m_address;
        m_age.text = user.m_age.ToString();      
        m_job.text = user.m_job.ToString();

    }

    //���� ���� ����
    public void SelectUserData(bool value)
    {       
        if(value)
        {
            UserData.Instance.GetObj(gameObject,m_name.text);
            
        }        
    }

    private void Start()
    {
        m_selectObj.isOn = false;     
        m_selectObj.onValueChanged.AddListener(SelectUserData);
    }
    

}

