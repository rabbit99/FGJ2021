using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WilliamSan : MonoBehaviour
{
    public SanData sanData;
    public UIController uiController;
    // Start is called before the first frame update
    void Start()
    {
        uiController.ChangeSan(sanData.san);
    }

    // Update is called once per frame
    void Update()
    {
        uiController.ChangeSan(sanData.san);
    }
}
