using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Notebook : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Animator animator;

    [Header("EventTypes")]
    public int eventType;

    [Header("EventType1")]
    [SerializeField] private GameObject togglesParent1;
    [SerializeField] private Toggle[] togglesType1;

    [Header("EventType2")]
    [SerializeField] private GameObject togglesParent2;
    [SerializeField] private Toggle toggleType2;

    [Header("Text and page")]
    [SerializeField] private int selectedPage;

    [SerializeField] private string page1Text;
    [SerializeField] private string page2Text;
    [SerializeField] private Text noteText;
    [SerializeField] private Text dayText;

    [SerializeField] private GameObject rightArrow;
    [SerializeField] private GameObject leftArrow;

    // ������� ��������
    public void ChangePage(bool isNext)
    {
        if(isNext && selectedPage + 1 < 4)
        {
            selectedPage++;
        }
        else if(!isNext && selectedPage - 1 > 0)
        {
            selectedPage--;
        }

        ChangeText();
    }

    // ����� ������ ������ �� ����� �� ������ ��������
    public void ChangeText()
    {
        switch(selectedPage)
        {
            case 1:
                noteText.text = page1Text;

                leftArrow.SetActive(false);
                rightArrow.SetActive(true);
                togglesParent1.SetActive(false);
                togglesParent2.SetActive(false);
                break;
            case 2:
                noteText.text = page2Text;

                leftArrow.SetActive(true);
                rightArrow.SetActive(true);
                togglesParent1.SetActive(false);
                togglesParent2.SetActive(false);
                break;
            case 3:
                switch(eventType)
                {
                    case 1:
                        togglesParent1.SetActive(true);
                        togglesParent2.SetActive(false);
                        break;
                    case 2:
                        togglesParent1.SetActive(false);
                        togglesParent2.SetActive(true);
                        break;
                }
                noteText.text = "";

                leftArrow.SetActive(true);
                rightArrow.SetActive(false);
                break;
        }
    }

    // �������� ����� ������� ����� �� ���������
    public void ChangePageText(string page1, string page2)
    {
        page1Text = page1;
        page2Text = page2;
        ChangeText();
    }

    public void AddText(string text)
    {
        page1Text += text;
    }

    // �������� ������� ����� ������ ����
    public IEnumerator NextDay(int day)
    {
        yield return new WaitForSeconds(4);
        dayText.text = "���� " + day.ToString();
        selectedPage = 1;

        for(int i = 0; i < togglesType1.Length; i++)
        {
            togglesType1[i].isOn = false;
        }
        toggleType2.isOn = false;
        ChangeText();
    }

    // �������� ��������
    public void ChangeAnimation(int id)
    {
        switch(id)
        {
            case 1:
                animator.SetTrigger("open");
                FMODUnity.RuntimeManager.PlayOneShot("event:/Openboook"); //���� �������� � �������� ���������

                break;
            case 2:
                animator.SetTrigger("close");
                FMODUnity.RuntimeManager.PlayOneShot("event:/Openboook");
                break;
        }
    }

    // ������� ��������
    public void CloseNoteBook()
    {
        gameObject.SetActive(false);
    }

    // ������ ����� ��� ������ � �������� �� 3 �������� ������ ������
    public void ActiveType(int type)
    {
        eventType = type;
    }

    // �������� ������ � 1 ���� ������
    public int GetType1()
    {
        for(int i = 0; i < togglesType1.Length; i++)
        {
            if(togglesType1[i].GetComponent<Toggle>().isOn)
            {
                return i + 1;
            }
        }
        return 0;
    }

    // �������� ������ � 2 ���� ������
    public bool GetType2()
    {
        return toggleType2.GetComponent<Toggle>().isOn;
    }
}
