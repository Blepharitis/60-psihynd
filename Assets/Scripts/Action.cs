using UnityEngine;
using UnityEngine.UI;

public class Action : MonoBehaviour
{
    [Header("Lyka")]
    [SerializeField] private Toggle[] lykaToggles;
    [SerializeField] private Toggle lykaEatToggle;
    [SerializeField] private bool isLykaEat;
    [SerializeField] private int lykaAction;

    [Header("Pepper")]
    [SerializeField] private Toggle[] pepperToggles;
    [SerializeField] private Toggle pepperEatToggle;
    [SerializeField] private bool isPepperEat;
    [SerializeField] private int pepperAction;

    [Header("Demian")]
    [SerializeField] private Toggle[] demianToggles;
    [SerializeField] private Toggle demianEatToggle;
    [SerializeField] private bool isDemianEat;
    [SerializeField] private int demianAction;

    [Header("Lyka")]
    [SerializeField] private Toggle[] victorToggles;
    [SerializeField] private Toggle victorEatToggle;
    [SerializeField] private bool isVictorEat;
    [SerializeField] private int victorAction;

    [Header("No Stack Actions")]
    [SerializeField] private Toggle[] toggleLooting;
    [SerializeField] private Toggle[] toggleTV;
    [SerializeField] private Toggle[] toggleDining;
    [SerializeField] private Toggle[] toggleRead;
    [SerializeField] private Toggle[] toggleCabinet;


    [Header("Components")]
    [SerializeField] private Animator animator;

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

    public void CloseActions()
    {
        gameObject.SetActive(false);
    }

    public void CheckAction(Manager manager)
    {
        // Едят ли персонажи
        isLykaEat = lykaEatToggle.isOn;
        isPepperEat = pepperEatToggle.isOn;
        isDemianEat = demianEatToggle.isOn;
        isVictorEat = victorEatToggle.isOn;

        // Если персонажи едят
        if (isLykaEat && manager.lykaPlayable) manager.ActionEat(1);
        if (isPepperEat && manager.pepperPlayable) manager.ActionEat(2);
        if (isDemianEat && manager.demianPlayable) manager.ActionEat(3);
        if (isVictorEat && manager.victorPlayable) manager.ActionEat(4);

        // Проверка других действий
        for(int i = 0; i < lykaToggles.Length; i++)
        {
            if (lykaToggles[i].isOn && manager.lykaPlayable)
            {
                lykaAction = i + 1;
                manager.OtherAction(1, lykaAction);
            }
        }
        for (int i = 0; i < pepperToggles.Length; i++)
        {
            if (pepperToggles[i].isOn && manager.pepperPlayable)
            {
                pepperAction = i + 1;
                manager.OtherAction(2, pepperAction);
            }
        }
        for (int i = 0; i < demianToggles.Length; i++)
        {
            if (demianToggles[i].isOn && manager.demianPlayable)
            {
                demianAction = i + 1;
                manager.OtherAction(3, demianAction);
            }
        }
        for (int i = 0; i < victorToggles.Length; i++)
        {
            if (victorToggles[i].isOn && manager.victorPlayable)
            {
                victorAction = i + 1;
                manager.OtherAction(4, victorAction);
            }
        }

        // Обнуление галочек действий 
        for (int i = 0; i < lykaToggles.Length; i++)
        {
            lykaToggles[i].isOn = false;
        }
        for (int i = 0; i < pepperToggles.Length; i++)
        {
            pepperToggles[i].isOn = false;
        }
        for (int i = 0; i < demianToggles.Length; i++)
        {
            demianToggles[i].isOn = false;
        }
        for (int i = 0; i < victorToggles.Length; i++)
        {
            victorToggles[i].isOn = false;
        }

        lykaEatToggle.isOn = false;
        pepperEatToggle.isOn = false;
        demianEatToggle.isOn = false;
        victorEatToggle.isOn = false;

        isLykaEat = false;
        isPepperEat = false;
        isDemianEat = false;
        isVictorEat = false;

        lykaAction = 0;
        pepperAction = 0;
        demianAction = 0;
        victorAction = 0;
    }

    public void ToggleTVChanged(Toggle toggle)
    {
        if(toggle.isOn)
        {
            for(int i = 0; i < toggleTV.Length; i++)
            {
                if (toggleTV[i].isOn && toggleTV[i] != toggle)
                {
                    toggleTV[i].isOn = false;
                }
            }
        }
    }

    public void ToggleLootingChanged(Toggle toggle)
    {
        if (toggle.isOn)
        {
            for (int i = 0; i < toggleTV.Length; i++)
            {
                if (toggleLooting[i].isOn && toggleLooting[i] != toggle)
                {
                    toggleLooting[i].isOn = false;
                }
            }
        }
    }

    public void ToggleDiningChanged(Toggle toggle)
    { 
        if(toggle.isOn)
        {
            for(int i = 0; i < toggleDining.Length; i++)
            {
                if (toggleDining[i].isOn && toggleDining[i] != toggle)
                {
                    toggleDining[i].isOn = false;
                }
            }
        }
    }

    public void ToggleReadChanged(Toggle toggle)
    {
        if (toggle.isOn)
        {
            for (int i = 0; i < toggleRead.Length; i++)
            {
                if (toggleRead[i].isOn && toggleRead[i] != toggle)
                {
                    toggleRead[i].isOn = false;
                }
            }
        }
    }

    public void ToggleCabinetChanged(Toggle toggle)
    {
        if (toggle.isOn)
        {
            for (int i = 0; i < toggleCabinet.Length; i++)
            {
                if (toggleCabinet[i].isOn && toggleCabinet[i] != toggle)
                {
                    toggleCabinet[i].isOn = false;
                }
            }
        }
    }
}
