using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject startButton;

    public void OnEnable() {
        State.Subscribe(Condition.START, DisableButton);
        State.Subscribe(Condition.FINISH, Release);
    }

    private void Release() {
        StopAllCoroutines();
    }

    public void DisableButton() {

       startButton.SetActive(false);
    }
    public void Execute() {
        State.Publish(Condition.START);
    }


    public void Resume() {

    }

    public void OnDisable() {
        State.UnSubscribe(Condition.START, DisableButton);
        State.UnSubscribe(Condition.FINISH, Release);

    }
}
