using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    public class Square
    {
        public static readonly int BOTTOMLEFT = 0;
        public static readonly int BOTTOMCENTER = 1;
        public static readonly int BOTTOMRIGHT = 2;
        public static readonly int CENTERLEFT = 3;
        public static readonly int CENTERRIGHT = 5;
        public static readonly int TOPLEFT = 6;
        public static readonly int TOPCENTER = 7;
        public static readonly int TOPRIGHT = 8;


        public int[] vertices = {0, 0, 0, 0, -1, 0, 0, 0, 0};

        public Square(int bottomleft, int bottomcenter, int bottomright, int centerleft, int centerright, int topleft, int topcenter, int topright)
        {
            vertices[BOTTOMLEFT] = bottomleft;
            vertices[BOTTOMCENTER] = bottomcenter;
            vertices[BOTTOMRIGHT] = bottomright;

            vertices[CENTERLEFT] = centerleft;
            vertices[CENTERRIGHT] = centerright;

            vertices[TOPLEFT] = topleft;
            vertices[TOPCENTER] = topcenter;
            vertices[TOPRIGHT] = topright;
        }
    }

    [SerializeField] private Vector2Int size = new Vector2Int(3, 5);

    public Vector2Int Size { get => size; }

    private List<Square> squares = new List<Square>();

    private Mesh mesh;

    private List<Vector3> vertices;
    private List<int> triangles;

    private void Start()
    {
        mesh = new Mesh();

        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();
    }

    private void CreateShape()
    {
        for(int x = 0; x < size.x; x++)
        {
            for(int y = 0; y < size.y; y++)
            {
                if (x == 0 && y == 0)
                    vertices.Add(new Vector3(x, y, 0));

                if (x == 0)
                {
                    vertices.Add(new Vector3(x, y + .5f, 0));
                    vertices.Add(new Vector3(x, y + 1f, 0));
                }

                if (y == 0)
                {
                    vertices.Add(new Vector3(x + .5f, y, 0));
                    vertices.Add(new Vector3(x + 1f, y, 0));
                }

                vertices.Add(new Vector3(x + 1f, y + .5f, 0));
                vertices.Add(new Vector3(x + .5f, y + 1f, 0));
                vertices.Add(new Vector3(x + 1f, y + 1f, 0));
                
                squares.Add(new Square(1, 2, 3, 4, 5, 6, 7, 8));

            }

        }
    }

    private void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();

        mesh.RecalculateNormals();
    }
}

public class ListExtension
{
    // TODO: extension for int list to add a triangle
}
