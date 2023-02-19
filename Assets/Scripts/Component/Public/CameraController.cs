using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private bool isShake;
    private bool isPause;
    private static CameraController instance;

    public static CameraController Instance
    {
        get
        {
            if (instance == null)
                instance = Transform.FindObjectOfType<CameraController>();
            return instance;
        }
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (!isShake&&!isPause)
        {
            transform.localPosition = new Vector3(player.transform.localPosition.x, player.transform.localPosition.y, transform.localPosition.z);
        }
    }
   
    public void HitPause(int duration)
    {
        isPause = true;
        StartCoroutine(Pause(duration));
    }

    IEnumerator Pause(int duration)
    {
        float pauseTime = duration / 60f;
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(pauseTime);
        Time.timeScale = 1;
        isPause = false;
    }
    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void TimeRecover()
    {
        Time.timeScale = 1;
    }

    public void CameraShake(float duration, float strength)
    {      
        if (!isShake)
            StartCoroutine(Shake(duration, strength));
    }

    IEnumerator Shake(float duration, float strength)
    {
        isShake = true;
        Transform camera = Camera.main.transform;
        Vector3 startPosition = camera.position;

        while (duration > 0)
        {
            camera.position = Random.insideUnitSphere * strength + startPosition;
            duration -= Time.deltaTime;
            yield return null;
        }
        camera.position = startPosition;
        isShake = false;
    }
}
