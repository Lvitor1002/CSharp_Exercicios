
/*
Foi solicitado que você adicionasse um recurso ao software de sua empresa. 
O recurso destina-se a melhorar a taxa de renovação das assinaturas do software. 

Sua tarefa é exibir uma mensagem de renovação quando um usuário fizer logon no sistema de software 
e receber a notificação de que a assinatura está prestes a ser encerrada. 

Você precisará adicionar um par de instruções de decisão para adicionar corretamente a lógica de ramificação ao
aplicativo para atender aos requisitos. 

Regra 1: seu código deve exibir apenas uma mensagem.
        A mensagem exibida pelo código dependerá das outras cinco regras. 
        Para as regras de 2 a 6, as regras numeradas mais altas têm precedência sobre as regras numeradas mais baixas.

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
    Você tem outra variável de inteiro chamada 'porcentagemDesconto' que é inicializada para 0.
*/
using System;


namespace Etapa1
{
    public class Program
    {
        public static void Main(string[] args)
            => ExibirMensagem();

        private static int RetornarDiasVencimentoAleatorio()
            => new Random().Next(12);

        private static void ExibirMensagem()
        {
            var diasAteVencimento = RetornarDiasVencimentoAleatorio();
            double porcentagemDesconto = 0;
            double valorAssinatura = 100;

            string mensagem = "";

            if(diasAteVencimento <= 0)
                mensagem += "Sua assinatura expirou. ";

            if(diasAteVencimento == 1)
            {
                mensagem += "Sua assinatura expira em um dia! Renove agora e economize 20%! ";
                porcentagemDesconto += 20.0/100.0;
            }

            if(diasAteVencimento <= 5)
            {
                mensagem += $"Sua assinatura expira em {diasAteVencimento} dias. Renove agora e economize 10%! ";
                porcentagemDesconto += 10.0/100.0;
            }

            if(diasAteVencimento <= 10)
                mensagem += "Sua assinatura expirará em breve. Renove agora! ";
            
            if(diasAteVencimento > 10)
                mensagem += "";

            var valorDesconto = porcentagemDesconto * 100;

            string economia = porcentagemDesconto > 0 ? $"Parabéns você economizou {valorDesconto}.\nNovo valor de assinatura: R${valorAssinatura - valorDesconto:F2}" : ""; 
            Console.WriteLine($"{mensagem}.\n{economia}");

        }
    }
}
