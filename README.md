# MazeGenerator
![Nuget](https://img.shields.io/nuget/v/Kysect.MazeGenerator?style=flat-square)


MazeGenerator - учебная библиотека, которая позволяет генерировать карты для игры в лабиринт.


Карта лабиринта представляет из себя матрицу Сells[][]
```C#
public enum Cells
{
    Wall,
    Empty,
    Exit
}
```

Пример создания лабиринта

https://github.com/kysect/MazeGenerator/blob/89657d5857d39e5961e1231bda079e7c4a863da4/Source/Kysect.MazeGenerator.Console/Program.cs
