decimal typedNumber = 0;
decimal grade_accumulator;
int typedOption;
string typedOption3;
var typedOption2 = "";
decimal result = 0;
string symbol = "+";
bool running = true;

while (running){

    try   
    {
        Console.WriteLine("\n-- Sistema de calculo y promedio --\n");

        Console.WriteLine("Elegir una opcion: \n1.Calculadora\n2.Promediar nota\n3.Salir\n");
        typedOption = int.Parse(Console.ReadLine());

        switch (typedOption)
        {
            case 1:
                Console.WriteLine("-- Calculadora --\n");
                Console.WriteLine("Seleccione la operacion que desea realizar:");
                Console.WriteLine("1. Suma\n2. Resta\n3. Multiplicacion\n4. Division\n5. Salir\n");

                
                Console.Write("Opcion: ");
                int typedOperation = int.Parse(Console.ReadLine());   

                if (typedOperation == 5)
                {
                    Console.WriteLine("\n\tVolviendo al menu principal...");
                    break;   
                }

                if (typedOperation < 1 || typedOperation > 4)
                {
                    Console.WriteLine("\nOperacion invalida");
                    break;
                }

                List<decimal> numbers = new();

                
                while (true)
                {
                    Console.WriteLine($"Ingresa el numero #{numbers.Count + 1} (escribir 'calcular' para ver el resultado): ");
                    typedOption2 = Console.ReadLine();

                    if (typedOption2 == "calcular")
                    {
                        if (numbers.Count < 2)
                        {
                            Console.WriteLine("\nDebe ingresar al menos 2 numeros.");
                        }
                        else
                        {
                            break;   
                        }
                    }
                    else if (decimal.TryParse(typedOption2, out typedNumber))
                    {
                        numbers.Add(typedNumber);
                    }
                    else
                    {
                        Console.WriteLine("\nIngrese un numero valido.");
                    }
                }

                bool canCalculate = true;
                result = numbers[0];   


                switch (typedOperation)
                {
                    case 1:
                        symbol = "+";
                        for (int index = 1; index < numbers.Count; index++)
                        {
                            result = result + numbers[index];
                        }
                        break;

                    case 2:
                        symbol = "-";
                        for (int index = 1; index < numbers.Count; index++)
                        {
                            result = result - numbers[index];
                        }
                        break;

                    case 3:
                        symbol = "x";
                        for (int index = 1; index < numbers.Count; index++)
                        {
                            result = result * numbers[index];
                        }
                        break;

                    case 4:
                        symbol = "/";
                        for (int index = 1; index < numbers.Count; index++)
                        {
                            if (numbers[index] == 0)
                            {
                                Console.WriteLine("\nError: no se puede dividir entre cero.");
                                canCalculate = false;
                                break;  
                            }
                            result = result / numbers[index];
                        }
                        break;
                }

                if (canCalculate)
                {
                    Console.WriteLine($"\n{string.Join($" {symbol} ", numbers)} = {result}");
                }

                break;

            case 2:
                Console.WriteLine("\n-- Calculadora de promedio --");
                var i = 0;
                List<decimal> grades = new();


                while (true)
                {

                    Console.WriteLine($"Ingresa la calificación #{i + 1} (escribir 'calcular' para calcular resultado): ");
                    typedOption2 = Console.ReadLine();

                    if (typedOption2 == "calcular")
                    {
                        Console.WriteLine("\n\tCalculando...\n");
                        break;
                    }

                    else if (decimal.TryParse(typedOption2, out decimal grade))
                    {
                        grades.Add(Convert.ToDecimal(typedOption2));
                        i++;
                    }
                    else
                    {
                        Console.WriteLine("\nIngrese un número válido.");
                    }
                } 

                grade_accumulator = 0;

                foreach (decimal iterator in grades)
                {
                    grade_accumulator = grade_accumulator + iterator;
                }

                result = grade_accumulator / i;

                if (i == 0)
                {
                    Console.WriteLine("\nDebe ingresar al menos un valor a promediar\n");
                }
                else 
                {
                    Console.WriteLine($"\nPromedio Final: {result}");
                }
                break;

            case 3:
                Console.WriteLine("\n\tCerrando Programa...");
                running = false;
                break;

            default:
                Console.WriteLine("\nOpcion invalida");
                break;
        }
    }
    catch (FormatException)   
    {
        Console.WriteLine("\nError: debe escribir un numero valido.");
    }
    catch (Exception ex) 
    {
        Console.WriteLine($"\nError inesperado: {ex.Message}");
    }

    if (running)

    {
    while (true)
    {
        try
        {

        Console.WriteLine("\nDesea utilizar este programa otra vez (si o no)? \n");
        typedOption3 = Convert.ToString(Console.ReadLine());

        if (typedOption3 == "no")
            {
                running = false;
                break;
            }
        else if (typedOption3 == "si")
            {
                Console.WriteLine("\n\tCargando...");
                break;
            }

        else
            {
                Console.WriteLine("\n\tIngresa una opción valida!");
            }
        }

        catch (FormatException)
        {
            Console.WriteLine("Ingrese una opción valida!");
        }
    }
    }

}