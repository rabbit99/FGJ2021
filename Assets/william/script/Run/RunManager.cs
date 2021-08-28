using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RunManager : MonoBehaviour
{
    public SanData sanData;
    public float spawnTime = 1f;
    public float san_amount = 1f;
    private CooldownTimer cooldownTimer;

    public UnityEvent<float> SanUpateAction;
    public UnityEvent HpUpateAction;
    public UnityEvent OverAction;

    private int hp = 2;

    // Start is called before the first frame update
    void Start()
    {
        cooldownTimer = new CooldownTimer(spawnTime, true);
        cooldownTimer.TimerCompleteEvent += IncreaseSan;
        cooldownTimer.Start();

        SanUpateAction?.Invoke(sanData.san);
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer.Update(Time.deltaTime);
    }

    public void IncreaseSan()
    {
        sanData.san += san_amount;
        SanUpateAction?.Invoke(sanData.san);
        if (sanData.IsOver())
        {
            cooldownTimer.Pause();
            OverAction?.Invoke();
        }
    }

    public void IncreaseSan(float value)
    {
        sanData.san += value;
        SanUpateAction?.Invoke(sanData.san);
        if (sanData.IsOver())
        {
            cooldownTimer.Pause();
            OverAction?.Invoke();
        }
    }

    public void Hurt(int value)
    {
        hp -= value;
        if (hp <= 0)
        {
            cooldownTimer.Pause();
            OverAction?.Invoke();
        }
    }
}
