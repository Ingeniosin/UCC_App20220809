namespace App20220809 {
   public static class InputUtils {
      
      public static bool GetBool(string text) {
         while(true) {
            var options = new List<string> { "Si", "No" };
            var option = GetOption(text, options, x => x);
            return option.Equals(options[0]);
         }
      }

      public static void SelectFunction( Dictionary<string, Action> dictionary, string text = "Selecciona una opcion: ", Action onPreExecute = null, Action onPostExecute = null) {
         var dictionaryKeys = dictionary.Keys.Select(x => x.ToString()).ToList();
         var option = GetOption(text, dictionaryKeys, x => x);
         onPreExecute?.Invoke();
         Console.WriteLine();
         dictionary[option]();
         onPostExecute?.Invoke();
      }

      public static T GetOption<T>(string text, Type ennm) {
         var options = (from object value in Enum.GetValues(ennm) select value.ToString()).ToList();
         var option = GetOption(text, options, x => x);
         return (T)Enum.Parse(ennm, option);
      }

      public static T MessageReturn<T>(string text, T type) {
         Console.WriteLine(text);
         return type;
      }
      
      public static T GetOption<T>(string text, List<T> elements, Func<T, string> display, bool returnOption = false, Func<T, bool> condition = null) {
         while(true) {
            Console.WriteLine();  
            if(text != null) {
               Console.WriteLine(text);
               Console.WriteLine();  
            }
            elements.ForEach(e => Console.WriteLine($"{elements.IndexOf(e) + 1} - {display(e)}"));
            if(returnOption) {
               Console.WriteLine($"{elements.Count + 1} - Regresar");
            }
            Console.WriteLine();
            var result = GetNumber("Seleciona una opcion: ", x => x > 0 && x <= elements.Count + (returnOption ? 1 : 0));
            if(returnOption && result == elements.Count + 1) {
               return default;
            }
            var selected = elements[result - 1];
            if(condition == null || condition(selected)) return selected;
            Console.Write("El valor ingresado no es valido, intenta de nuevo..");
            Console.WriteLine();
         }
      }
      
      public static string GetText(string text, Func<string, bool> condition = null) {
         while(true) {
            Console.Write(text);
            var result = Console.ReadLine();
            if(condition == null || condition(result)) return result;
            Console.WriteLine("El valor ingresado no es valido, intenta de nuevo..");
         }
      }

      public static int GetNumber(string text, Func<int, bool> condition = null) {
         while(true) {
            Console.Write(text);
            if(int.TryParse(Console.ReadLine(), out var number) && (condition == null || condition(number))) return number;
            Console.WriteLine("El valor ingresado no es valido, intenta de nuevo.");
         }
      }

      public static double GetDouble(string text, Func<double, bool> condition = null) {
         while(true) {
            Console.Write(text);
            if(double.TryParse(Console.ReadLine(), out var number) && (condition == null || condition(number))) return number;
            Console.WriteLine("El valor ingresado no es valido, intenta de nuevo.");
         }
      }

      public static double? GetDoubleNullable(string text, Func<double, bool> condition = null) {
         while(true) {
            Console.Write(text);
            var readLine = Console.ReadLine();
            if(readLine == null || readLine.Trim() == "") return null;
            if(double.TryParse(readLine, out var number) && (condition == null || condition(number))) return number;
            Console.WriteLine("El valor ingresado no es valido, intenta de nuevo.");
         }
      }


      public static int? GetNumberNullable(string text, Func<int, bool> condition = null) {
         while(true) {
            Console.Write(text);
            var readLine = Console.ReadLine();
            if(readLine == null || readLine.Trim() == "") return null;
            if(int.TryParse(readLine, out var number) && (condition == null || condition(number))) return number;
            Console.WriteLine("El valor ingresado no es valido, intenta de nuevo.");
         }
      }
      
      public static void PressToContinue() {
         Console.WriteLine();
         Console.Write("Toca una tecla para continuar...");
         Console.ReadKey();
         Console.WriteLine();
      }
      
   }
}