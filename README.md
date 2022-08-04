# ModularProceduralGeneration
Terrain generation Tool for Unity using Modular Components


![Modified](https://user-images.githubusercontent.com/72665691/172989747-26312928-644a-4692-bc2d-113ce2770e4c.png)
![NoiseDataInheritanceModel](https://user-images.githubusercontent.com/72665691/172990090-3740d64c-014b-446d-b30c-5054c7493e72.png)
![ModuleInheritanceModule](https://user-images.githubusercontent.com/72665691/172990095-9f5ca1a9-2bdd-48ce-afbc-50760023a097.png)
![Sprint3](https://user-images.githubusercontent.com/72665691/172990113-538f33dc-32ba-453a-9edc-c83e55937006.PNG)
![Sprint3SO](https://user-images.githubusercontent.com/72665691/172990116-294f134b-3e82-4087-b19e-f94268769543.PNG)
![Creater](https://user-images.githubusercontent.com/72665691/172990252-f745c7e8-1bcc-4dc6-becc-73c50ece5ce3.PNG)
![Creater3](https://user-images.githubusercontent.com/72665691/172990260-739c8912-556b-41ae-8935-06ae08ea2118.PNG)
![Creater5](https://user-images.githubusercontent.com/72665691/172990261-4e5429c4-a8da-435d-a281-5d1f4b34bd69.PNG)
![Landscape](https://user-images.githubusercontent.com/72665691/172990262-5175848f-11d3-40b8-881d-9b4fe25afc9a.PNG)
![Terrain Export](https://user-images.githubusercontent.com/72665691/172990264-6a13c738-c6bd-42ae-bc8a-a0863586e9d7.PNG)
![Terrain](https://user-images.githubusercontent.com/72665691/172990265-3f66141c-011b-4fa8-86b9-2187a76c6497.PNG)
![Terrains#](https://user-images.githubusercontent.com/72665691/172990437-d344928e-2822-4315-9e9c-54d56526fc32.png)

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



