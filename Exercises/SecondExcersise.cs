namespace App20220809.Exercises;

public class SecondExcersise : Exercise{
    public override string Name => "Segundo ejercicio de arreglos";

    public override string Description => "Un programa que calcule las tabla de multiplicar del 1 al 10, las almacene en un array y luego las muestre";
    
    public override void Execute(){
        var tables = new int[10][];

       for(var i = 1; i <= 10; i++){
           tables[i-1] = new int[10];
           for(var j = 1; j <= 10; j++){
               tables[i-1][j-1] = i * j;
           }
       }
       
       for(var i = 0; i < 10; i++){
           for(var j = 0; j < 10; j++){
               Console.Write($"{$"{tables[i][j]}",-5}");
           }
           Console.WriteLine();
       }

    }
}