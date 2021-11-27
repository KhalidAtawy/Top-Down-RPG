using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundries : MonoBehaviour
{
    private Vector2 screenBoundries;
    // Start is called before the first frame update
    void Start()
    {
        screenBoundries = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBoundries.x * -1, screenBoundries.x );
        viewPos.y = Mathf.Clamp(viewPos.y, screenBoundries.y * -1, screenBoundries.y );
        transform.position = viewPos;
    }
}
