using UnityEngine;
using System.Collections;
 
public class SpectrumAnalyzer : MonoBehaviour {
 
    public GameObject cubePrefab;
    public GameObject[] cubes;
    public float[] numbers = new float[1024];
    public float speed = 0.2f;
    public float spectrumModifier = 30;
    public int initialBlocks = 10;
    public float distance = 5;
    public int rings = 5;
    int bestFrequency;
 
    void Start() {
        for (int r = 1; r <= rings; r++) {
            int blocks = initialBlocks * r;
            float angles = 360 / blocks;
            for (int n = 0; n < blocks; n++) {
                float angle = n * angles;
                GameObject gO = Instantiate(cubePrefab) as GameObject;
                gO.transform.localPosition = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle) * distance * r, 0, Mathf.Sin(Mathf.Deg2Rad * angle) * distance * r);
                gO.transform.eulerAngles = new Vector3(0, -angle, 0);
            }
        }
 
        cubes = GameObject.FindGameObjectsWithTag("cubes");
 
        bestFrequency = 1024 / cubes.Length;
    }
 
    void Update() {
        Camera.main.gameObject.GetComponent<AudioSource>().GetOutputData(numbers, 0);
 
        for (int i = 0; i < cubes.Length; i++) {
            cubes[i].transform.localScale = Vector3.Lerp(cubes[i].transform.localScale, new Vector3(cubes[i].transform.localScale.x, numbers[i * bestFrequency] * spectrumModifier * Mathf.PerlinNoise(numbers[i * bestFrequency], Time.time), cubes[i].transform.localScale.z), speed);
        }
    }
}