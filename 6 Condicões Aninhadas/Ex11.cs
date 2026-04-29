

/*
Foi solicitado que você adicionasse um recurso ao software de sua empresa. 
O recurso destina-se a melhorar a taxa de renovação das assinaturas do software. 

Sua tarefa é exibir uma mensagem de renovação quando um usuário fizer logon no sistema de software 
e receber a notificação de que a assinatura está prestes a ser encerrada. 

Você precisará adicionar um par de instruções de decisão para adicionar corretamente a lógica de ramificação ao
aplicativo para atender aos requisitos. 

Regra 1: seu código deve exibir apenas uma mensagem.
        A mensagem exibida pelo código dependerá das outras cinco regras. 
        Para as regras de 2 à 6, considere que as numerações mais altas têm precedência sobre as regras numeradas mais baixas.

Regra 2: se a assinatura do usuário expirar em dez dias ou menos, será exibida a mensagem:
        Your subscription will expire soon. Renew now!

Regra 3: se a assinatura do usuário expirar em cinco dias ou menos, será exibida a mensagem:
        Your subscription expires in _ days.
        Renew now and save 10%!
Observação:
            Substitua o caractere _ exibido na mensagem acima pelo valor armazenado na variável daysUntilExpiration ao criar a saída da mensagem.

Regra 4: se a assinatura do usuário expirar em um dia, serão exibidas as mensagens:
        Your subscription expires within a day!
        Renew now and save 20%!

Regra 5: se a assinatura do usuário tiver expirado, será exibida a mensagem:
        Your subscription has expired.

Regra 6: se a assinatura do usuário não expirar em dez dias ou menos, não será exibida nenhuma mensagem.

Bonus:
    Gere um número aleatório de 0 a 11. 
    O número aleatório é atribuído a uma variável de inteiro chamada: 'diasAteVencimento'. 
    Você tem outra variável de inteiro chamada '_porcentagemDesconto' que é inicializada para 0.
    Uma variável: valorAssinatura = 100;
*/

using System;

namespace Fundamentos
{
    public class Program
    {
        private static Random _sorteioNumero = new Random();
        private static double _porcentagemDesconto = 0;

        private static void Main(string[] args)
            => ExibirDados();
                
            
        private static int RetornarDiasAteVencimento()
            =>_sorteioNumero.Next(0,12);


        private static string RetornarMensagemRenovacao(int diasAteVencimento)
            => diasAteVencimento > 10 ? string.Empty :
                diasAteVencimento == 0 ? "Your subscription has expired." :
                diasAteVencimento == 1 ? $"Your subscription expires within a day!\nRenew now and save {_porcentagemDesconto += 20}%!" :
                diasAteVencimento <= 5 ? $"Your subscription expires in {diasAteVencimento} days.\nRenew now and save {_porcentagemDesconto += 10}%!" :
                "Your subscription will expire soon. Renew now!";


        private static void ExibirDados()
        {
            string mensagemRenovacao = RetornarMensagemRenovacao(RetornarDiasAteVencimento());

            double valorAssinatura = 100;

            double valorAssinaturaComDesconto = _porcentagemDesconto == 10 ? valorAssinatura * 0.90 :
                                                _porcentagemDesconto == 20 ? valorAssinatura * 0.80 :
                                                valorAssinatura;

            Console.WriteLine(_porcentagemDesconto != 0 
                ? $"{mensagemRenovacao} Congratulations on your {_porcentagemDesconto}% discount!\nOld price {valorAssinatura:C2}\nNew price {valorAssinaturaComDesconto:C2}" 
                : mensagemRenovacao);
        }
    }
}
