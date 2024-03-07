using System.Collections.Generic;
using UnityEngine;

public class Generator
{
    public void Generate(int sizeX, int sizeY, List<List<Field>> fields, Camera cam)
    {
        for (int x = 0; x < sizeX; x++)
        {
            fields.Add(new List<Field>());
            for (int y = 0; y < sizeY; y++)
            {
                fields[x].Add(new Field());
            }
        }
        cam.transform.position = new Vector3(sizeX * 0.25f, sizeY * 0.25f, -10);
    }
}