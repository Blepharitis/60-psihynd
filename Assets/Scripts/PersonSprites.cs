using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PersonSprites : MonoBehaviour
{
    [Header("Lyka")]
    [SerializeField] private GameObject[] lykaSprites;
    [SerializeField] private Sprite[] lykaBlinking;
    [SerializeField] private Sprite[] lykaDefault;
    private int thisLyka;

    [Header("Pepper")]
    [SerializeField] private GameObject[] pepperSprites;
    [SerializeField] private Sprite[] pepperBlinking;
    [SerializeField] private Sprite[] pepperDefault;
    private int thisPepper;

    [Header("Demian")]
    [SerializeField] private GameObject[] demianSprites;
    [SerializeField] private Sprite[] demianBlinking;
    [SerializeField] private Sprite[] demianDefault;
    private int thisDemian;

    [Header("Victor")]
    [SerializeField] private GameObject[] victorSprites;
    [SerializeField] private Sprite[] victorBlinking;
    [SerializeField] private Sprite[] victorDefault;
    private int thisVictor;

    private float lykaTime;
    private float pepperTime;
    private float demianTime;
    private float victorTime;

    private void Start()
    {
        lykaTime = Random.Range(1, 5);
        pepperTime = Random.Range(1, 5);
        demianTime = Random.Range(1, 5);
        victorTime = Random.Range(1, 5);
    }

    private void Update()
    {
        // Каждые несколько секунд персонажи моргают
        if(lykaTime <= 0)
        {
            Blinking(1);
        }
        else
        {
            lykaTime -= Time.deltaTime;
        }

        if (pepperTime <= 0)
        {
            Blinking(2);
        }
        else
        {
            pepperTime -= Time.deltaTime;
        }

        if (demianTime <= 0)
        {
            Blinking(3);
        }
        else
        {
            demianTime -= Time.deltaTime;
        }

        if (victorTime <= 0)
        {
            Blinking(4);
        }
        else
        {
            victorTime -= Time.deltaTime;
        }
    }

    private void Blinking(int person)
    {
        lykaTime = Random.Range(1, 5);
        pepperTime = Random.Range(1, 5);
        demianTime = Random.Range(1, 5);
        victorTime = Random.Range(1, 5);
        switch (person)
        {
            case 1:
                lykaSprites[thisLyka].GetComponent<Image>().sprite = lykaBlinking[thisLyka];
                StartCoroutine(ResetBlink(1));
                break;
            case 2:
                pepperSprites[thisPepper].GetComponent<Image>().sprite = pepperBlinking[thisPepper];
                StartCoroutine(ResetBlink(2));
                break;
            case 3:
                demianSprites[thisDemian].GetComponent<Image>().sprite = demianBlinking[thisDemian];
                StartCoroutine(ResetBlink(3));
                break;
            case 4:
                victorSprites[thisVictor].GetComponent<Image>().sprite = victorBlinking[thisVictor];
                StartCoroutine(ResetBlink(4));
                break;
        }
    }

    private IEnumerator ResetBlink(int person)
    {
        yield return new WaitForSeconds(0.5f);
        switch(person)
        {
            case 1:
                lykaSprites[thisLyka].GetComponent<Image>().sprite = lykaDefault[thisLyka];
                break;
            case 2:
                pepperSprites[thisPepper].GetComponent<Image>().sprite = pepperDefault[thisPepper];
                break;
            case 3:
                demianSprites[thisDemian].GetComponent<Image>().sprite = demianDefault[thisDemian];
                break;
            case 4:
                victorSprites[thisVictor].GetComponent<Image>().sprite = victorDefault[thisVictor];
                break;
        }
    }

    public void SetLyka(int spriteID)
    {
        thisLyka = spriteID;
        for(int i = 0; i < lykaSprites.Length; i++)
        {
            if(i == spriteID)
            {
                lykaSprites[i].SetActive(true);
            }
            else
            {
                lykaSprites[i].SetActive(false);
            }
        }
    }

    public void SetPepper(int spriteID)
    {
        thisPepper = spriteID;
        for (int i = 0; i < pepperSprites.Length; i++)
        {
            if (i == spriteID)
            {
                pepperSprites[i].SetActive(true);
            }
            else
            {
                pepperSprites[i].SetActive(false);
            }
        }
    }

    public void SetDemian(int spriteID)
    {
        thisDemian = spriteID;
        for (int i = 0; i < demianSprites.Length; i++)
        {
            if (i == spriteID)
            {
                demianSprites[i].SetActive(true);
            }
            else
            {
                demianSprites[i].SetActive(false);
            }
        }
    }

    public void SetVictor(int spriteID)
    {
        thisVictor = spriteID;
        for (int i = 0; i < victorSprites.Length; i++)
        {
            if (i == spriteID)
            {
                victorSprites[i].SetActive(true);
            }
            else
            {
                victorSprites[i].SetActive(false);
            }
        }
    }

    public void NewDay(Manager manager)
    {
        // Если рассудка меньше 20 ставим эту картинку
        // Лука
        if (!manager.lykaPlayable)
        {
            SetLyka(2);
            thisLyka = 2;
        }
        else
        {
            // Если рассудка больше выбираем на рандом из 2 картинок
            if(Random.Range(0, 100) < 50)
            {
                SetLyka(0);
                thisLyka = 0;
            }
            else
            {
                SetLyka(1);
                thisLyka = 1;
            }
        }

        // Перец
        if (!manager.pepperPlayable)
        {
            SetPepper(2);
            thisPepper = 2;
        }
        else
        {
            if (Random.Range(0, 100) < 50)
            {
                SetPepper(0);
                thisPepper = 0;
            }
            else
            {
                SetPepper(1);
                thisPepper = 1;
            }
        }

        // Демиан
        if (!manager.demianPlayable)
        {
            SetDemian(2);
            thisDemian = 2;
        }
        else
        {
            if (Random.Range(0, 100) < 50)
            {
                SetDemian(0);
                thisDemian = 0;
            }
            else
            {
                SetDemian(1);
                thisDemian = 1;
            }
        }

        // Виктор
        if (!manager.victorPlayable)
        {
            SetVictor(2);
            thisVictor = 2;
        }
        else
        {
            if (Random.Range(0, 100) < 50)
            {
                SetVictor(0);
                thisVictor = 0;
            }
            else
            {
                SetVictor(1);
                thisVictor = 1;
            }
        }

        // Если персонаж мёртв
        if(manager.lykaDead)
        {
            for(int i = 0; i < lykaSprites.Length; i++)
            {
                lykaSprites[i].SetActive(false);
            }
        }
        if (manager.pepperDead)
        {
            for (int i = 0; i < pepperSprites.Length; i++)
            {
                pepperSprites[i].SetActive(false);
            }
        }
        if (manager.demianDead)
        {
            for (int i = 0; i < demianSprites.Length; i++)
            {
                demianSprites[i].SetActive(false);
            }
        }
        if (manager.victorDead)
        {
            for (int i = 0; i < victorSprites.Length; i++)
            {
                victorSprites[i].SetActive(false);
            }
        }
    }
}
