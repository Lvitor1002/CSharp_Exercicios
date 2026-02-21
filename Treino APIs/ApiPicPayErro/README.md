<img src="./img/picpay.png" alt="Logo">

<h1>Desafio Back-End PicPay</h1>
<br/>
<br/>

<h3>Objetivos do PicPay simplificado</h3>

<p>O PicPay é uma plataforma de pagamentos, porém, neste caso, será simplificado. É possível, portanto, depositar e realizar transferências de dinheiro entre usuários. <br/>
Temos 2 tipos de usuários: os comuns e os lojistas. Ambos têm carteira com dinheiro e realizam transferências entre si.</p>

<br/>
<br/>
<h3>Requisitos</h3>
<p><strong>Regra de negócio para o bom funcionamento do PicPay simplificado:</strong></p>
<p>> Para ambos os tipos de usuários precisamos de: nome completo, CPF, e-mail e senha. <br/>
CPF/CNPJ e e-mails devem ser únicos no sistema. Sendo assim, seu sistema deve permitir apenas um cadastro com o mesmo CPF ou endereço de e-mail.</p>
<br/>
<p>> Usuários podem enviar dinheiro (efetuar transferências) para lojistas e entre usuários.</p>
<br/>
<p>> Lojistas só recebem transferências, não enviam dinheiro para ninguém.</p>
<br/>
<p>> Validar se o usuário tem saldo antes da transferência.</p>
<br/>
<p>> Antes de finalizar a transferência, deve-se consultar um serviço autorizador externo. Use este mock: <a href="https://util.devi.tools/api/v2/authorize" target="_blank">https://util.devi.tools/api/v2/authorize</a> para simular o serviço utilizando o verbo GET.</p>
<br/>
<p>> A operação de transferência deve ser uma transação (ou seja, revertida em qualquer caso de inconsistência) e o dinheiro deve voltar para a carteira do usuário que o enviou.</p>
<br/>
<p>> No recebimento de pagamento, o usuário ou lojista precisa receber notificações (envio de email, sms) enviadas por um serviço de terceiro, que eventualmente pode estar indisponível/instável. Use este mock: <a href="https://util.devi.tools/api/v1/notify" target="_blank">https://util.devi.tools/api/v1/notify</a> para simular o envio da notificação utilizando o verbo POST.</p>
<br/>
<p>> Este serviço deve ser RESTful.</p>
<br/>
<br/>
<h3>Endpoint de transferência</h3>
<p>Você pode implementar o que achar conveniente, porém vamos nos atentar somente ao fluxo de transferência entre dois usuários. A implementação deve seguir o contrato abaixo:</p>
<br/>
<pre>
POST /transfer
Content-Type: application/json

{
    "value": 100.0,
    "payer": 4,
    "payee": 15
}
`</pre>`
