using System;
using System.ComponentModel;
using System.Text;

namespace ConsoleAppEjercicio75
{
    class Program
    {
        static void Main(string[] args)
        {
            int extInferior, extSuperior;
            int escalaConversion = 0;
            bool seguir = true;
            do
            {
                extInferior = PedirInt("Ingrese el extremo inferior del intervalo:");
                extSuperior = PedirInt("Ingrese el extremo superior del intervalo:");
                if (extInferior>=extSuperior)
                {
                    Console.WriteLine("ERROR: extremos mal ingresados");
                    seguir = true;
                }
                else
                {
                    seguir = false;
                }

            } while (seguir);

            
            escalaConversion = SeleccionarEscala();
            MostrarTablaDeConversion(extInferior, extSuperior, escalaConversion);
        }

        private static void MostrarTablaDeConversion(int menor, int mayor, int escala)
        {
            double tempConvertida = 0;
            string tempMostrada = ObtenerTemperaturaMostrada(escala);
            for (int temperatura = menor; temperatura <= mayor; temperatura++)
            {
                switch (escala)
                {
                    case 1:
                        tempConvertida = ConvertirCelsiusFahrenheit(temperatura);
                        break;
                    case 2:
                        tempConvertida = ConvertirCelsiusReaumur(temperatura);
                        break;
                    case 3:
                        tempConvertida = ConvertirCelsiusKelvin(temperatura);
                        break;
                    default:
                        tempConvertida = ConvertirCelsiusRankine(temperatura);
                        break;
                }
                Console.WriteLine($"{temperatura} equivale a {tempConvertida} grados {tempMostrada}");
            }

            Console.ReadLine();
        }

        private static string ObtenerTemperaturaMostrada(int escala)
        {
            string escalaMostrada = "";
            switch (escala)
            {
                case 1:
                    escalaMostrada = "Fahrenheit";
                    break;
                case 2:
                    escalaMostrada = "Reaumur";
                    break;
                case 3:
                    escalaMostrada = "Kelvin";
                    break;
                default:
                    escalaMostrada = "Rankine";
                    break;
            }

            return escalaMostrada;
        }

        private static double ConvertirCelsiusRankine(double celsius) =>
            ConvertirCelsiusKelvin(celsius) * 9 / 5;

        private static double ConvertirCelsiusKelvin(double celsius) => 273.15 + celsius;
        private static double ConvertirCelsiusReaumur(double celsius) => 0.8 * celsius;

        private static double ConvertirCelsiusFahrenheit(double celsius)
        {
            return 1.8 * celsius + 32;
        }

        private static int SeleccionarEscala()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("1-Fahrenheit");
            sb.AppendLine("2-Reaumur");
            sb.AppendLine("3-Kelvin");
            sb.AppendLine("4-Rankine");
            sb.Append("Seleccione una escala:");
            
            var seleccion = PedirInt(sb.ToString(), 1, 4);
            return seleccion;
        }
        /// <summary>
        /// Metodo para pedir un entero entre 2 valores
        /// </summary>
        /// <param name="mensaje">Mensaje que se mostrará en la consola</param>
        /// <param name="valorMenor">Valor menor del rango</param>
        /// <param name="valorMayor">Valor mayor del rango</param>
        /// <returns></returns>
        private static int PedirInt(string mensaje, int valorMenor, int valorMayor)
        {
            
            bool seguir = true;
            int valorInt;
            do
            {
                Console.Write($"{mensaje}");
                if (!int.TryParse(Console.ReadLine(), out valorInt))
                {
                    Console.WriteLine("ERROR: Nro. mal ingresado");
                    seguir = true;
                }
                else if (valorInt<valorMenor || valorInt>valorMayor)
                {
                    Console.WriteLine($"ERROR: el nro. debe estar entre {valorMenor} y {valorMayor}");
                }else
                {
                    seguir = false;
                }
            } while (seguir);

            return valorInt;
        }

        private static int PedirInt(string mensaje)
        {
            bool seguir = true;
            int valorInt;
            do
            {
                Console.Write($"{mensaje}");
                if (!int.TryParse(Console.ReadLine(),out valorInt))
                {
                    Console.WriteLine("ERROR: Nro. mal ingresado");
                    seguir = true;
                }
                else
                {
                    seguir = false;
                }
            } while (seguir);

            return valorInt;
        }
    }
}
