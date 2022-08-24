namespace App20220809.Exercises; 

public class ThirdExercise : Exercise {

    public override string Name => "Tercer ejercicio mapa";
    
    public override string Description => "Un programa para implementar un mapa de 11 filas por 10 columnas, cada elemento del array especifica el tipo de terreno en un juego así como hierba, arena, ladrillo o agua, siendo cada tipo de terreno representado por un color especifico y un carácter especifico.";
    
    private readonly static Random Random = new();
    
    public override void Execute() {

        var array = new Materials?[11, 10];

        var figure = (Figures) Random.Next(0, Enum.GetNames(typeof(Figures)).Length);
        figure.ParseFigure(array);
        
        var rotate = Random.Next(0, 4);
        while(rotate-- >0) {
            array = RotateArray(array);
        }
        
        var mirror = Random.Next(0, 2);
        if(mirror == 1) MirrorArray(array);
        
        var defaultColor = Console.ForegroundColor;

        //print
        for (int i = 0; i < array.GetLength(0); i++) {
            for (int j = 0; j < array.GetLength(1); j++) {
                var material = array[i, j];
                if(material != null)
                     Console.ForegroundColor = material.Value.GetColor();
                Console.Write(" "+(material?.GetSymbol() ?? "?").PadRight(3));
                Console.ForegroundColor = defaultColor;
            }
            Console.WriteLine();
        }
        Console.ForegroundColor = defaultColor;
    }
    
    private Materials?[,] RotateArray(Materials?[,] array) {

        var x = array.GetLength(0);
        var y = array.GetLength(1);
        
        if(array.GetLength(0) != array.GetLength(1)) {
            int max = Math.Max(array.GetLength(0), array.GetLength(1));
            var newArray = new Materials?[max, max];
            for (var i = 0; i < newArray.GetLength(0); i++) {
                for (var j = 0; j < newArray.GetLength(1); j++) {
                    if(i > x - 1|| j > y - 1) {
                        newArray[i, j] = Materials.Cement;
                    } else {
                        newArray[i, j] = array[i, j];
                    }
                }
            }
            array = newArray;
        }

        var temp = new Materials?[x, y];
        for (var i = 0; i < x; i++) {
            for (var j = 0; j < y; j++) { //rotate
                temp[i, j] = array[j, i];
            }
        }
        return temp;
    }
    
    private void MirrorArray(Materials?[,] array) {
        var temp = new Materials?[array.GetLength(0), array.GetLength(1)];
        for (var i = 0; i < array.GetLength(0); i++) {
            for (var j = 0; j < array.GetLength(1); j++) {
                temp[i, j] = array[array.GetLength(0) - i - 1, array.GetLength(1) - j - 1];   
            }
        }
        for (var i = 0; i < array.GetLength(0); i++) {
            for (var j = 0; j < array.GetLength(1); j++) {
                array[i, j] = temp[i, j];
            }
        }
    }
}

public enum Materials {
    Sand,
    Cement,
    Water,
    Grass,
}

public enum Figures {
    One, 
    Two,
}

public static class TerrainExtensions {
    
    public static void ParseFigure(this Figures figure, Materials?[,] array) {
        if(figure == Figures.One) {
            GenerateSquare(array, Materials.Sand, 4, 7);
            GenerateSquare(array, Materials.Sand, 3, 3, 5, 5);
            GenerateSquare(array, Materials.Grass, 6, 4, 5);
            GenerateSquare(array, Materials.Water, 7, 4, 1, 8);
            GenerateSquare(array, Materials.Cement, 3, 1, 8, 5);
            GenerateSquare(array, Materials.Cement, 1, 7, 8, 5);
            GenerateSquare(array, Materials.Sand, 2, 4, 9, 6);
            GenerateSquare(array, Materials.Water, 2, 2, 9, 10);
        } else {
            GenerateSquare(array, Materials.Water, 11, 10);
            GenerateSquare(array, Materials.Sand, 11, 10, 1, 3);
            GenerateSquare(array, Materials.Grass, 11, 10, 1, 6);
            GenerateSquare(array, Materials.Cement, 11, 10, 1, 9);
        }
    }
    
    private static void GenerateSquare(Materials?[,] array, Materials material, int columns, int rows, int x = 1, int y = 1) {
        y -= 1;
        x -= 1;
        for(var rowI = y; rowI < rows + y; rowI++) {
            for(var columnI = x; columnI < columns + x; columnI++) {
                if(rowI >= 0 && rowI < array.GetLength(0) && columnI >= 0 && columnI < array.GetLength(1)) {
                    array[rowI, columnI] = material;
                }
            }
        }
    }
 
    
    public static ConsoleColor GetColor(this Materials material) {
        return material switch{
            Materials.Sand => ConsoleColor.Yellow,
            Materials.Cement => ConsoleColor.Gray,
            Materials.Water => ConsoleColor.Blue,
            Materials.Grass => ConsoleColor.Green,
            _ => ConsoleColor.White
        };
    }
    
    public static string GetSymbol(this Materials material) {
        return material switch{
            Materials.Sand => "*",
            Materials.Cement => "#",
            Materials.Water => "~",
            Materials.Grass => "&",
            _ => "⚠"
        };
    }
}