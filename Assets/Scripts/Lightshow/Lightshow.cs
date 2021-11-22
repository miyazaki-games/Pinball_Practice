using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightshow : MonoBehaviour
{
    public float interval = .5f;
    bool lightShowRunning;

    public enum LightModes
    {
        SINGLE,
        AIRPLANE,
        PINGPONG,
        ALL_AT_ONCE
    }

    public LightModes lightMode;

    [System.Serializable]
    public class LightSet
    {
        public SpriteRenderer sp;
        public Sprite on, off;
    }

    public List<LightSet> lightList = new List<LightSet>();
    int lightIndex;
    int direction = 1;

    public void StartLightShow()
    {
        StartCoroutine(Blink());
    }

    public void StopLightShow()
    {
        lightShowRunning = false;

        foreach(var l in lightList)
        {
            l.sp.sprite = l.off;
        }

        Debug.Log("StopLightShow");
    }

    IEnumerator Blink()
    {
        if (lightShowRunning)
        {
            yield break;
        }
        lightShowRunning = true;
        direction = 1;

        while(lightShowRunning)
        {
            if (lightMode == LightModes.SINGLE)
            {
                lightList[0].sp.sprite = lightList[0].on;

                yield return new WaitForSeconds(interval);

                lightList[0].sp.sprite = lightList[0].off;

                yield return new WaitForSeconds(interval);
            }

            if (lightMode == LightModes.AIRPLANE)
            {
                lightList[lightIndex].sp.sprite = lightList[lightIndex].on;

                yield return new WaitForSeconds(interval);

                lightList[lightIndex].sp.sprite = lightList[lightIndex].off;

                yield return new WaitForSeconds(interval);

                lightIndex++;

                if (lightIndex > lightList.Count - 1) lightIndex = 0;
            }

            if (lightMode == LightModes.PINGPONG)
            {
                lightList[lightIndex].sp.sprite = lightList[lightIndex].on;

                yield return new WaitForSeconds(interval);

                lightList[lightIndex].sp.sprite = lightList[lightIndex].off;

                yield return new WaitForSeconds(interval);

                lightIndex += 1 * direction;

                if (lightIndex > lightList.Count - 1)
                {
                    lightIndex = lightList.Count - 1;
                    direction = -1;
                }
                else if (lightIndex < 0)
                {
                    lightIndex = 0;
                    direction = 1;
                }
            }

            if (lightMode == LightModes.ALL_AT_ONCE)
            {
                foreach(var l in lightList)
                {
                    l.sp.sprite = l.on;
                }

                yield return new WaitForSeconds(interval);

                foreach(var l in lightList)
                {
                    l.sp.sprite = l.off;
                }

                yield return new WaitForSeconds(interval);
            }
        }
    }
}
