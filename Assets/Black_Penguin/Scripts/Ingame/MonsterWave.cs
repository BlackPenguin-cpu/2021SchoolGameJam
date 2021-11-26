using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterWave : MonoBehaviour
{
    [SerializeField] GameObject[] gameObjects;
    public int position;
    public bool isRight;
    public int WaveLevel;
    public float WaveTime;

    private void Update()
    {
        if (WaveTime >= 122)
        {
            StartCoroutine(Clear());
        }
        if (WaveLevel < 20 && WaveTime >= 100)
        {
            if (Random.Range(0, 2) == 1)
            {
                position = 44;
                isRight = true;
            }
            else
            {
                position = -44;
                isRight = false;
            }
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
    IEnumerator Clear()
    {
        yield return new WaitForSeconds(1);
    }
    IEnumerator Wave1()
    {
        for (int i = 0; i < 15; i++)
        {
            Instantiate(gameObjects[0], new Vector3(position, -2f, 0), Quaternion.identity);
            yield return new WaitForSeconds(6);
        }
    }
    IEnumerator Wave2()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(gameObjects[0], new Vector3(position, -2f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5);
        }
        for (int i = 0; i < 5; i++)
        {
            Instantiate(gameObjects[1], new Vector3(position, -2f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5);
        }
        yield return new WaitForSeconds(1);
    }
    IEnumerator Wave3()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(gameObjects[0], new Vector3(position, -2f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5);
            Instantiate(gameObjects[1], new Vector3(position, -2f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5);
        }
        for (int i = 0; i < 5; i++)
        {
            Instantiate(gameObjects[0], new Vector3(position, -2f, 0), Quaternion.identity);
            Instantiate(gameObjects[1], new Vector3(position, -2f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5);
        }
        yield return new WaitForSeconds(1);
    }
    IEnumerator Wave4()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(gameObjects[0], new Vector3(position, -2f, 0), Quaternion.identity);
            yield return new WaitForSeconds(3);
        }
        yield return new WaitForSeconds(1);
    }
    IEnumerator Wave5()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(gameObjects[2], new Vector3(position, -2f, 0), Quaternion.identity);
            yield return new WaitForSeconds(10);
            for (int j = 0; j < 8; j++)
            {
                Instantiate(gameObjects[0], new Vector3(position, -2f, 0), Quaternion.identity);
                yield return new WaitForSeconds(1);
            }
        }
        yield return new WaitForSeconds(1);
    }
    IEnumerator Wave6()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(gameObjects[0], new Vector3(position, -2f, 0), Quaternion.identity);
            Instantiate(gameObjects[1], new Vector3(position, -2f, 0), Quaternion.identity);
            Instantiate(gameObjects[2], new Vector3(position, -2f, 0), Quaternion.identity);
            yield return new WaitForSeconds(10);
        }
        yield return new WaitForSeconds(1);
    }
    IEnumerator Wave7()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(gameObjects[3], new Vector3(position, -2f, 0), Quaternion.identity);
            yield return new WaitForSeconds(9);
        }
        yield return new WaitForSeconds(1);
    }
    IEnumerator Wave8()
    {
        for(int i = 0; i < 100; i++)
        {
            Instantiate(gameObjects[0], new Vector3(position, -2f, 0), Quaternion.identity);
            yield return new WaitForSeconds(1);
        }
        yield return new WaitForSeconds(1);
    }
    IEnumerator Wave9()
    {
        for(int i = 0; i < 5; i++)
        {

        }
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
        Wave20();
    }
}
