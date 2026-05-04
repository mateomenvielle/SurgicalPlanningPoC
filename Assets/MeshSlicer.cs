using UnityEngine;
using EzySlice;

public class MeshSlicer : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject target;
    [SerializeField] private Transform plane;
    [SerializeField] private Material sliceMaterial;

    private GameObject upperPart;
    private GameObject lowerPart;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("⎵ SPACE detectado");
            Slice();
        }
    }

    public void Slice()
    {
        if (target == null || plane == null)
        {
            Debug.LogError("❌ Referencias no asignadas");
            return;
        }

        if (!target.activeInHierarchy)
        {
            Debug.LogWarning("⚠️ El target ya fue cortado");
            return;
        }

        Debug.Log("✂️ Intentando cortar...");

        // Debug del plano
        Debug.DrawRay(plane.position, plane.up * 0.5f, Color.red, 2f);

        // 🔥 CORTE DINÁMICO (LO IMPORTANTE)
        var hull = target.Slice(plane.position, plane.up);

        if (hull == null)
        {
            Debug.LogError("❌ NO CORTA → el plano no está intersectando el mesh");
            return;
        }

        // fallback de material
        Material mat = sliceMaterial;
        if (mat == null)
        {
            var renderer = target.GetComponent<MeshRenderer>();
            if (renderer != null)
                mat = renderer.material;
        }

        upperPart = hull.CreateUpperHull(target, mat);
        lowerPart = hull.CreateLowerHull(target, mat);

        upperPart.transform.SetPositionAndRotation(target.transform.position, target.transform.rotation);
        lowerPart.transform.SetPositionAndRotation(target.transform.position, target.transform.rotation);

        // separación leve (no exagerada)
        upperPart.transform.Translate(Vector3.up * 0.05f, Space.World);
        lowerPart.transform.Translate(Vector3.down * 0.05f, Space.World);

        target.SetActive(false);

        Debug.Log("✅ CORTE OK");
    }

    public void RemoveProximal()
    {
        if (upperPart != null)
        {
            Destroy(upperPart);
            Debug.Log("🗑️ Proximal eliminado");
        }
        else
        {
            Debug.LogWarning("No hay parte proximal");
        }
    }

    public void RemoveDistal()
    {
        if (lowerPart != null)
        {
            Destroy(lowerPart);
            Debug.Log("🗑️ Distal eliminado");
        }
        else
        {
            Debug.LogWarning("No hay parte distal");
        }
    }
}