using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Goal : MonoBehaviour
{
    public UnityEvent OnBallGoalEnter = new UnityEvent();
    private void OnTriggerEnter(Collider other)
    {
        //deteksi bola masuk apa ngga
        if(other.CompareTag("Ball"))
        {
            OnBallGoalEnter.Invoke();
            //AudioManager.Instance.musicSource.Stop();
            AudioManager.Instance.PlaySFX("Win");
        }
    }
}
