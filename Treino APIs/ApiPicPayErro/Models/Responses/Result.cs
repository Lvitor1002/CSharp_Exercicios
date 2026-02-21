using System;

namespace BackEndPicPay.Models.Responses
{

    //Resposta que o servidor envia de volta para o cliente após processar a requisição.


    public class Result<T> //[T] -> Tipo genérico
    {
        public bool Sucesso{ get; private set; } //Só podem ser modificadas dentro desta classe
        public string ErroMensagem{ get; private set; }
        public T Valor { get; private set; }


        //Construtor[private] - não pode criar Result<T> diretamente com [new] fora desta classe
        private Result(bool sucesso, string erroMensagem, T valor)
        {
            Sucesso = sucesso;
            ErroMensagem = erroMensagem;
            Valor = valor;
        }

        private Result(bool sucesso)
        {
            Sucesso = sucesso;
        }

        public static Result<T> SucessoResult(T valor) => new Result<T>(sucesso:true, erroMensagem:null, valor);
        public static Result<T> FalhaResult(string erroMensagem) => new Result<T>(sucesso: false, erroMensagem, default);

    }
}
