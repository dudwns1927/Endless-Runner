using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    
    private enum Condition {
        START,
        FINISH,
        RESUME
    }
    public void Execute() {

       Debug.Log("Execute");

    }


    public void Resume() {
        Debug.Log("Resume");
    }

}
