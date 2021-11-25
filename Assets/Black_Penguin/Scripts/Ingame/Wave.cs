using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public int WaveLevel;
    public float WaveTime;

    private void Update()
    {
        if (WaveLevel < 20)
        {
            WaveLevel++;
            switch (WaveLevel)
            {
                case 1:
                    StartCoroutine(Wave1());
                    break;
                case 2:
                    StartCoroutine(Wave2());
                    break;
                case 3:
                    StartCoroutine(Wave3());
                    break;
                case 4:
                    StartCoroutine(Wave4());
                    break;
                case 5:
                    StartCoroutine(Wave5());
                    break;
                case 6:
                    StartCoroutine(Wave6());
                    break;
                case 7:
                    StartCoroutine(Wave7());
                    break;
                case 8:
                    StartCoroutine(Wave8());
                    break;
                case 9:
                    StartCoroutine(Wave9());
                    break;
                case 10:
                    StartCoroutine(Wave10());
                    break;
                case 11:
                    StartCoroutine(Wave11());
                    break;
                case 12:
                    StartCoroutine(Wave12());
                    break;
                case 13:
                    StartCoroutine(Wave13());
                    break;
                case 14:
                    StartCoroutine(Wave14());
                    break;
                case 15:
                    StartCoroutine(Wave15());
                    break;
                case 16:
                    StartCoroutine(Wave16());
                    break;
                case 17:
                    StartCoroutine(Wave17());
                    break;
                case 18:
                    StartCoroutine(Wave18()); 
                    break;
                case 19:
                    StartCoroutine(Wave19());
                    break;
                case 20:
                    StartCoroutine(Wave20());
                    break;
            }
            WaveTime = 0;
        }
        WaveTime += Time.deltaTime;
    }
    IEnumerator Wave1()
    {
        yield return new WaitForSeconds(1);
    }
    IEnumerator Wave2()
    {
        yield return new WaitForSeconds(1);
    }
    IEnumerator Wave3()
    {
        yield return new WaitForSeconds(1);
    }
    IEnumerator Wave4()
    {
        yield return new WaitForSeconds(1);
    }
    IEnumerator Wave5()
    {
        yield return new WaitForSeconds(1);
    }
    IEnumerator Wave6()
    {
        yield return new WaitForSeconds(1);
    }
    IEnumerator Wave7()
    {
        yield return new WaitForSeconds(1);
    }
    IEnumerator Wave8()
    {
        yield return new WaitForSeconds(1);
    }
    IEnumerator Wave9()
    {
        yield return new WaitForSeconds(1);
    }
    IEnumerator Wave10()
    {
        yield return new WaitForSeconds(1);
    }
    IEnumerator Wave11()
    {
        yield return new WaitForSeconds(1);
    }
    IEnumerator Wave12()
    {
        yield return new WaitForSeconds(1);
    }
    IEnumerator Wave13()
    {
        yield return new WaitForSeconds(1);
    }
    IEnumerator Wave14()
    {
        yield return new WaitForSeconds(1);
    }
    IEnumerator Wave15()
    {
        yield return new WaitForSeconds(1);
    }
    IEnumerator Wave16()
    {
        yield return new WaitForSeconds(1);
    }
    IEnumerator Wave17()
    {
        yield return new WaitForSeconds(1);
    }
    IEnumerator Wave18()
    {
        yield return new WaitForSeconds(1);
    }
    IEnumerator Wave19()
    {
        yield return new WaitForSeconds(1);
    }
    IEnumerator Wave20()
    {
        yield return new WaitForSeconds(1);
    }
}
