using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{

    static PopupManager m_instance;

    public static PopupManager Instance
    {
        get
        {
            if (m_instance == null)
                m_instance = FindObjectOfType<PopupManager>();

            return m_instance;

        }

    }


    [SerializeField]
    GameObject m_essentialPanel;
    [SerializeField]
    Text m_checkText;
    [SerializeField]
    GameObject m_deletePanel;
    [SerializeField]
    Text m_deleteText;
    [SerializeField]
    GameObject m_deleteAllPanel;
    [SerializeField]
    Text m_deleteAllText;
    [SerializeField]
    GameObject m_findPanel;
    [SerializeField]
    InputField m_findName;
    [SerializeField]
    Text m_editText;
    [SerializeField]
    GameObject m_userEditor;
    [SerializeField]
    Text m_editorTitle;
    [SerializeField]
    GameObject m_mainpanel;


    public void UserEditorPop()
    {
       
        if (UIManager.Instance.IsAdd == true)
        {
            m_editorTitle.text = "ȸ���߰�";            
        }
        else if(UIManager.Instance.IsAdd == false)
        {
            m_editorTitle.text = "ȸ������";           
        }
        m_mainpanel.SetActive(false);
        m_userEditor.SetActive(true);
    }
    public void OnOk_Editor()
    {
        if (UIManager.Instance.IsAdd == true)
        {
            EssentialPop();
        }
        else
        {
            
            UserData.Instance.EditUser();
            m_mainpanel.SetActive(true);
            m_userEditor.SetActive(false);
        }
    }

    public void EssentialPop()
    {
        if (UIManager.Instance.EssentialCheck())
        {
            if (UserData.Instance.NameCheck)
            {
                UserData.Instance.AddUser();
                UIManager.Instance.InitData();
                m_userEditor.SetActive(false);
                m_mainpanel.SetActive(true);
            }
            else
            {
                m_checkText.text = "�ߺ�Ȯ���� ���ּ���.";
                m_essentialPanel.SetActive(true);
            }
        }
        else
        {
            m_checkText.text = "�ʼ��׸��� Ȯ�����ּ���.";
            m_essentialPanel.SetActive(true);
        }
    }
    public void OnOk_Eseential()
    {
        m_essentialPanel.SetActive(false);       
    }

    public void DeletePop()
    {
        m_deleteText.text = "�ش� ������ �����Ͻðڽ��ϱ�?";
        m_deletePanel.SetActive(true);
    }
    public void OnDeleteOk()
    {
        UserData.Instance.DeleteUser();
        m_deletePanel.SetActive(false);
    }
    public void OnCancel()
    {
        m_deletePanel.SetActive(false);
        m_deleteAllPanel.SetActive(false);
    }
    public void DeleteAllPop()
    {
        m_deleteAllText.text = "������ ��� �����Ͻðڽ��ϱ�?";
        m_deleteAllPanel.SetActive(true);
    }
    public void OnDeleteAllOk()
    {
        UserData.Instance.DeleteAllUser();
        m_deleteAllPanel.SetActive(false);
    }
    public void FindPop()
    {
        if(UserData.Instance.UserList != null) 
        {
            m_findPanel.SetActive(true);
            m_editText.text = "������ ȸ���̸��� �����ּ���";
        }
    }
    public void OnFindOk()
    {
        UserData.Instance.SetUserData(m_findName.text);
        m_findPanel.SetActive(false);
        UserEditorPop();
        m_findName.text = "";
    }
    private void Start()
    {
        m_mainpanel.SetActive(true);
        m_userEditor.SetActive(false);
    }
}
