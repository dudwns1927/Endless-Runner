using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineCamera : MonoBehaviour
{
    [SerializeField] Runner runner;
    
    [SerializeField] CinemachineVirtualCamera cinemachineVirtualCamera;

    private void OnEnable() {
        State.Subscribe(Condition.START, Follow);
        State.Subscribe(Condition.FINISH, observe);
    }


    public void Follow() {
        cinemachineVirtualCamera.Follow = runner.transform;


    }

    public void observe() {

       cinemachineVirtualCamera.LookAt = runner.transform;
    }

    private void OnDisable() {
        State.UnSubscribe(Condition.START, Follow);
        State.UnSubscribe(Condition.FINISH, observe);
    }

}
