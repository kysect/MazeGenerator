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

https://github.com/kysect/MazeGenerator/blob/900e3bb19168dc95cc1e1b15b82e71bce4338867/Source/Kysect.MazeGenerator.Console/Program.cs#L5-L30
