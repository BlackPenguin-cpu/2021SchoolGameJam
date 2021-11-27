using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterWave : MonoBehaviour
{
    [SerializeField] GameObject[] gameObjects;
    [SerializeField] Player player;
    public int position;
    public bool isRight;
    const int right = 44;
    const int left = -44;
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
            player._hp += 25;
            if (Random.Range(0, 2) == 1)
            {
                position = 44;
            }
            else
            {
                position = -44;
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
        for (int i = 0; i < 100; i++)
        {
            if (Random.Range(0, 2) == 0)
            {
                Instantiate(gameObjects[0], new Vector3(left, -2f, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(gameObjects[0], new Vector3(right, -2f, 0), Quaternion.identity);
            }
            yield return new WaitForSeconds(1);
        }
        yield return new WaitForSeconds(1);
    }
    IEnumerator Wave9()
    {
        yield return new WaitForSeconds(5);
        for (int i = 0; i < 4; i++)
        {
            Instantiate(gameObjects[3], new Vector3(right, -2f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5);
            Instantiate(gameObjects[3], new Vector3(right, -2f, 0), Quaternion.identity);
            yield return new WaitForSeconds(10);
            Instantiate(gameObjects[3], new Vector3(left, -2f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5);
            Instantiate(gameObjects[3], new Vector3(left, -2f, 0), Quaternion.identity);
        }
        yield return new WaitForSeconds(1);
    }
    IEnumerator Wave10()
    {
        for (int j = 0; j < 2; j++)
        {
            for (int i = 4; i > -5; i--)
            {
                Instantiate(gameObjects[0], new Vector3(i * 11, 5f, 0), Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForSeconds(10);
            for (int i = -4; i < 5; i++)
            {
                Instantiate(gameObjects[0], new Vector3(i * 11, 5f, 0), Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForSeconds(40);
        }
        yield return new WaitForSeconds(1);
    }
    IEnumerator Wave11()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(gameObjects[3], new Vector3(position, -2.4f, 0), Quaternion.identity);
            yield return new WaitForSeconds(4);
            Instantiate(gameObjects[2], new Vector3(position, -2.4f, 0), Quaternion.identity);
            yield return new WaitForSeconds(4);
            Instantiate(gameObjects[1], new Vector3(position, -2.4f, 0), Quaternion.identity);
            yield return new WaitForSeconds(4);
            Instantiate(gameObjects[0], new Vector3(position, -2.4f, 0), Quaternion.identity);
            yield return new WaitForSeconds(4);
        }
        yield return new WaitForSeconds(1);
    }
    IEnumerator Wave12()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(gameObjects[4], new Vector3(position, -2.4f, 0), Quaternion.identity);
            yield return new WaitForSeconds(1);
            Instantiate(gameObjects[4], new Vector3(position, -2.4f, 0), Quaternion.identity);
            yield return new WaitForSeconds(6);
        }
        Instantiate(gameObjects[4], new Vector3(position, -2.4f, 0), Quaternion.identity);

    }
    IEnumerator Wave13()
    {
        for (int i = 0; i < 2; i++)
        {
            Instantiate(gameObjects[4], new Vector3(left, -2.4f, 0), Quaternion.identity);
            yield return new WaitForSeconds(20);
            Instantiate(gameObjects[4], new Vector3(right, -2.4f, 0), Quaternion.identity);
            yield return new WaitForSeconds(20);
        }
        yield return new WaitForSeconds(1);
    }
    IEnumerator Wave14()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(gameObjects[1], new Vector3(position, -2.4f, 0), Quaternion.identity);
            yield return new WaitForSeconds(1);
            Instantiate(gameObjects[1], new Vector3(position, -2.4f, 0), Quaternion.identity);
            yield return new WaitForSeconds(1);
            Instantiate(gameObjects[1], new Vector3(position, -2.4f, 0), Quaternion.identity);
            yield return new WaitForSeconds(8);
        }
        yield return new WaitForSeconds(1);
    }
    IEnumerator Wave15()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(gameObjects[3], new Vector3(position, -2.4f, 0), Quaternion.identity);
            Instantiate(gameObjects[3], new Vector3(position, -2.4f, 0), Quaternion.identity);
            yield return new WaitForSeconds(10);
            Instantiate(gameObjects[2], new Vector3(position, -2.4f, 0), Quaternion.identity);
            Instantiate(gameObjects[2], new Vector3(position, -2.4f, 0), Quaternion.identity);
            yield return new WaitForSeconds(10);
        }
        yield return new WaitForSeconds(1);
    }
    IEnumerator Wave16()
    {
        for (int j = 0; j < 2; j++)
        {
            for (int i = 4; i > -5; i--)
            {
                Instantiate(gameObjects[3], new Vector3(i * 11, 5f, 0), Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForSeconds(10);
            for (int i = -4; i < 5; i++)
            {
                Instantiate(gameObjects[3], new Vector3(i * 11, 5f, 0), Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForSeconds(40);
        }
    }
    IEnumerator Wave17()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(gameObjects[4], new Vector3(right, -2.4f, 0), Quaternion.identity);
            Instantiate(gameObjects[0], new Vector3(right, -2.4f, 0), Quaternion.identity);
            Instantiate(gameObjects[4], new Vector3(left, -2.4f, 0), Quaternion.identity);
            Instantiate(gameObjects[0], new Vector3(left, -2.4f, 0), Quaternion.identity);
            yield return new WaitForSeconds(10);
        }
        yield return new WaitForSeconds(1);
    }
    IEnumerator Wave18()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(gameObjects[0], new Vector3(right, -2.4f, 0), Quaternion.identity);
            Instantiate(gameObjects[1], new Vector3(right, -2.4f, 0), Quaternion.identity);
            Instantiate(gameObjects[2], new Vector3(right, -2.4f, 0), Quaternion.identity); 
            Instantiate(gameObjects[0], new Vector3(left, -2.4f, 0), Quaternion.identity);
            Instantiate(gameObjects[1], new Vector3(left, -2.4f, 0), Quaternion.identity);
            Instantiate(gameObjects[2], new Vector3(left, -2.4f, 0), Quaternion.identity);
            yield return new WaitForSeconds(10);
        }
        yield return new WaitForSeconds(1);
    }
    IEnumerator Wave19()
    {
        yield return new WaitForSeconds(30);
        for(int i = 0; i < 100; i++)
        {
            Instantiate(gameObjects[3], new Vector3(left, -2.4f, 0), Quaternion.identity);
            Instantiate(gameObjects[3], new Vector3(right, -2.4f, 0), Quaternion.identity);
            yield return new WaitForSeconds(20);
        }

    }
    IEnumerator Wave20()
    {
        for(int i = 0; i < 100; i++)
        {
            Instantiate(gameObjects[4], new Vector3(left, -2.4f, 0), Quaternion.identity);
            Instantiate(gameObjects[4], new Vector3(right, -2.4f, 0), Quaternion.identity);
            Instantiate(gameObjects[3], new Vector3(left, -2.4f, 0), Quaternion.identity);
            Instantiate(gameObjects[3], new Vector3(right, -2.4f, 0), Quaternion.identity);
            yield return new WaitForSeconds(12);
        }
        yield return new WaitForSeconds(1);
    }
}
