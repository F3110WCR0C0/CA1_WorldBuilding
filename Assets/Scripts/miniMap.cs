using UnityEngine;

public class miniMap : MonoBehaviour
{
    public float heightAbovePlayer;
    public Transform Player;

    private void LateUpdate()
    {
        transform.position = new Vector3(Player.position.x, Player.position.y + heightAbovePlayer, Player.position.z);
    }

}