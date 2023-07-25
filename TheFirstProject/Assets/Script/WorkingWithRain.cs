using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WorkingWithRain : MonoBehaviour
{
    public Light ligh;
    private ParticleSystem PS;
    private bool isRain = false;

    private void Start()
    {
        PS = GetComponent<ParticleSystem>();
        StartCoroutine(Wahtr());
    }

    private void Update()
    {
        if (isRain && ligh.intensity > 0.25f)
        {
            LighIntensity(-1);
        }
        else if (!isRain && ligh.intensity < 0.5f)
        {
            LighIntensity(1);
        }
    }

    private void LighIntensity(int malt)
    {
        ligh.intensity += 0.1f * Time.deltaTime * malt;
    }

    IEnumerator Wahtr()
    { 
        while (true) 
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(1f, 5f));

            if (isRain)
            {
                PS.Stop();
            }
            else 
            {
                PS.Play();
            }
            isRain = !isRain;    
        }
        
    }
}
