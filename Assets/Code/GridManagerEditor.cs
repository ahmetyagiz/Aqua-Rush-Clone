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
        // Grid'i çiz
        DrawGrid();

        // Fare ile sahnede týklama yapýldýðýnda obje yerleþtir
        HandleMouseClick();
    }

    // Grid'i sahnede çizmek için
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

                // Yatay çizgiler
                if (x < gridManager.columns)
                {
                    Handles.DrawLine(start, endX);
                }

                // Dikey çizgiler
                if (y < gridManager.rows)
                {
                    Handles.DrawLine(start, endY);
                }
            }
        }
    }

    // Fare ile týklanýlan yere obje yerleþtirmek için
    private void HandleMouseClick()
    {
        Event e = Event.current;
        if (e.type == EventType.MouseDown && e.button == 0) // Sol týklama
        {
            Ray ray = HandleUtility.GUIPointToWorldRay(e.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector2Int gridPos = gridManager.GetGridPosition(hit.point);
                Vector3 spawnPos = gridManager.GetWorldPosition(gridPos.x, gridPos.y);

                if (selectedPrefab != null)
                {
                    // Prefab'ý yerleþtir
                    Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
                }
            }
        }
    }

    public override void OnInspectorGUI()
    {
        // GridManager'ýn normal inspektörünü göster
        base.OnInspectorGUI();

        // Objeleri yerleþtirmek için prefab seç
        selectedPrefab = (GameObject)EditorGUILayout.ObjectField("Placeable Object", selectedPrefab, typeof(GameObject), false);
    }
}