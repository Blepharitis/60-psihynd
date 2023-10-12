using UnityEngine;
using UnityEngine.UI;

public class Indicator : MonoBehaviour
{
    [Header("Lyka")]
    [SerializeField] private Image[] lykaImage;
    [SerializeField] private float[] lykaStats;

    [Header("Pepper")]
    [SerializeField] private Image[] pepperImage;
    [SerializeField] private float[] pepperStats;

    [Header("Damian")]
    [SerializeField] private Image[] demianImage;
    [SerializeField] private float[] demianStats;

    [Header("Victor")]
    [SerializeField] private Image[] victorImage;
    [SerializeField] private float[] victorStats;

    [Header("Change In Day")]
    public float[] defaultChanges;
    public float[] changes;

    [Header("Components")]
    [SerializeField] private Animator animator;

    private void Start()
    {
        ChangeStatistics();
    }

    public void ChangeAnimation(int id)
    {
        switch (id)
        {
            case 1:
                animator.SetTrigger("open");
                break;
            case 2:
                animator.SetTrigger("close");
                break;
        }
    }


    public void CloseIndicator()
    {
        gameObject.SetActive(false);
    }

    public void ChangeLyka(float[] changes)
    {
        for(int i = 0;  i < lykaStats.Length; i++)
        {
            if (lykaStats[i] + changes[i] <= 100 && lykaStats[i] + changes[i] >= 0) lykaStats[i] += changes[i];
            else if (lykaStats[i] + changes[i] > 100) lykaStats[i] = 100f;
            else if (lykaStats[i] + changes[i] < 0) lykaStats[i] = 0f;
        }
        ChangeStatistics();
    }

    public void ChangePepper(float[] changes)
    {
        for (int i = 0; i < pepperStats.Length; i++)
        {
            if (pepperStats[i] + changes[i] <= 100 && pepperStats[i] + changes[i] >= 0) pepperStats[i] += changes[i];
            else if (pepperStats[i] + changes[i] > 100) pepperStats[i] = 100f;
            else if (pepperStats[i] + changes[i] < 0) pepperStats[i] = 0f;
        }
        ChangeStatistics();
    }

    public void ChangeDemian(float[] changes)
    {
        for (int i = 0; i < demianStats.Length; i++)
        {
            if (demianStats[i] + changes[i] <= 100 && demianStats[i] + changes[i] >= 0) demianStats[i] += changes[i];
            else if (demianStats[i] + changes[i] > 100) demianStats[i] = 100f;
            else if (demianStats[i] + changes[i] < 0) demianStats[i] = 0f;
        }
        ChangeStatistics();
    }

    public void ChangeVictor(float[] changes)
    {
        for (int i = 0; i < victorStats.Length; i++)
        {
            if (victorStats[i] + changes[i] <= 100 && victorStats[i] + changes[i] >= 0) victorStats[i] += changes[i];
            else if (victorStats[i] + changes[i] > 100) victorStats[i] = 100f;
            else if (victorStats[i] + changes[i] < 0) victorStats[i] = 0f;
        }
        ChangeStatistics();
    }


    public void ChangeStatistics()
    {
        for(int i = 0; i < lykaImage.Length; i++)
        {
            lykaImage[i].fillAmount = lykaStats[i] / 100;
        }

        for (int i = 0; i < pepperImage.Length; i++)
        {
            pepperImage[i].fillAmount = pepperStats[i] / 100;
        }

        for (int i = 0; i < demianImage.Length; i++)
        {
            demianImage[i].fillAmount = demianStats[i] / 100;
        }

        for (int i = 0; i < victorImage.Length; i++)
        {
            victorImage[i].fillAmount = victorStats[i] / 100;
        }
    }

    public void ChangeStat(int person, int number, int amount)
    {
        // Кто будет есть
        switch(person)
        {
            // Ест только Лука
            case 1:
                if (lykaStats[number] + amount <= 100) lykaStats[number] += amount;
                else if (lykaStats[number] + amount > 100) lykaStats[number] = 100f;
                if (lykaStats[number] + amount <= 0) lykaStats[number] = 0f;
                ChangeStatistics();
                break;
            // Ест только Перец
            case 2:
                if (pepperStats[number] + amount <= 100) pepperStats[number] += amount;
                else if (pepperStats[number] + amount > 100) pepperStats[number] = 100f;
                if (pepperStats[number] + amount <= 0) pepperStats[number] = 0f;
                ChangeStatistics();
                break;
            // Ест только Демиан
            case 3:
                if (demianStats[number] + amount <= 100) demianStats[number] += amount;
                else if (demianStats[number] + amount > 100) demianStats[number] = 100f;
                if (demianStats[number] + amount <= 0) demianStats[number] = 0f;
                ChangeStatistics();
                break;
            // Ест только Виктор
            case 4:
                if (victorStats[number] + amount <= 100) victorStats[number] += amount;
                else if (victorStats[number] + amount > 100) victorStats[number] = 100f;
                if (victorStats[number] + amount <= 0) victorStats[number] = 0f;
                ChangeStatistics();
                break;
        }
    }

    public void NewDay(Manager manager)
    {
        // Смена значений за день
        ChangeLyka(changes);
        ChangePepper(changes);
        ChangeDemian(changes);
        ChangeVictor(changes);

        // Если рассудок меньше 0, то персонаж не играбелен
        if (lykaStats[1] <= 0)
        {
            manager.SetPlayable(1);
        }
        if (pepperStats[1] <= 0)
        {
            manager.SetPlayable(2);
        }
        if (demianStats[1] <= 0)
        {
            manager.SetPlayable(3);
        }
        if (victorStats[1] <= 0)
        {
            manager.SetPlayable(4);
        }

        // Если голод меньше 0, то персонаж мёртв
        if (lykaStats[0] <= 0)
        {
            manager.SetDead(1);
        }
        if (pepperStats[0] <= 0)
        {
            manager.SetDead(2);
        }
        if (demianStats[0] <= 0)
        {
            manager.SetDead(3);
        }
        if (victorStats[0] <= 0)
        {
            manager.SetDead(4);
        }
    }
}
