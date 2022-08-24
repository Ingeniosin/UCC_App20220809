using System.Collections;

namespace App20220809.Exercises;



public class ThirdExercise : Exercise{
    public override string Name => "Tercer ejercicio arreglos";

    private static Random _random = new Random();
    private int _probabilidadJuntos = 8; //de 10
    
    public override string Description => "Un programa para implementar un mapa de 11 filas por 10 columnas, cada elemento del array especifica el tipo de terreno en un juego así como hierba, arena, ladrillo o agua, siendo cada tipo de terreno representado por un color especifico y un carácter especifico";

    public void Run() {
        var filas = InputUtils.GetNumber("Ingrese el numero de filas: ");
        var columnas = InputUtils.GetNumber("Ingrese el numero de columnas: ");
        var cantidadItems = filas * columnas;

        var figuras = new Dictionary<string, ConsoleColor> {
            {"*", ConsoleColor.Yellow},
            {"#", ConsoleColor.Blue},
            {"&", ConsoleColor.Red},
            {"~", ConsoleColor.Green}
        };
        
        var promedio = cantidadItems / figuras.Count;
        var cantidadFiguras = figuras.Keys.ToDictionary(figurasKey => figurasKey, _ => _random.Next(promedio - 5, promedio + 5));
        var sum = cantidadFiguras.Values.Sum();
        var diff = cantidadItems - sum;

        while(diff > 0) {
            cantidadFiguras[cantidadFiguras.Keys.ToList()[_random.Next(0, figuras.Count-1)]]--;
            diff--;
        }

        while(diff < 0) {
            cantidadFiguras[cantidadFiguras.Keys.ToList()[_random.Next(0, figuras.Count-1)]]++;
            diff++;
        }
        
        var output = new int[filas][];

        for(var i = 0; i < output.Length; i++) {
            var fila = new int[columnas];
            var filaArriba = i > 0 ? output[i-1] : null;
            output[i] = fila;
            
            
            
            
            
            
            
        }
        
        ArrayList arrList2 = new ArrayList();
        arrList2.Add(1);
        arrList2.Add("2");
        arrList2.Add(3);

        var o = arrList2[0];

    }
    
    public string GetFigura(Dictionary<string, int> figuras, int a) {
        return figuras.Keys.ToList()[_random.Next(0, figuras.Count)];
    }
    
    
    public bool EsJuntos() {
        var numero = _random.Next(1, 4);
        return numero is 1 or 2;
    }
    
    public override void Execute() {

        Run();
        return;
        
        var filas = InputUtils.GetNumber("Ingrese el numero de filas: ");
        var columnas = InputUtils.GetNumber("Ingrese el numero de columnas: ");
        var cantidadItems = filas * columnas;

        var figuras = new Dictionary<string, ConsoleColor> {
            {"*", ConsoleColor.Yellow},
            {"#", ConsoleColor.Blue},
            {"&", ConsoleColor.Red},
            {"~", ConsoleColor.Green}
        };
        
        var promedio = cantidadItems / figuras.Count;

        var cantidadFiguras = figuras.Keys.ToDictionary(figurasKey => figurasKey, _ => _random.Next(promedio - 5, promedio + 5));

        var sum = cantidadFiguras.Values.Sum();
        var diff = cantidadItems - sum;

        while(diff > 0) {
            cantidadFiguras[cantidadFiguras.Keys.ToList()[_random.Next(0, figuras.Count-1)]]--;
            diff--;
        }

        while(diff < 0) {
            cantidadFiguras[cantidadFiguras.Keys.ToList()[_random.Next(0, figuras.Count-1)]]++;
            diff++;
        }

        var output = new string[filas][];
        
        for(var i = 0; i < filas; i++) {
            var fila = new string[columnas];

            if(i == 0) {
                for(var j = 0; j < columnas; j++) {
                    var nextItem = cantidadFiguras.Keys.ToList()[_random.Next(0, cantidadFiguras.Count)];
                    var prevItem = j > 0 ? fila[j-1] : null;
                    if(prevItem != null && prevItem == nextItem) {
                        var juntos = _random.Next(_probabilidadJuntos, 11) >= 5;
                        while(!juntos && prevItem == nextItem) {
                            nextItem = cantidadFiguras.Keys.ToList()[_random.Next(0, cantidadFiguras.Count)];
                        }
                        
                        
                    }
                    cantidadFiguras[nextItem]--;
                    if(cantidadFiguras[nextItem] < 0)
                        cantidadFiguras.Remove(nextItem);
                    
                    fila[j] = nextItem;
                }
            }
            else {
                for(var j = 0; j < columnas; j++) {
                    if(cantidadFiguras.Count == 0)
                        break;
                    var nextItem = cantidadFiguras.Keys.ToList()[_random.Next(0, cantidadFiguras.Count)];
                    var filaAnterior = output[i-1];
                    var top = filaAnterior[j];
                    var left = j > 0 ? filaAnterior[j-1] : null;
                    var right = j < columnas - 1 ? filaAnterior[j+1] : null;
                    var esArriba = (top != null && top == nextItem) || (left != null && left == nextItem) || (right != null && right == nextItem);
                    var esIzquierda = j > 0 && fila[j-1] == nextItem;
                    var prevItem = esArriba || esIzquierda ? nextItem : null;
                    if(prevItem != null && prevItem == nextItem) {
                        var juntos = _random.Next(_probabilidadJuntos, 11) >= 5;
                        while(!juntos && prevItem == nextItem) {
                            if(cantidadFiguras.Keys.Count == 1)
                                break;
                            nextItem = cantidadFiguras.Keys.ToList()[_random.Next(0, cantidadFiguras.Count)];
                        }
        
                    }
                    cantidadFiguras[nextItem]--;
                    if(cantidadFiguras[nextItem] < 0)
                        cantidadFiguras.Remove(nextItem);
                    
                    fila[j] = nextItem;
                }
            }
            
            output[i] = fila;
        }
        


        foreach (var fila in output) {
            foreach (var item in fila) {
                if(item == null) 
                    continue;
                Console.ForegroundColor = figuras[item];
                Console.Write(item);
            }
            Console.WriteLine();
        }




    }
}