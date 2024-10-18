using UnityEditor;
using UnityEngine;

public class MaterialAssigner : EditorWindow
{
    private enum MaterialType
    {
        None,
        MaterialA,
        MaterialB,
        MaterialC
    }

    private MaterialType selectedMaterialType = MaterialType.None;

    // Materyal referanslarý
    private Material materialA;
    private Material materialB;
    private Material materialC;

    private const string MaterialAKey = "MaterialAssigner_MaterialA";
    private const string MaterialBKey = "MaterialAssigner_MaterialB";
    private const string MaterialCKey = "MaterialAssigner_MaterialC";

    [MenuItem("Tools/Assign Material to Selected")]
    public static void ShowWindow()
    {
        GetWindow<MaterialAssigner>("Material Assigner");
    }

    private void OnEnable()
    {
        // EditorPrefs'ten materyalleri yükle
        materialA = AssetDatabase.LoadAssetAtPath<Material>(EditorPrefs.GetString(MaterialAKey, ""));
        materialB = AssetDatabase.LoadAssetAtPath<Material>(EditorPrefs.GetString(MaterialBKey, ""));
        materialC = AssetDatabase.LoadAssetAtPath<Material>(EditorPrefs.GetString(MaterialCKey, ""));
    }

    private void OnGUI()
    {
        GUILayout.Label("Assign Material to Selected Objects", EditorStyles.boldLabel);

        selectedMaterialType = (MaterialType)EditorGUILayout.EnumPopup("Select Material Type", selectedMaterialType);

        // Materyalleri yükle
        materialA = (Material)EditorGUILayout.ObjectField("Material A", materialA, typeof(Material), false);
        materialB = (Material)EditorGUILayout.ObjectField("Material B", materialB, typeof(Material), false);
        materialC = (Material)EditorGUILayout.ObjectField("Material C", materialC, typeof(Material), false);

        if (GUILayout.Button("Assign Material"))
        {
            AssignMaterialToSelected();
        }

        // Materyalleri kaydet
        if (GUI.changed)
        {
            EditorPrefs.SetString(MaterialAKey, AssetDatabase.GetAssetPath(materialA));
            EditorPrefs.SetString(MaterialBKey, AssetDatabase.GetAssetPath(materialB));
            EditorPrefs.SetString(MaterialCKey, AssetDatabase.GetAssetPath(materialC));
        }
    }

    private void AssignMaterialToSelected()
    {
        Material materialToAssign = null;

        switch (selectedMaterialType)
        {
            case MaterialType.MaterialA:
                materialToAssign = materialA;
                break;
            case MaterialType.MaterialB:
                materialToAssign = materialB;
                break;
            case MaterialType.MaterialC:
                materialToAssign = materialC;
                break;
            case MaterialType.None:
            default:
                Debug.LogWarning("Please select a material type.");
                return;
        }

        if (materialToAssign == null)
        {
            Debug.LogWarning("Selected material is not assigned.");
            return;
        }

        foreach (GameObject obj in Selection.gameObjects)
        {
            // Tüm child'larda Renderer bileþenini bul
            Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();
            if (renderers.Length > 0)
            {
                foreach (var renderer in renderers)
                {
                    renderer.material = materialToAssign;
                    Debug.Log($"Assigned {materialToAssign.name} to {renderer.gameObject.name}");
                }
            }
            else
            {
                Debug.LogWarning($"{obj.name} does not have any Renderer components in its children.");
            }
        }
    }
}