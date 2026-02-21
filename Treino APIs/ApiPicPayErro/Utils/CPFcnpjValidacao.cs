namespace BackEndPicPay.Utils
{
    public class CPFcnpjValidacao 
    {

        // Método interno que realiza o cálculo de validação
        private static bool Valido(string opcao, int comprimentoEsperado, int[] primeirosMultiplicadores, int[] segundosMultiplicadores)
        {

            // Verifica se o tamanho está correto e se é numérico
            if (opcao.Length != comprimentoEsperado || !long.TryParse(opcao, out _))
            {
                return false;
            }
            
            int primeiraSoma = 0, segundaSoma = 0;


            // Loop que percorre todos os dígitos (exceto os 2 verificadores)
            for (int i = 0; i<comprimentoEsperado - 2; i++)
            {
                // Converte cada caractere para número
                var numero = int.Parse(opcao[i].ToString());

                // Soma ponderada para o primeiro dígito verificador
                primeiraSoma += numero * primeirosMultiplicadores[i];

                // Soma ponderada para o segundo dígito verificador
                segundaSoma += numero * segundosMultiplicadores[i];
            }

            var primeiraVerificador = GetVerificador(primeiraSoma);

            // Adiciona o primeiro verificador ao cálculo do segundo
            segundaSoma += primeiraVerificador * segundosMultiplicadores[comprimentoEsperado - 2];


            var segundoVerificador = GetVerificador(segundaSoma);

            // Compara com os dígitos finais do número original ||
            //Checa se a string original termina com "12"
            return opcao.EndsWith(primeiraVerificador.ToString() + segundoVerificador.ToString());
        }

        private static int GetVerificador(int soma)
        {
            var resto = soma % 11; //Obtém o resto da divisão
            return resto < 2 ? 0 : 11 - resto;
        }

        public static bool CPFValido(string cpf)
        {
            //[Valido] - Reúso por composição
            return Valido(
                cpf,
                11,
                new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 }, // Pesos para 1º dígito
                new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 } // Pesos para 2º dígito
            );
        }
        public static bool CNPJValido(string cnpj)
        {
            //[Valido] - Reúso por composição
            return Valido(
                cnpj,
                14,
                new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 },
                new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 }
            );
        }
        public static bool CPFcnpjValido(string cpfcnpj)
        {
            return cpfcnpj.Length == 11 ? CPFValido(cpfcnpj) : 
                (cpfcnpj.Length == 14 ? CNPJValido(cpfcnpj) : false);
        }
    }
}
