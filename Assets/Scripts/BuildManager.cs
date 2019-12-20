using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;

    [Header("Unity Setup Fields")]
    public GameObject StandardTurretPrefab;
    
    private GameObject _selectedTurret;

    public GameObject GetSelectedTurret()
    {
        return _selectedTurret;
    }

    // Awake is called before Start method
    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        // Default to Standard Turret
        _selectedTurret = StandardTurretPrefab;
    }
}
