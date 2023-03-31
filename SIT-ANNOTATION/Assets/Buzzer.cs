using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buzzer : MonoBehaviour
{
    public int taskNumber;
    public static event Action<int> OnTaskFinished;
    private Slider _slider;

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(CountDown(2f));
    }

    IEnumerator CountDown(float duration)
    {
        float elapsedTime = 0;
        while (elapsedTime <= duration)
        {
            elapsedTime += Time.deltaTime;
            _slider.
            yield return null;
        }
        OnTaskFinished?.Invoke(taskNumber);
    }
}

