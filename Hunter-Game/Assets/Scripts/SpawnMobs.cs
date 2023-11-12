using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnMobs : MonoBehaviour
{
    private float minX, maxX, minY, maxY;

    [SerializeField] private Transform[] puntos;
    [SerializeField] private GameObject[] mobs;
    [SerializeField] private float tiempoSpawn;

    private float tiempoSiguienteSpawn;

    private float mobsActuales = 0;
    public float maxMobs;

    private void Start()
    {
        maxX = puntos.Max(punto => punto.position.x);
        maxY = puntos.Max(punto => punto.position.y);
        minX = puntos.Min(punto => punto.position.x);
        minY = puntos.Min(punto => punto.position.y);
    }

    private void Update()
    {
        tiempoSiguienteSpawn += Time.deltaTime;

        if (tiempoSiguienteSpawn >= tiempoSpawn && mobsActuales < maxMobs)
        {
            tiempoSiguienteSpawn = 0;
            mobsActuales += 1;
            CrearMob();
        }
    }

    private void CrearMob()
    {
        int numeroMob = Random.Range(0, mobs.Length);
        Vector2 posicionAleatoria = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        GameObject nuevoMob = Instantiate(mobs[numeroMob], posicionAleatoria, Quaternion.identity);

       
        nuevoMob.transform.parent = transform;
    }
}
