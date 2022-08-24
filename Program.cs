using App20220809;
using App20220809.Exercises;

var exercises = new List<Exercise>{
    new FirstExercise(),
    new SecondExcersise(),
    new ThirdExercise(),
};

while (true){
    var seleccion = InputUtils.GetOption("Ingrsa el ejercicio a ejecutar: ", exercises, x => $"{x.Name}: \n\t * {x.Description}", true);
    if (seleccion == null) break;
    Console.Clear();
    var initialTime = DateTime.Now.Ticks;
    seleccion.Execute();
    var finalTime = DateTime.Now.Ticks;
    var time = (finalTime - initialTime) / TimeSpan.TicksPerMillisecond;
    Console.WriteLine();
    Console.WriteLine($"Tiempo de ejecución: {time} ms");
    InputUtils.PressToContinue();
    Console.Clear();
}

InputUtils.PressToContinue();


