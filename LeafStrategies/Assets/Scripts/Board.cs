using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private GameObject blockPrefab;

    public int sizeX;
    public int sizeY;
    private List<List<Field>> fields = new List<List<Field>>();

    private Generator generator = new Generator();

    private void Start()
    {
        generator.Generate(sizeX, sizeY, fields, Camera.main);
        Render();
    }

    public void Render()
    {
        for (int x = 0; x < fields.Count; x++)
        {
            for (int y = 0; y < fields[x].Count; y++)
            {
                GameObject block = Instantiate(blockPrefab, new Vector3(x * 0.5f, y * 0.5f, 0), Quaternion.identity, transform);
            }
        }
    }
}