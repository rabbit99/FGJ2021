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
    public float san_amount = 1f;
    public float anger_amount = 1f;

    private CooldownTimer cooldownTimer;

    public UnityEvent<int> SanUpateAction;
    public UnityEvent<int> HpUpateAction;
    public UnityEvent<int> AngerUpateAction;
    public UnityEvent OverAction;
    public UnityEvent VictoryAction;

    public UIController m_UIController;

    private int hp = 2;

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
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer.Update(Time.deltaTime);
    }

    public void DecreaseSan()
    {
        sanData.san -= san_amount;
        SanUpateAction?.Invoke((int)sanData.san);
        if (sanData.IsOver())
        {
            cooldownTimer.Pause();
            OverAction?.Invoke();
        }
    }

    public void IncreaseSan()
    {
        sanData.san += 5;
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
