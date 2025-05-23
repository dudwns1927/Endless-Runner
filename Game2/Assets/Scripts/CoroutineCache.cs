using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineCache : MonoBehaviour
{
    static Dictionary<float, WaitForSeconds> dictionary = new Dictionary<float, WaitForSeconds>();
}
