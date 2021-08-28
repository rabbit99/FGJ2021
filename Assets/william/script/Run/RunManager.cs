using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RunManager : MonoBehaviour
{
    public SanData sanData;
    public AngerData angerData;
    public float spawnTime = 1f;
    public float san_amount = 1f;
    public float anger_amount = 1f;

    private CooldownTimer cooldownTimer;

    public UnityEvent<int> SanUpateAction;
    public UnityEvent<int> HpUpateAction;
    public UnityEvent<int> AngerUpateAction;
    public UnityEvent OverAction;
    public UnityEvent VictoryAction;

    private int hp = 2;

    // Start is called before the first frame update
    void Start()
    {
        cooldownTimer = new CooldownTimer(spawnTime, true);
        cooldownTimer.TimerCompleteEvent += IncreaseSan;
        cooldownTimer.TimerCompleteEvent += DncreaseAnger;
        cooldownTimer.Start();

        SanUpateAction?.Invoke((int)sanData.san);

        angerData.anger = 100;
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer.Update(Time.deltaTime);
    }

    public void IncreaseSan()
    {
        sanData.san += san_amount;
        SanUpateAction?.Invoke((int)sanData.san);
        if (sanData.IsOver())
        {
            cooldownTimer.Pause();
            OverAction?.Invoke();
        }
    }

    public void IncreaseSan(float value)
    {
        sanData.san += value;
        SanUpateAction?.Invoke((int)sanData.san);
        if (sanData.IsOver())
        {
            cooldownTimer.Pause();
            OverAction?.Invoke();
        }
    }

    public void DncreaseAnger()
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
        hp -= value;
        HpUpateAction?.Invoke(hp);
        if (hp <= 0)
        {
            cooldownTimer.Pause();
            OverAction?.Invoke();
        }
    }
}
