README

This is a guide of how to use Modular noise to generate Noise and Terrains.

Noise
1. Right click in the assets folder and create a new noiseData with Create>ModularTerrain>Pick a noise data type
2. Use the inspector to change the variables and adjust your noise, the inspector will auto update the texture if autoUpdate is set to true

Terrains
1. Create a empty game Object
2. Add the MasterModule Component - This is where all modules attatch to
2.5. Tick AutoGenerate if you want the your changes to automatically generate the terrain (This is advised)
3. Select a starting noise from your assets folder
4. Set the Terrain target to this object or a child object
5. Be sure to set a material on the objects Mesh Renderer
6. Add Modules to change the terrain by changing the variables of the attached components
7. Repeat 6 as many times a s you like, you can rearrange the order of the list by draging it to change the order of exectution

Export To Unity Terrain
1. Create a Unity Terrain Object - Adjust the TerrainData setting to your liking (Dimensions)
2. Add the terrain to the Master Module as a reference
3. Click "Export to Terrain"