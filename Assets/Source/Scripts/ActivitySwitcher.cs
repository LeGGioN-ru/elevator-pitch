using UnityEngine;

public class ActivitySwitcher : MonoBehaviour
{
    [SerializeField] private GameObject[] _objectsToHide;
    [SerializeField] private GameObject[] _objectsToShow;

    public void Activate()
    {
        foreach (var obj in _objectsToHide)
            obj.SetActive(false);

        foreach (var obj in _objectsToShow)
            obj.SetActive(true);
    }
}
