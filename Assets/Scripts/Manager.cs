using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [Header("PersonSprites")]
    [SerializeField] private PersonSprites personScript;

    [Header("Events")]
    [SerializeField] private int eventChance;

    public PersonEvent[] events;
    public int eventType;
    public bool isEvent;
    public int eventID;

    [Header("TV")]

    [Header("LykaTV")]
    [SerializeField] private string[] lykaTVText;
    [System.Serializable]
    public struct lykaTVStruct
    {
        public float[] changes;
    }
    public lykaTVStruct[] lykaTVChanges;

    [Header("PepperTV")]
    [SerializeField] private string[] pepperTVText;
    [System.Serializable]
    public struct pepperTVStruct
    {
        public float[] changes;
    }
    public lykaTVStruct[] pepperTVChanges;

    [Header("DemianTV")]
    [SerializeField] private string[] demianTVText;
    [System.Serializable]
    public struct demianTVStruct
    {
        public float[] changes;
    }
    public lykaTVStruct[] demianTVChanges;

    [Header("VictorTV")]
    [SerializeField] private string[] victorTVText;
    [System.Serializable]
    public struct victorTVStruct
    {
        public float[] changes;
    }
    public lykaTVStruct[] victorTVChanges;


    [Header("Diner")]
    [SerializeField] private DinerEvent[] lykaDinerEvent;
    [SerializeField] private DinerEvent[] pepperDinerEvent;
    [SerializeField] private DinerEvent[] demianDinerEvent;
    [SerializeField] private DinerEvent[] victorDinerEvent;

    [Header("Read")]
    [SerializeField] private ReadEvent[] lykaReadEvent;
    [SerializeField] private ReadEvent[] pepperReadEvent;
    [SerializeField] private ReadEvent[] demianReadEvent;
    [SerializeField] private ReadEvent[] victorReadEvent;


    [Header("NoteBook")]
    [SerializeField] private GameObject noteBook;
    [SerializeField] private Notebook noteBookScript;
    [SerializeField] private Button noteBookButton;

    [Header("Player Statistics")]
    [SerializeField] private GameObject indicator;
    [SerializeField] private Indicator indicatorScript;
    [SerializeField] private Button indicatorButton;

    [Header("Inventory")]
    [SerializeField] private GameObject inventory;
    [SerializeField] private Inventory inventoryScript;
    [SerializeField] private Button inventoryButton;

    [Header("Craft")]
    [SerializeField] private GameObject craft;
    [SerializeField] private Crafting craftScript;
    [SerializeField] private Button craftButton;

    [Header("Action")]
    [SerializeField] private GameObject action;
    [SerializeField] private Action actionScript;
    [SerializeField] private Button actionButton;

    [Header("Endings")]
    [SerializeField] private Endings endingsScript;

    [Header("Purity")]
    [SerializeField] private Purity purityScript;

    [Header("Item Bonus")]
    [SerializeField] private ItemBonus itemBonusScript;

    [Header("Loot Event")]
    [SerializeField] private LootType[] lykaLootEvent;
    [SerializeField] private LootType[] pepperLootEvent;
    [SerializeField] private LootType[] demianLootEvent;
    [SerializeField] private LootType[] victorLootEvent;

    [Header("Days")]
    [SerializeField] private Animator dayAnimator;
    [SerializeField] private Button dayButton;
    public int day;

    [Header("Options")]
    [SerializeField] private bool isOpenIndicator;
    [SerializeField] private bool isOpenNoteBook;
    [SerializeField] private bool isOpenInventory;
    [SerializeField] private bool isOpenCraft;
    [SerializeField] private bool isOpenAction;

    [Header("Playable")]
    public int lykaPlayableDay;
    public int pepperPlayableDay;
    public int demianPlayableDay;
    public int victorPlayableDay;

    public bool lykaPlayable = true;
    public bool pepperPlayable = true;
    public bool demianPlayable = true;
    public bool victorPlayable = true;

    [Header("Dead")]
    public bool lykaDead = false;
    public bool pepperDead = false;
    public bool demianDead = false;
    public bool victorDead = false;

    public Item item;
    public Item item2;

    private void Start()
    {
        indicatorScript = indicator.GetComponent<Indicator>();
        noteBookScript = noteBook.GetComponent<Notebook>();
        inventoryScript = inventory.GetComponent<Inventory>();
        craftScript = craft.GetComponent<Crafting>();
        actionScript = action.GetComponent<Action>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            inventoryScript.AddItem(item);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            inventoryScript.AddItem(item2);
        }
    }

    public void OpenNoteBook()
    {
        isOpenNoteBook = !isOpenNoteBook;
        if (isOpenNoteBook)
        {
            isOpenIndicator = false;
            isOpenInventory = false;
            isOpenCraft = false;
            isOpenAction = false;
            noteBook.SetActive(true);
            StartCoroutine(ButtonInteractable(1));

            noteBookScript.ChangeAnimation(1);
            inventoryScript.ChangeAnimation(2);
            indicatorScript.ChangeAnimation(2);
            craftScript.ChangeAnimation(2);
            actionScript.ChangeAnimation(2);
        }
        if (!isOpenNoteBook)
        {
            StartCoroutine(ButtonInteractable(1));
            noteBookScript.ChangeAnimation(2);
        }
    }

    public void OpenIndicator()
    {
        isOpenIndicator = !isOpenIndicator;
        if (isOpenIndicator)
        {
            isOpenNoteBook = false;
            isOpenInventory = false;
            isOpenCraft = false;
            isOpenAction = false;
            indicator.SetActive(true);
            StartCoroutine(ButtonInteractable(1));

            indicatorScript.ChangeAnimation(1);
            inventoryScript.ChangeAnimation(2);
            noteBookScript.ChangeAnimation(2);
            craftScript.ChangeAnimation(2);
            actionScript.ChangeAnimation(2);
        }
        if (!isOpenIndicator)
        {
            StartCoroutine(ButtonInteractable(1));
            indicatorScript.ChangeAnimation(2);
        }
    }

    public void OpenInventory()
    {
        isOpenInventory = !isOpenInventory;
        if (isOpenInventory)
        {
            isOpenNoteBook = false;
            isOpenIndicator = false;
            isOpenCraft = false;
            isOpenAction = false;
            inventory.SetActive(true);
            inventoryScript.ClearItemInfo();
            StartCoroutine(ButtonInteractable(1));

            inventoryScript.ChangeAnimation(1);
            indicatorScript.ChangeAnimation(2);
            noteBookScript.ChangeAnimation(2);
            craftScript.ChangeAnimation(2);
            actionScript.ChangeAnimation(2);
        }
        if (!isOpenInventory)
        {
            StartCoroutine(ButtonInteractable(1));
            inventoryScript.ChangeAnimation(2);
        }
    }

    public void OpenCraft()
    {
        isOpenCraft = !isOpenCraft;
        if (isOpenCraft)
        {
            isOpenNoteBook = false;
            isOpenIndicator = false;
            isOpenInventory = false;
            isOpenAction = false;
            craft.SetActive(true);
            StartCoroutine(ButtonInteractable(1));

            craftScript.ChangeAnimation(1);
            inventoryScript.ChangeAnimation(2);
            indicatorScript.ChangeAnimation(2);
            noteBookScript.ChangeAnimation(2);
            actionScript.ChangeAnimation(2);
        }
        if (!isOpenCraft)
        {
            StartCoroutine(ButtonInteractable(1));
            craftScript.ChangeAnimation(2);
        }
    }

    public void OpenAction()
    {
        isOpenAction = !isOpenAction;
        if (isOpenAction)
        {
            isOpenNoteBook = false;
            isOpenIndicator = false;
            isOpenInventory = false;
            isOpenCraft = false;
            action.SetActive(true);
            StartCoroutine(ButtonInteractable(1));

            actionScript.ChangeAnimation(1);
            inventoryScript.ChangeAnimation(2);
            indicatorScript.ChangeAnimation(2);
            noteBookScript.ChangeAnimation(2);
            craftScript.ChangeAnimation(2);
        }
        if (!isOpenAction)
        {
            StartCoroutine(ButtonInteractable(1));
            actionScript.ChangeAnimation(2);
        }
    }

    private IEnumerator ButtonInteractable(int seconds)
    {
        indicatorButton.interactable = false;
        noteBookButton.interactable = false;
        inventoryButton.interactable = false;
        craftButton.interactable = false;
        actionButton.interactable = false;
        dayButton.interactable = false;
        yield return new WaitForSeconds(seconds);

        indicatorButton.interactable = true;
        noteBookButton.interactable = true;
        inventoryButton.interactable = true;
        craftButton.interactable = true;
        actionButton.interactable = true;
        dayButton.interactable = true;
    }

    public void NextDay()
    {
        StartCoroutine(noteBookScript.NextDay(day));
        dayAnimator.SetTrigger("change");
        StartCoroutine(ChangeDay());
        StartCoroutine(ButtonInteractable(4));
    }

    IEnumerator ChangeDay()
    {
        yield return new WaitForSeconds(2);
        day++;
        Debug.Log(1);
        indicatorScript.ChangeAnimation(2);
        noteBookScript.ChangeAnimation(2);
        inventoryScript.ChangeAnimation(2);
        craftScript.ChangeAnimation(2);
        actionScript.ChangeAnimation(2);
        isOpenIndicator = false;
        isOpenNoteBook = false;
        isOpenInventory = false;
        isOpenCraft = false;
        isOpenAction = false;

        GetEvent();
        itemBonusScript.BonusNewDay(inventoryScript, indicatorScript);
        purityScript.ChangePurity(inventoryScript, indicatorScript);
        indicatorScript.NewDay(this);
        CheckPlayableDays();
        personScript.NewDay(this);
        actionScript.CheckAction(this);
        endingsScript.CheckEnds(this);
    }

    public void CheckPlayableDays()
    {
        if (lykaPlayableDay > 0) lykaPlayableDay -= 1;
        if (pepperPlayableDay > 0) pepperPlayableDay -= 1;
        if (demianPlayableDay > 0) demianPlayableDay -= 1;
        if (victorPlayableDay > 0) victorPlayableDay -= 1;

        if (lykaPlayableDay <= 0) lykaPlayable = true;
        if (pepperPlayableDay <= 0) pepperPlayable = true;
        if (demianPlayableDay <= 0) demianPlayable = true;
        if (victorPlayableDay <= 0) victorPlayable = true;
    }

    public void SetPlayable(int person)
    {
        // Установка значения играбельности персонажа
        switch(person)
        {
            case 1:
                if (!lykaPlayable) return;
                lykaPlayable = false;
                noteBookScript.AddText("Лука сошёл с ума. ");
                break;
            case 2:
                if (!pepperPlayable) return;
                pepperPlayable = false;
                noteBookScript.AddText("Перец сошёл с ума. ");
                break;
            case 3:
                if (!demianPlayable) return;
                demianPlayable = false;
                noteBookScript.AddText("Демиан сошёл с ума. ");
                break;
            case 4:
                if (!victorPlayable) return;
                victorPlayable = false;
                noteBookScript.AddText("Виктор сошёл с ума. ");
                break;
        }
    }

    public void SetDead(int person)
    {
        // Установка значения играбельности персонажа
        switch (person)
        {
            case 1:
                if (lykaDead) return;
                lykaPlayable = false;
                lykaDead = true;
                noteBookScript.AddText("Лука погиб. ");
                break;
            case 2:
                if (pepperDead) return;
                pepperPlayable = false;
                pepperDead = true;
                noteBookScript.AddText("Перец погиб. ");
                break;
            case 3:
                if (demianDead) return;
                demianPlayable = false;
                demianDead = true;
                noteBookScript.AddText("Демиан погиб. ");
                break;
            case 4:
                if (victorDead) return;
                victorPlayable = false;
                victorDead = true;
                noteBookScript.AddText("Виктор погиб. ");
                break;
        }
    }

    public void PlayableDay(int person, int days)
    {
        switch(person)
        {
            case 1:
                if (days == 0) return;
                lykaPlayableDay = days;
                lykaPlayable = false;
                break;
            case 2:
                if (days == 0) return;
                pepperPlayableDay = days;
                pepperPlayable = false;
                break;
            case 3:
                if (days == 0) return;
                demianPlayableDay = days;
                demianPlayable = false;
                break;
            case 4:
                if (days == 0) return;
                victorPlayableDay = days;
                victorPlayable = false;
                break;
        }
    }

    public void ActionEat(int person)
    {
        switch(person)
        {
            // Пополняем голод и меняем текст взависимости кто поел
            case 1:
                if (!inventoryScript.FindItemForType(1))
                {
                    noteBookScript.AddText("Лука хотел поесть, но не было еды. ");
                    return;
                }
                else
                {
                    inventoryScript.RemoveItemForType(1);
                    indicatorScript.ChangeStat(person, 0, 50);
                    noteBookScript.AddText("Лука поел. ");
                }
                break;
            case 2:
                if (!inventoryScript.FindItemForType(1))
                {
                    noteBookScript.AddText("Перец хотел поесть, но не было еды. ");
                    return;
                }
                else
                {
                    inventoryScript.RemoveItemForType(1);
                    indicatorScript.ChangeStat(person, 0, 50);
                    noteBookScript.AddText("Перец поел. ");
                }
                break;
            case 3:
                if (!inventoryScript.FindItemForType(1))
                {
                    noteBookScript.AddText("Демиан хотел поесть, но не было еды. ");
                    return;
                }
                else
                {
                    inventoryScript.RemoveItemForType(1);
                    indicatorScript.ChangeStat(person, 0, 50);
                    noteBookScript.AddText("Демиан поел. ");
                }
                break;
            case 4:
                if (!inventoryScript.FindItemForType(1))
                {
                    noteBookScript.AddText("Виктор хотел поесть, но не было еды. ");
                    return;
                }
                else
                {
                    inventoryScript.RemoveItemForType(1);
                    indicatorScript.ChangeStat(person, 0, 50);
                    noteBookScript.AddText("Виктор поел. ");
                }
                break;
        }
    }

    public void OtherAction(int person, int actionID)
    {
        // Кто выполняет действие
        switch(person)
        {
            // Мародёрство, смотреть телевизор или отдыхать
            case 1:
                if(actionID == 1)
                {
                    // Бродить по палатам
                    int random = Random.Range(0, lykaLootEvent.Length);
                    noteBookScript.AddText(lykaLootEvent[random].text);
                    indicatorScript.ChangeLyka(lykaLootEvent[random].changes);
                    PlayableDay(1, lykaLootEvent[random].dayPlayable);
                    if (lykaLootEvent[random].item != null)
                    {
                        inventoryScript.AddItem(lykaLootEvent[random].item);
                    }
                }
                if (actionID == 2)
                {
                    int random = Random.Range(0, lykaTVText.Length);
                    indicatorScript.ChangeLyka(lykaTVChanges[random].changes);
                    noteBookScript.AddText(lykaTVText[random]);
                }
                if (actionID == 3)
                {
                    personScript.SetLyka(3);
                    indicatorScript.ChangeStat(person, 1, 5);
                    indicatorScript.ChangeStat(person, 2, 5);
                }
                if (actionID == 4)
                {
                    int random = Random.Range(0, lykaDinerEvent.Length);
                    noteBookScript.AddText(lykaDinerEvent[random].text);
                    indicatorScript.ChangeLyka(lykaDinerEvent[random].changes);
                    PlayableDay(1, lykaDinerEvent[random].dayPlayable);
                }
                if (actionID == 5)
                {
                    int random = Random.Range(0, lykaReadEvent.Length);
                    noteBookScript.AddText(lykaReadEvent[random].text);
                    indicatorScript.ChangeLyka(lykaReadEvent[random].changes);
                }
                if (actionID == 6)
                {
                    if(inventoryScript.FindItemForID(10))
                    {
                        inventoryScript.RemoveItemForID(10);
                        noteBookScript.AddText("Удалена отмычка. ");
                    }
                }
                break;
            case 2:
                if (actionID == 1)
                {
                    // Бродить по палатам
                    int random = Random.Range(0, pepperLootEvent.Length);
                    noteBookScript.AddText(pepperLootEvent[random].text);
                    indicatorScript.ChangePepper(pepperLootEvent[random].changes);
                    PlayableDay(2, pepperLootEvent[random].dayPlayable);
                    if (pepperLootEvent[random].item != null)
                    {
                        inventoryScript.AddItem(pepperLootEvent[random].item);
                    }
                }
                if (actionID == 2)
                {
                    int random = Random.Range(0, pepperTVText.Length);
                    indicatorScript.ChangePepper(pepperTVChanges[random].changes);
                    noteBookScript.AddText(pepperTVText[random]);
                }
                if (actionID == 3)
                {
                    personScript.SetPepper(3);
                    indicatorScript.ChangeStat(person, 1, 5);
                    indicatorScript.ChangeStat(person, 2, 5);
                }
                if (actionID == 4)
                {
                    int random = Random.Range(0, pepperDinerEvent.Length);
                    noteBookScript.AddText(pepperDinerEvent[random].text);
                    indicatorScript.ChangePepper(pepperDinerEvent[random].changes);
                    PlayableDay(2, pepperDinerEvent[random].dayPlayable);
                }
                if (actionID == 5)
                {
                    int random = Random.Range(0, pepperReadEvent.Length);
                    noteBookScript.AddText(pepperReadEvent[random].text);
                    indicatorScript.ChangePepper(pepperReadEvent[random].changes);
                }
                break;
            case 3:
                if (actionID == 1)
                {
                    // Бродить по палатам
                    int random = Random.Range(0, demianLootEvent.Length);
                    noteBookScript.AddText(demianLootEvent[random].text);
                    indicatorScript.ChangeDemian(demianLootEvent[random].changes);
                    PlayableDay(3, demianLootEvent[random].dayPlayable);
                    if (demianLootEvent[random].item != null)
                    {
                        inventoryScript.AddItem(demianLootEvent[random].item);
                    }
                }
                if (actionID == 2)
                {
                    int random = Random.Range(0, demianTVText.Length);
                    indicatorScript.ChangeDemian(demianTVChanges[random].changes);
                    noteBookScript.AddText(demianTVText[random]);
                }
                if (actionID == 3)
                {
                    personScript.SetDemian(3);
                    indicatorScript.ChangeStat(person, 1, 5);
                    indicatorScript.ChangeStat(person, 2, 5);
                }
                if (actionID == 4)
                {
                    int random = Random.Range(0, demianDinerEvent.Length);
                    noteBookScript.AddText(demianDinerEvent[random].text);
                    indicatorScript.ChangeDemian(demianDinerEvent[random].changes);
                    PlayableDay(3, demianDinerEvent[random].dayPlayable);
                }
                if (actionID == 5)
                {
                    int random = Random.Range(0, demianReadEvent.Length);
                    noteBookScript.AddText(demianReadEvent[random].text);
                    indicatorScript.ChangeDemian(demianReadEvent[random].changes);
                }
                break;
            case 4:
                if (actionID == 1)
                {
                    // Бродить по палатам
                    int random = Random.Range(0, victorLootEvent.Length);
                    noteBookScript.AddText(victorLootEvent[random].text);
                    indicatorScript.ChangeVictor(victorLootEvent[random].changes);
                    PlayableDay(4, victorLootEvent[random].dayPlayable);
                    if (victorLootEvent[random].item != null)
                    {
                        inventoryScript.AddItem(victorLootEvent[random].item);
                    }
                }
                if (actionID == 2)
                {
                    int random = Random.Range(0, victorTVText.Length);
                    indicatorScript.ChangeVictor(victorTVChanges[random].changes);
                    noteBookScript.AddText(victorTVText[random]);
                }
                if (actionID == 3)
                {
                    personScript.SetVictor(3);
                    indicatorScript.ChangeStat(person, 1, 5);
                    indicatorScript.ChangeStat(person, 2, 5);
                }
                if (actionID == 4)
                {
                    int random = Random.Range(0, victorDinerEvent.Length);
                    noteBookScript.AddText(victorDinerEvent[random].text);
                    indicatorScript.ChangeLyka(victorDinerEvent[random].changes);
                    PlayableDay(4, victorDinerEvent[random].dayPlayable);
                }
                if (actionID == 5)
                {
                    int random = Random.Range(0, victorReadEvent.Length);
                    noteBookScript.AddText(victorReadEvent[random].text);
                    indicatorScript.ChangeVictor(victorReadEvent[random].changes);
                }
                break;
        }
    }

    public void GetEvent()
    {
        // С шансом может произойти ивент
        if(Random.Range(1, 100) <= eventChance)
        {
            Debug.Log("EVENT!!!");
            if(isEvent)
            {
                // Если до этого был ивент, то пишем его результат и выбираем новый
                int randomEvent = Random.Range(0, events.Length);
                // Если тип ивента это ивент с персонажами то
                if (events[eventID].eventType == 1)
                {
                    switch (noteBookScript.GetType1())
                    {
                        // Никто не сделал
                        case 0:
                            noteBookScript.ChangePageText(events[eventID].resultNone,
                                events[randomEvent].text);
                            break;
                        // Лука сделал
                        case 1:
                            noteBookScript.ChangePageText(events[eventID].resultLyka,
                                events[randomEvent].text);
                            indicatorScript.ChangeLyka(events[eventID].lykaStats);
                            break;
                        // Перец сделал
                        case 2:
                            noteBookScript.ChangePageText(events[eventID].resultPepper,
                                events[randomEvent].text);
                            indicatorScript.ChangePepper(events[eventID].pepperStats);
                            break;
                        // Демиан сделал
                        case 3:
                            noteBookScript.ChangePageText(events[eventID].resultDemian,
                                events[randomEvent].text);
                            indicatorScript.ChangeDemian(events[eventID].demianStats);
                            break;
                        // Виктор сделал
                        case 4:
                            noteBookScript.ChangePageText(events[eventID].resultVictor,
                                events[randomEvent].text);
                            indicatorScript.ChangeVictor(events[eventID].victorStats);
                            break;
                    }
                }
                // Если тип ивента это ивент с да/нет то
                else if (events[eventID].eventType == 2)
                {
                    switch (noteBookScript.GetType2())
                    {
                        // Если мы отказались
                        case false:
                            noteBookScript.ChangePageText(events[eventID].resultNo,
                                events[randomEvent].text);
                            break;
                        // Если мы согласились
                        case true:
                            noteBookScript.ChangePageText(events[eventID].resultYes,
                                events[randomEvent].text);
                            indicatorScript.ChangeLyka(events[eventID].lykaStats);
                            indicatorScript.ChangePepper(events[eventID].pepperStats);
                            indicatorScript.ChangeDemian(events[eventID].demianStats);
                            indicatorScript.ChangeVictor(events[eventID].victorStats);

                            // Если ивент нам даёт предмет
                            if (events[eventID].items != null)
                            {
                                for(int i = 0; i < events[eventID].items.Length; i++)
                                {
                                    inventoryScript.AddItem(events[eventID].items[i]);
                                }
                            }
                            break;
                    }
                }
                eventType = events[randomEvent].eventType;
                noteBookScript.ActiveType(eventType);
                eventID = randomEvent;
                isEvent = true;
            }
            else
            {
                // Если до этого не было ивентов, то выбираем новый ивент
                int randomEvent = Random.Range(0, events.Length);
                noteBookScript.ChangePageText("За этот день ничего не обычного не случилось. ",
                    events[randomEvent].text);
                eventType = events[randomEvent].eventType;
                noteBookScript.ActiveType(eventType);
                eventID = randomEvent;
                isEvent = true;
            }
            
        }
        // Или же его не будет
        else
        {
            if (isEvent)
            {
                // Если до этого был ивент, то пишем его результат
                // Если тип ивента это ивент с персонажами то
                if (events[eventID].eventType == 1)
                {
                    switch (noteBookScript.GetType1())
                    {
                        // Никто не сделал
                        case 0:
                            noteBookScript.ChangePageText(events[eventID].resultNone,
                                "Весь день вы ждали чего-нибудь, но ничего не было. ");
                            break;
                        // Лука сделал
                        case 1:
                            noteBookScript.ChangePageText(events[eventID].resultLyka,
                                "Весь день вы ждали чего-нибудь, но ничего не было. ");
                            indicatorScript.ChangeLyka(events[eventID].lykaStats);
                            break;
                        // Перец сделал
                        case 2:
                            noteBookScript.ChangePageText(events[eventID].resultPepper,
                                "Весь день вы ждали чего-нибудь, но ничего не было. ");
                            indicatorScript.ChangePepper(events[eventID].pepperStats);
                            break;
                        // Демиан сделал
                        case 3:
                            noteBookScript.ChangePageText(events[eventID].resultDemian,
                                "Весь день вы ждали чего-нибудь, но ничего не было. ");
                            indicatorScript.ChangeDemian(events[eventID].demianStats);
                            break;
                        // Виктор сделал
                        case 4:
                            noteBookScript.ChangePageText(events[eventID].resultVictor,
                                "Весь день вы ждали чего-нибудь, но ничего не было. ");
                            indicatorScript.ChangeVictor(events[eventID].victorStats);
                            break;
                    }
                }
                // Если тип ивента это ивент с да/нет то
                else if (events[eventID].eventType == 2)
                {
                    switch (noteBookScript.GetType2())
                    {
                        // Если мы отказались
                        case false:
                            noteBookScript.ChangePageText(events[eventID].resultNo,
                                "Весь день вы ждали чего-нибудь, но ничего не было. ");
                            break;
                        // Если мы согласились
                        case true:
                            noteBookScript.ChangePageText(events[eventID].resultYes,
                                "Весь день вы ждали чего-нибудь, но ничего не было. ");
                            indicatorScript.ChangeLyka(events[eventID].lykaStats);
                            indicatorScript.ChangePepper(events[eventID].pepperStats);
                            indicatorScript.ChangeDemian(events[eventID].demianStats);
                            indicatorScript.ChangeVictor(events[eventID].victorStats);

                            // Если ивент нам даёт предмет
                            if (events[eventID].items != null)
                            {
                                for (int i = 0; i < events[eventID].items.Length; i++)
                                {
                                    inventoryScript.AddItem(events[eventID].items[i]);
                                }
                            }
                            break;
                    }
                }
                noteBookScript.ActiveType(0);
                eventType = 0;
                isEvent = false;
            }
            else
            {
                // Если не было ивент
                noteBookScript.ChangePageText("За этот день ничего не обычного не случилось. ",
                    "Весь день вы ждали чего-нибудь, но ничего не было. ");
                noteBookScript.ActiveType(0);
                eventType = 0;
                isEvent = false;
            }
        }
    }
}
