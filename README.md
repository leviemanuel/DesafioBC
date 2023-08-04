<h1 align="center">:file_cabinet: Desafio BC</h1>

## :memo: Descrição
Solução desenvolvida para registro de lançamentos e de entidades (fornecedores e clientes) de um comércio.

## :books: Funcionalidades
* <b>Entidade</b>: Cadastro e manutenção de entidades (Fornecedores e clientes).
* <b>Lançamento</b>: Cadastro e manutenção dos lançamentos diários do comércio.
* <b>Report</b>: Exibição de lançamentos por data selecionada (data de pagamento).

## :wrench: Tecnologias utilizadas
* .Net Core 6
*  MySQL
*  Docker
*  ASP Net
*  Arquitetura DDD (Domain Driven Design)

## :rocket: Rodando o projeto
Para que possa rodar o projeto, é necessário preencher os seguintes pré-requisitos
- MySQL
- .Net Core 6 SDK

(Caso queira, pode usar também o Docker)

No arquivo appsettings.json, ajuste a connection string para seu servidor de banco de dados.

Abra o prompt de comando e, após navegar até a pasta do projeto de infraestrutura, digite:
```
dotnet ef migrations add InitialStructure --project TesteBC.Infrastructure
```

Agora navegue até a pasta do projeto API e rode-o com o seguinte comando:
```
dotnet run
```
A API pode ser acessada pelo endereço: <b>https://localhost:7092/swagger/index.html</b>

Após isso, navegue até a pasta do projeto Web e rode-o com o seguinte comando:
```
dotnet run
```
Você pode acessá-lo pelo caminho: <b>https://localhost:7092/swagger/index.html</b>


Mas se quiser testar pelo projeto de testes, navegue até a pasta dele e execute o seguinte comando:
```
dotnet test
```


## :soon: Implementação futura
* Aguardo novas instruções!

## :handshake: Colaboradores
<table>
  <tr>
    <td align="center">
      <a href="http://github.com/leviemanuel">
        <img src="https://avatars.githubusercontent.com/u/72361692?v=4" width="77px;" alt="levi.emanuel@outlook.com"/><br>
        <sub>
          <b>levi.emanuel</b>
        </sub>
      </a>
    </td>
  </tr>
</table>

## :dart: Status do projeto
Aguardando aprovação...
