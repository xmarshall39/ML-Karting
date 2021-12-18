using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalCameraManager : MonoBehaviour
{
    public List<AutomaticCameraSystem> cameraSystems;


    public float cameraTime = 60f;
    private float elapsedTime = 0f;

    private int camSysIndex = 0;

    private void Start()
    {
        cameraSystems[0].gameObject.SetActive(true);
        for (int i = 1; i < cameraSystems.Count; ++i) cameraSystems[i].gameObject.SetActive(false);
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime > cameraTime)
        {
            cameraSystems[camSysIndex].gameObject.SetActive(false);
            camSysIndex = camSysIndex == cameraSystems.Count - 1 ? 0 : camSysIndex + 1;
            cameraSystems[camSysIndex].gameObject.SetActive(true);
            elapsedTime = 0f;

        }
    }

}
