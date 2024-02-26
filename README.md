# Voxel-Terrain-Experiments
My attempts at creating Voxel terrain in Godot. This project was created in 2021 over the span of a few nights. The code is in a semi functional state as I was experimenting with breaking meshes into chunks when I had stopped working on it. I plan on modifying the code soon to return it to its original functioning state. I also think adding the chunking method would probably not be too difficult. I definitly tried to optimize to early in creating this system which caused a ton of issues in implementation. If this system was to be used it would definitely need to be optimized but I should have focused on building more complete initial versions before dedicating to that task.

At the time I made this project Godot was version 3.4 and was using C# 6.0 with .NET 4.7.2. I updated the project to use the newer Godot 4.2.1 with .NET 6.

This is an early running example of the generation:
![A gif of vertex colored cubes generated using OpenSimplexNoise](https://github.com/Rissuvius/Voxel-Terrain-Experiments/blob/main/Landscape3.gif)

This is the last running example of the generation using a more unified color and better lighting:
![This is the last running example of the generation using a more unified color and better lighting](https://github.com/Rissuvius/Voxel-Terrain-Experiments/blob/main/Lighting.gif)

