using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpeedManager : Singleton<SpeedManager>
{

    static SpeedManager instance;

    [SerializeField] float speed = 30.0f;
    [SerializeField] float limitSpeed = 60.0f;
    [SerializeField] float initializeSpeed;

    public float Speed { get { return speed; } }

    public float InitializeSpeed { get { return initializeSpeed; } }

    private void OnEnable() {

        initializeSpeed = speed;

        State.Subscribe(Condition.START, Execute);
        State.Subscribe(Condition.FINISH, Release);
    
    }

    private void Release() {
        StopAllCoroutines();
    }


    private void Execute() {
        StartCoroutine(Increase());
    
    }

    IEnumerator Increase() {
        while (speed < limitSpeed) {
            yield return CoroutineCache.WaitForSeconds(0.533f);
            speed = speed + 0.5f;
        }
    }

    private void OnDisable() {
        State.UnSubscribe(Condition.START, Execute);
        State.UnSubscribe(Condition.FINISH, Release);
    }
}
