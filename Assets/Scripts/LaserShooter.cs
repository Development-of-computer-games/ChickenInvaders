using UnityEngine;

/**
 * This component spawns the given laser-prefab whenever the player clicks a given key.
 * It also updates the "scoreText" field of the new laser.
 */
public class LaserShooter : KeyboardSpawner
{


    protected override GameObject spawnObject()
    {
        GameObject newObject = base.spawnObject();  // base = super


        return newObject;
    }
}
