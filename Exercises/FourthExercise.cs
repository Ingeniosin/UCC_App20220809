namespace App20220809.Exercises; 

public class FourthExercise : Exercise {

    public override string Name => "Cuarto ejercicio, calendario";
    public override string Description => "Implementar un plan de transporte anual en un array de arrays, por cada día del mes la aplicación mostrará un tipo de transporte en un color diferente siendo U para bus, B para bicicleta, C para Carro, S para tren, W para caminar. El tipo de transporte para cada día puede ser un valor aleatorio para cada tipo de transporte.";
    
    private readonly static Random Random = new();

    
    public override void Execute() {

        /*var calendar = new string */
        
        var calendar = new Types[12][];


        var dateTime = DateTime.Now;

        for (var i = 0; i < calendar.Length; i++) {
            var daysInMonth = DateTime.DaysInMonth(dateTime.Year, i + 1);
            var month = new Types[daysInMonth];
            for (var j = 0; j < month.Length; j++) {
                month[j] = (Types)Random.Next(0, Enum.GetNames(typeof(Types)).Length);
            }
            calendar[i] = month;
        }
        
        var defaultColor = Console.BackgroundColor;

        //print
        
        for (var i = 0; i < calendar.Length; i++) {
            var month = calendar[i];
            var monthString = new DateTime(dateTime.Year, i + 1, 1).ToString("MMMM");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{monthString}: ".PadRight(2));
            foreach (var day in month) {
                Console.BackgroundColor = day.GetColor();
                Console.Write(day.GetSymbol());
                Console.BackgroundColor = defaultColor;
                Console.Write($"".PadRight(2));
            }
            Console.WriteLine();
            Console.BackgroundColor = defaultColor;
        }
        
        Console.BackgroundColor = defaultColor;

    }
    
}

public enum Types {
    Bus,
    Bike,
    Car,
    Train,
    Walk
}

public static class TypesExtension {

    public static string GetSymbol(this Types type) {
        return type switch{
            Types.Bus => "U",
            Types.Bike => "B",
            Types.Car => "C",
            Types.Train => "S",
            Types.Walk => "W",
            _ => ""
        };
    }
    
    public static ConsoleColor GetColor(this Types type) {
        return type switch{
            Types.Bus => ConsoleColor.Blue,
            Types.Bike => ConsoleColor.Green,
            Types.Car => ConsoleColor.Red,
            Types.Train => ConsoleColor.Yellow,
            Types.Walk => ConsoleColor.White,
            _ => ConsoleColor.White
        };
    }
    
}