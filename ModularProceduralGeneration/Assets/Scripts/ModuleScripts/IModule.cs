using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IModule 
{
    public float[,] OnIProcessMap(float[,] noiseMapInput);

    public bool OnIReturnInclude();

    /*
     *  int width = noiseMapInput.GetLength(0);
        int height = noiseMapInput.GetLength(1);


        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                

            }
        }


        return noiseMapInput;
     * 
     * 
     */

}
