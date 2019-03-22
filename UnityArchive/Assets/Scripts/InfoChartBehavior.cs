using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoChartBehavior : MonoBehaviour
{

    private void Update()
    {
        transform.LookAt(gameManager.instance.Player);
    }

}
