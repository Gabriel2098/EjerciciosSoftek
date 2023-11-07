using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_3_Gabriel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> itemsCorrectos = new List<string>();
            string[] combo = { "CPO-MEX", "CIS-XEQ-*", "BI_PYB", "Q-AC_RPA", "VAL-PRE1", "VALPRE_2", "GB-M-DIF*", "GBM1-DAF", "A-CC1-AH", "CIS-DIF*" };
            string[] lista = { "ACC1AH", "ACC2AH", "AC-RPA", "ACRPE", "BIPYA", "BIPYB", "CISDIF0", "CISDIF1", "CISDIF3", "CISDIF*", "CPOMEX1", "CPOMEX2", "CPOMEX", "GBMDAF", "GBM1DAF", "GBMDIF0", "QACRPA", "VALPRE1", "VALPRE*" };
            string cadena, sobrante;
            int itemsQuitados = 0, itemLista = 0;
            bool coincide;
            for (int i = 0; i < combo.Length; i++)
            {
                coincide = false;
                char[] item = combo[i].ToCharArray();
                for (int j = 0; j < lista.Length; j++)
                {
                    cadena = "";
                    sobrante = "";
                    int l = 0;
                    for (int k = 0; k < item.Length; k++)
                    {
                        if (item[k].ToString() == lista[j].ToString().Substring(l, 1))
                        {
                            cadena += item[k];
                            l++;
                        }
                        else
                        {
                            sobrante += $"\n    {item[k]} -> Posicion {k+1}";
                        }
                    }
                    if (cadena == lista[j].ToString())
                    {
                        coincide = true;
                        itemLista = j;
                        Console.WriteLine($"El item {combo[i].ToString()} matchea con {cadena}, estos caracteres sobran: {sobrante}");
                    }
                }
                if (!coincide) itemsQuitados++;
                else itemsCorrectos.Add(lista[itemLista]);
            }
            Console.WriteLine("\nPresiona cualquier tecla para imprimir la lista con los items correctos...");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("========= Lista Correcta =========");
            foreach(var item in itemsCorrectos)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
