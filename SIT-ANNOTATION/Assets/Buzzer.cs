using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buzzer : MonoBehaviour
{
    public int taskNumber;
    public static event Action<int> OnTaskFinished;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _duration = 2f;

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(CountDown(_duration));
    }

    IEnumerator CountDown(float duration)
    {
        float elapsedTime = 0;
        while (elapsedTime <= duration)
        {
            elapsedTime += Time.deltaTime;
            _slider.value = elapsedTime / duration;
            yield return null;
        }
        OnTaskFinished?.Invoke(taskNumber);
    }
}

