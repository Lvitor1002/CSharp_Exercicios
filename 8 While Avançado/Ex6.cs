

/*
Projeto de código 3 - Escrever código que processa o conteúdo de uma matriz de cadeia de caracteres

Sua solução deve usar a seguinte matriz de cadeia de caracteres para representar a entrada para sua lógica de codificação:
string[] myStrings = new string[2] { "I like pizza. I like roast chicken. I like salad", "I like all three of the menu choices" };

Sua solução deve declarar uma variável inteira chamada indexPonto que pode ser usada para manter o local 
do caractere de indexPonto dentro de uma cadeia de caracteres.

Sua solução deve incluir um externo foreach ou for loop que possa ser usado para processar cada elemento de cadeia 
de caracteres na matriz. A variável string que você processará dentro dos loops deve ser nomeada palavra.

No loop externo, sua solução deve usar o IndexOf() String método da classe para obter a localização do 
caractere do primeiro período na palavra variável. 

A chamada de método deve ser semelhante a: palavra.IndexOf("."). 
Se não houver nenhum caractere de indexPonto na cadeia de caracteres, um valor de -1 será retornado.

Sua solução deve incluir um loop interno do-while que while possa ser usado para processar a palavra variável.

No loop interno, sua solução deve extrair e exibir (gravar no console) cada frase contida em cada uma das cadeias de 
caracteres processadas.

No loop interno, sua solução não deve exibir o caractere de período.

No loop interno, sua solução deve usar os Remove()métodos, 
Substring() e para TrimStart() processar as informações da cadeia de caracteres.

Se a lógica de código funcionar corretamente, a saída deverá ser semelhante à seguinte:
I like pizza
I like roast chicken
I like salad
I like all three of the menu choices
 
 */
using System;

namespace Fundamentos
{
    internal class Program
    {

        static void Main(string[] args)
            => ManipularCadeiaChar();

        private static void ManipularCadeiaChar()
        {
            string[] myStrings = new string[2] {"I like pizza. I like roast chicken. I like salad", "I like all three of the menu choices"};

            for (int i = 0; i < myStrings.Length; i++)
            {
                string fraseCompleta = myStrings[i];
                int posicaoPonto = fraseCompleta.IndexOf('.');

                while (posicaoPonto != -1)
                {
                    string parte = fraseCompleta.Substring(0, posicaoPonto).Trim();
                    Console.WriteLine(parte);

                    // Remove a parte já extraída (incluindo o ponto) e prepara o restante
                    fraseCompleta = fraseCompleta.Substring(posicaoPonto + 1).TrimStart();

                    posicaoPonto = fraseCompleta.IndexOf('.');
                }

                if (!string.IsNullOrWhiteSpace(fraseCompleta))
                    Console.WriteLine(fraseCompleta.Trim());
            }
        }
    }
}
