using UnityEngine;

public class Node : MonoBehaviour
{
    [Header("Unity Setup Fields")]
    public Vector3 PositionOffset;
    public Color HoverColor = Color.grey;
    public Color InvalidColor = Color.red;

    private Renderer _renderer;
    private Color _originalColor = Color.white;
    private GameObject _turret;

    // Start is called before the first frame update
    private void Start()
    {
        _renderer = gameObject.GetComponent<Renderer>();
        _originalColor = _renderer.material.color;
    }

    private void OnMouseEnter()
    {
        _renderer.material.color = _turret != null ? InvalidColor : HoverColor;
    }

    private void OnMouseExit()
    {
        _renderer.material.color = _originalColor;
    }

    private void OnMouseDown()
    {
        if (_turret != null)
        {
            return;
        }

        var turret = BuildManager.Instance.GetSelectedTurret();

        _turret = Instantiate(turret, gameObject.transform.position + PositionOffset, gameObject.transform.rotation);

        _renderer.material.color = InvalidColor;
    }
}
