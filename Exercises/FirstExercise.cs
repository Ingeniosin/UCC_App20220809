namespace App20220809.Exercises;

public class FirstExercise : Exercise{
    public override string Name => "Primer ejercicio arreglos";

    public override string Description => "Un programa que pida los nombres de personas y luego permita preguntarle al usuario cual elemento del array quiere visualizar";
    
    public override void Execute(){
        var cantidadPersonas = InputUtils.GetNumber("Ingrese la cantidad de personas a ingresar: ", x => x > 0);
        var personas = new string[cantidadPersonas];
        for (var i = 1; i <= cantidadPersonas; i++){
            personas[i-1] = InputUtils.GetText($"Ingrese el nombre de la persona {i}: ");
        }

        while (true){
            var indice = InputUtils.GetNumber("Ingrese el indice del elemento a visualizar [-1 para salir]: ", x => x >= -1 && x <= cantidadPersonas);
            if (indice <= 0) break;
            Console.WriteLine($"El nombre de la persona {indice} es: {personas[indice - 1]}");
        }
    }
}