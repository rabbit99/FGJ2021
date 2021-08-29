using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RunManager : MonoBehaviour
{
    public SanData sanData;
    public AngerData angerData;
    public HpData hpData;
    public float spawnTime = 1f;
    public int san_DecreaseAmount = 1;
    public int san_IncreaseAmount = 5;
    public int anger_amount = 1;

    private CooldownTimer cooldownTimer;

    public UnityEvent<int> SanUpateAction;
    public UnityEvent<int> HpUpateAction;
    public UnityEvent<int> AngerUpateAction;
    public UnityEvent OverAction;
    public UnityEvent VictoryAction;

    public UIController m_UIController;

    private int hp = 2;

    public AudioClip coinAudio;
    public AudioClip deadAudio;
    public AudioSource soundPlayer;

    // Start is called before the first frame update
    void Start()
    {
        cooldownTimer = new CooldownTimer(spawnTime, true);
        cooldownTimer.TimerCompleteEvent += DecreaseSan;
        cooldownTimer.TimerCompleteEvent += DecreaseAnger;
        cooldownTimer.Start();

        SanUpateAction?.Invoke((int)sanData.san);
        AngerUpateAction?.Invoke((int)angerData.anger_max);
        sanData.Retset();
        angerData.Retset();
        hpData.Retset();

        OverAction.AddListener(() =>
       {
           cooldownTimer.Pause();
           soundPlayer.clip = deadAudio;
           soundPlayer.Play();
       });
        VictoryAction.AddListener(() =>
        {
            cooldownTimer.Pause();
        });
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer.Update(Time.deltaTime);
    }

    public void DecreaseSan()
    {
        sanData.san -= san_DecreaseAmount;
        SanUpateAction?.Invoke((int)sanData.san);
        if (sanData.IsOver())
        {
            cooldownTimer.Pause();
            OverAction?.Invoke();
        }
    }

    public void IncreaseSan()
    {
        soundPlayer.clip = coinAudio;
        soundPlayer.Play();
        if (sanData.san + san_IncreaseAmount <= sanData.san_max)
        {
            sanData.san += san_IncreaseAmount;
        }
        else
        {
            sanData.san = sanData.san_max;
        }

        SanUpateAction?.Invoke((int)sanData.san);
        if (sanData.IsOver())
        {
            cooldownTimer.Pause();
            OverAction?.Invoke();
        }
    }

    public void DecreaseAnger()
    {
        angerData.anger -= anger_amount;
        AngerUpateAction?.Invoke((int)angerData.anger);
        if (angerData.IsOver())
        {
            cooldownTimer.Pause();
            VictoryAction?.Invoke();
        }
    }

    public void Hurt(int value)
    {
        hpData.hp -= value;
        HpUpateAction?.Invoke((int)hpData.hp);
        if (hpData.IsOver())
        {
            cooldownTimer.Pause();
            OverAction?.Invoke();
        }
    }
}
