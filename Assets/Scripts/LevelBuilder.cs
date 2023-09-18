using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script is attached to the camera so that it always generates in front of it
public class LevelBuilder : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab, platformPrefab, speedUpPrefab, slowDownPrefab;
    [SerializeField] private float lastPlatformEnding, platformLength;
    [SerializeField] private int minPlatformGap, maxPlatformGap, minWindowToCamera, maxWindowToCamera;
    [SerializeField] private float minObstacleHeight, maxObstacleHeight, platformHeight, collectableHeight;

    // NOTES: window of 7 - 35 units from camera position is the space to generate in

    private void Update()
    {
        float currentPosition = transform.position.x;

        if (lastPlatformEnding - currentPosition < minWindowToCamera)
        {
            // generating the space between platforms
            float platformGap = Random.Range(minPlatformGap, maxPlatformGap+1);
            if (platformGap >= 4)
            {
                int numObstacles = Random.Range(1, 3);
                // one obstacle
                if (numObstacles == 1)
                {
                    Vector3 location = new Vector3(lastPlatformEnding + platformGap / 2, Random.Range(minObstacleHeight, maxObstacleHeight), 0f);
                    Instantiate(obstaclePrefab, location, Quaternion.identity);
                }
                // two obstacles
                else
                {
                    Vector3 location1 = new Vector3(lastPlatformEnding + platformGap / 3, Random.Range(minObstacleHeight, maxObstacleHeight), 0f);
                    Vector3 location2 = new Vector3(lastPlatformEnding + 2 * platformGap / 3, Random.Range(minObstacleHeight, maxObstacleHeight), 0f);
                    Instantiate(obstaclePrefab, location1, Quaternion.identity);
                    Instantiate(obstaclePrefab, location2, Quaternion.identity);
                }
            }
            else if (platformGap >= 2)
            {
                Vector3 location = new Vector3(lastPlatformEnding + platformGap / 2, Random.Range(minObstacleHeight, maxObstacleHeight), 0f);
                Instantiate(obstaclePrefab, location, Quaternion.identity);
            }

            // generating the platform
            float platformLocationX = lastPlatformEnding + platformGap + platformLength / 2;
            Vector3 platformLocation = new Vector3(platformLocationX, platformHeight, 0f);
            Instantiate(platformPrefab, platformLocation, Quaternion.identity);

            Debug.Log("Platform at: " + platformLocationX);

            // generating the collectables
            Vector3 collectableLocation = new Vector3(platformLocationX, collectableHeight, 0f);
            int collectableOdds = Random.Range(1, 5);
            // 1/4 chance of speed up
            if (collectableOdds == 1)
            {
                Instantiate(speedUpPrefab, collectableLocation, Quaternion.identity);
            }
            // 1/4 chance of slow down
            if (collectableOdds == 2)
            {
                Instantiate(slowDownPrefab, collectableLocation, Quaternion.identity);
            }

            // set up for next platform placement
            lastPlatformEnding = lastPlatformEnding + platformGap + platformLength;
        }
    }
}
