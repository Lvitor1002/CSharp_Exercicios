

/*
Você está desenvolvendo um aplicativo de Avaliação de Alunos que automatiza o cálculo das notas 
atuais de cada aluno de uma turma. 

Os parâmetros para a sua aplicação são:
                Você recebe uma pequena lista de quatro alunos e suas cinco notas de trabalho.

                Cada nota de atribuição é expressa como um valor inteiro, 0-100, 
                onde 100 representa 100% correto.

                As pontuações finais são calculadas como uma média das cinco pontuações 
                dos trabalhos.

                Seu aplicativo precisa executar operações matemáticas básicas para 
                calcular as notas finais de cada aluno.

                A sua aplicação tem de mostrar o nome e a pontuação final de cada aluno.

Atualmente, o livro de notas dos professores mostra as tarefas graduadas para cada aluno 
da seguinte forma:
                Sophia: 93, 87, 98, 95, 100
                Nicolas: 80, 83, 82, 88, 85
                Zahirah:   84, 96, 73, 85, 79
                Jeong:  90, 92, 98, 100, 97

O professor exige que as notas calculadas para cada aluno sejam exibidas da seguinte forma:
                                                                        Student     Grade
                                                                        Sophia      94.6  A
                                                                        Nicolas     83.6  B
                                                                        Zahirah     83.4  B
                                                                        Jeong       95.4  A
*/

using System;
using System.Linq;

namespace Fundamentos
{
    public class Program
    {
        private static void Main(string[] args)
            => Exbir();


        private static (decimal, decimal, decimal, decimal) RetornarDadosAlunos()
        {
            var notasSopia = new int[5] { 93, 87, 98, 95, 100 };
            // Utilizando esse tipo de conversão explícita, pois não estamos trabalhando com divisão de números fracionários, se não, seria necessário usar Convet para não trucar dados
            decimal mediaSopia = (decimal)notasSopia.Average();
            
            var notasNicolas = new int[5] { 80, 83, 82, 88, 85 };
            decimal mediaNicolas = (decimal)notasNicolas.Average();
            
            var notasZahirah = new int[5] { 84, 96, 73, 85, 79 };
            decimal mediaZahirah = (decimal)notasZahirah.Average();
            
            var notasJeong = new int[5] { 90, 92, 98, 100, 97 };
            decimal mediaJeong = (decimal)notasJeong.Average();
            
            return (mediaSopia, mediaNicolas, mediaZahirah, mediaJeong);
        }

        private static void Exbir()
        {

            var (mediaSopia, mediaNicolas, mediaZahirah, mediaJeong) = RetornarDadosAlunos();

            Console.Clear();

            Console.WriteLine("Student\t\tGrade\n");
            Console.WriteLine($"Sophia\t\t{mediaSopia.ToString().Replace(',','.'):F2}\tA");
            Console.WriteLine($"Nicolas\t\t{mediaNicolas.ToString().Replace(',', '.'):F2}\tB");
            Console.WriteLine($"Zahirah\t\t{mediaZahirah.ToString().Replace(',','.'):F2}\tB");
            Console.WriteLine($"Jeong\t\t{mediaJeong.ToString().Replace(',','.'):F2}\tA");

        }
    }
}
