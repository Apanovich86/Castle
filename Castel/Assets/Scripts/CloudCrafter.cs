using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCrafter : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Set in Inspector”)]
 public
 public
 public
 public
 public
 public
 public
 int
 GameObject
Vector3
Vector3
float
float
float
// Число облаков
// Шаблон для облаков
numClouds = 40;
    cloudPrefab;
cloudPosMin = new Vector3(-50,-5,10);
    cloudPosMax = new Vector3(150,100,10);
    cloudScaleMin =1; // Мин. масштаб каждого облака
cloudScaleMax = 3; // Макс, масштаб каждого облака
cloudSpeedMult = 0.5f; // Коэффициент скорости облаков
private GameObject[] cloudinstances;
    void Awake()
    {
        // Создать массив для хранения всех экземпляров облаков
        cloudinstances = new GameObject[numClouds];
        // Найти родительский игровой объект CloudAnchor
        GameObject anchor = GameObject.Find("CloudAnchor”);
        // Создать в цикле заданное количество облаков
        GameObject cloud;
        for (int i = 0; i < numClouds; i++)
        {
            // Создать экземпляр cloudPrefab
            cloud = Instantiate<GameObject>(cloudPrefab);
            // Выбрать местоположение для облака
            Vector3 cPos = Vector3.zero;
            cPos.x = Random.Range(cloudPosMin.x, cloudPosMax.x);
            cPos.y = Random.Range(cloudPosMin.y, cloudPosMax.у);
            // Масштабировать облако
            float scaleU = Random.value;
            float scaleVal = Mathf.Lerp(cloudScaleMin, cloudScaleMax, scaleU);
            // Меньшие облака (с меньшим значением scaleU) должны быть ближе
            // к земле
            cPos.y = Mathf.Lerp(cloudPosMin.у, cPos.y, scaleU);
            // Меньшие облака должны быть дальше
            cPos.z = 100 - 90 * scaleU;
            // Применить полученные значения координат и масштаба к облаку
            cloud.transform.position = cPos;
            cloud.transform.localscale = Vector3.one ♦ scaleVal;
            // Сделать облако дочерним по отношению к anchor
            cloud.transform.SetParent(anchor.transform);
            cloudinstances[i] = cloud;


            // Update is called once per frame
            void Update()
    {
                foreach (GameObject cloud in cloudinstances)
                {
                    // Получить масштаб и координаты облака
                    float scaleVal = cloud.transform.localScale.x;
                    Vector3 cPos = cloud.transform.position;
                    // Увеличить скорость для ближних облаков
                    cPos.x -= scaleVal * Time.deltaTime ♦ cloudSpeedMult;
                    // Если облако сместилось слишком далеко влево...
                    if (cPos.x <= cloudPosMin.x)
                    {
                        // Переместить его далеко вправо
                        cPos.x = cloudPosMax.x;
                    }
                    // Применить новые координаты к облаку
                    cloud.transform.position = cPos;
                }
            }
