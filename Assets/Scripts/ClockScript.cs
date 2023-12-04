using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockScript : MonoBehaviour
{
    [SerializeField]
    TMPro.TextMeshPro clock;
    float time;
    void Start()
    {
        time = 0f;
    }
    
    void Update()
    {
        time += Time.deltaTime;
    }
    private void LateUpdate()
    {
        clock.text = time.ToString();
    }
}
