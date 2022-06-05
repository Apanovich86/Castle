using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    [Header("Set in Inspector")] // a
    public GameObject cloudsphere;
    public int numSpheresMin = 6;
    public int numSpheresMax = 10;
    public Vector3 sphereOffsetScale = new Vector3(5, 2, 1);
    public Vector2 sphereScaleRangeX = new Vector2(4, 8);
    public Vector2 sphereScaleRangeY = new Vector2(3, 4);
    public Vector2 sphereScaleRangeZ = new Vector2(2, 4);
    public float scaleYMin = 2f;
    private List<GameObject> spheres; // b
    void Start()
    {
        spheres = new List<GameObject>();
        int num = Random.Range(numSpheresMin, numSpheresMax); // c
        for (int i = 0; i < num; i++)
        {
            GameObject sp = Instantiate<GameObject>(cloudsphere); // d
            spheres.Add(sp);
            Transform spTrans = sp.transform;
            spTrans.SetParent(this.transform);
            // Выбрать случайное местоположение
            Vector3 offset = Random.insideUnitSphere; // e
            offset.x *= sphereOffsetScale.x;
            offset.у *= sphereOffsetScale.y;
            offset.z *= sphereOffsetScale.z;
            spTrans.localposition = offset; // f
                                            // Выбрать случайный масштаб
            Vector3 scale = Vector3.one; // g
            scale.x = Random.Range(sphereScaleRangeX.x, sphereScaleRangeX.y);
            scale.у = Random.Range(sphereScaleRangeY.x, sphereScaleRangeY.y);
            scale.z = Random.Range(sphereScaleRangeZ.x, sphereScaleRangeZ.y);
            scale.у *= 1 - (Mathf.Abs(offset.х) / sphereOffsetScale.x); // h
            scale.у = Mathf.Max(scale.у, scaleYMin);
            spTrans.localscale = scale;
        }  

    }
    // Update вызывается в каждом кадре
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //Restart();
        //}
    }
    void Restart()
    {
        // Удалить старые сферы, составляющие облако
        foreach (GameObject sp in spheres)
        {
        Destroy(sp);
        }
        Start();
    }
}

