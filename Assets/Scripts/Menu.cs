using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button buttonSettings;
    [SerializeField] private Button buttonPlay;
    [SerializeField] private Button buttonExit;

    [SerializeField] private GameObject openSettings;
    [SerializeField] private GameObject openPlay;

    [SerializeField] private Animator animatorSettings;
    [SerializeField] private Animator animatorPlay;

    private void Start()
    {
        animatorSettings = openSettings.GetComponent<Animator>();
        animatorPlay = openPlay.GetComponent<Animator>();
    }

    public void ClickOpen(int button)
    {
        switch(button)
        {
            case 1:
                ButtonInteractable(false);
                openSettings.SetActive(false);
                openPlay.SetActive(true);
                animatorPlay.SetTrigger("open");
                StartCoroutine(SetTrueButtons());
                break;
            case 2:
                ButtonInteractable(false);
                openSettings.SetActive(true);
                openPlay.SetActive(false);
                animatorSettings.SetTrigger("open");
                StartCoroutine(SetTrueButtons());
                break;
        }
    }
    
    public void ButtonInteractable(bool active)
    {
        for (int i = 0; i < openPlay.transform.childCount; i++)
        {
            openPlay.transform.GetChild(i).GetComponent<Button>().interactable = active;
        }
        for (int i = 0; i < openSettings.transform.childCount; i++)
        {
            openSettings.transform.GetChild(i).GetComponent<Button>().interactable = active;
        }
        buttonSettings.interactable = active;
        buttonPlay.interactable = active;
        buttonExit.interactable = active;
    }

    public void Back(int button)
    {
        switch(button)
        {
            case 1:
                ButtonInteractable(false);
                animatorPlay.SetTrigger("close");
                StartCoroutine(Close(1));
                break;
            case 2:
                ButtonInteractable(false);
                animatorSettings.SetTrigger("close");
                StartCoroutine(Close(2));
                break;
        }
    }

    IEnumerator SetTrueButtons()
    {
        yield return new WaitForSeconds(1f);
        ButtonInteractable(true);
    }

    IEnumerator Close(int button)
    {
        yield return new WaitForSeconds(1f);
        switch (button)
        {
            case 1:
                openPlay.SetActive(false);
                ButtonInteractable(true);
                break;
            case 2:
                openSettings.SetActive(false);
                ButtonInteractable(true);
                break;
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void Exit()
    {
        
    }
}
