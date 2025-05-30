using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpeedManager : Singleton<SpeedManager>
{

    static SpeedManager instance;

    [SerializeField] float speed = 30.0f;
    [SerializeField] float limitSpeed = 60.0f;

    public float Speed { get { return speed; } }

    private void OnEnable() {
        State.Subscribe(Condition.START, Execute);
    
    }

    private void Execute() {
        StartCoroutine(Increase());
    
    }

    IEnumerator Increase() {
        while (speed < limitSpeed) {
            yield return CoroutineCache.WaitForSeconds(5.0f);
            speed = speed + 2.5f;
        }
    }

    private void OnDisable() {
        State.UnSubscribe(Condition.START, Execute);
    }
}
