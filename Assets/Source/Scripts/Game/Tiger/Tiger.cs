using UnityEngine;

public class Tiger : MonoBehaviour
{
    [SerializeField] private TigerMover _tigerMover;

    public TigerMover TigerMover=> _tigerMover;

    public Tiger Init(Transform[] path, Transform spawnPoint, GameSettings gameSettings, Clicker clicker)
    {
        _tigerMover.Init(path, spawnPoint, gameSettings, clicker);
        return this;
    }
}
