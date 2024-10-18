using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GridManager))]
public class GridManagerEditor : Editor
{
    private GridManager gridManager;
    private GameObject selectedPrefab;

    private void OnEnable()
    {
        gridManager = (GridManager)target;
    }

    private void OnSceneGUI()
    {
        // Grid'i �iz
        DrawGrid();

        // Fare ile sahnede t�klama yap�ld���nda obje yerle�tir
        HandleMouseClick();
    }

    // Grid'i sahnede �izmek i�in
    private void DrawGrid()
    {
        Handles.color = Color.gray;
        for (int x = 0; x <= gridManager.columns; x++)
        {
            for (int y = 0; y <= gridManager.rows; y++)
            {
                Vector3 start = gridManager.GetWorldPosition(x, y);
                Vector3 endX = gridManager.GetWorldPosition(x + 1, y);
                Vector3 endY = gridManager.GetWorldPosition(x, y + 1);

                // Yatay �izgiler
                if (x < gridManager.columns)
                {
                    Handles.DrawLine(start, endX);
                }

                // Dikey �izgiler
                if (y < gridManager.rows)
                {
                    Handles.DrawLine(start, endY);
                }
            }
        }
    }

    // Fare ile t�klan�lan yere obje yerle�tirmek i�in
    private void HandleMouseClick()
    {
        Event e = Event.current;
        if (e.type == EventType.MouseDown && e.button == 0) // Sol t�klama
        {
            Ray ray = HandleUtility.GUIPointToWorldRay(e.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector2Int gridPos = gridManager.GetGridPosition(hit.point);
                Vector3 spawnPos = gridManager.GetWorldPosition(gridPos.x, gridPos.y);

                if (selectedPrefab != null)
                {
                    // Prefab'� yerle�tir
                    Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
                }
            }
        }
    }

    public override void OnInspectorGUI()
    {
        // GridManager'�n normal inspekt�r�n� g�ster
        base.OnInspectorGUI();

        // Objeleri yerle�tirmek i�in prefab se�
        selectedPrefab = (GameObject)EditorGUILayout.ObjectField("Placeable Object", selectedPrefab, typeof(GameObject), false);
    }
}