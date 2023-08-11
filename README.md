<h1 align="center">:file_cabinet: Desafio BC</h1>

## :memo: Descrição
Solução desenvolvida para registro de lançamentos e de entidades (fornecedores e clientes) de um comércio.

## :books: Funcionalidades
* <b>Entidade</b>: Cadastro e manutenção de entidades (Fornecedores e clientes).
* <b>Lançamento</b>: Cadastro e manutenção dos lançamentos diários do comércio.
* <b>Report</b>: Exibição de lançamentos por data selecionada (data de pagamento).

## :bricks: Estrutura do projeto
Desenvolvido em arquitetura DDD e com injeção de dependência, o projeto tem suas camadas e classes da seguinte forma:
* <b>TesteBC.Domain</b>: Define os modelos dos objetos, usando dataannotations para validações e definições de tamanhos de colunas.
* <b>TesteBC.Infrastructure</b>: Contém o contexto de BD do projeto, os arquivos de migração e repositórios.
* <b>TesteBC.Service</b>: Contém os serviços que serão utilizados na API.
* <b>TesteBC.Api</b>: Enfim o projeto da API, que é a interface do aplicativo. Contendo os Controllers, modelos baseados nos objetos de banco de dados (e seus respectivos DTOs, um para cada operação de cada objeto - deixando configurável o que será exibido e necessário para cada operação) e modelos baseados nos reports e response padrão da API. Esse projeto também contém os profiles de transformação do AutoMapper.
* <b>TesteBC.Tests</b>: Projeto de testes.

![image](https://github.com/leviemanuel/DesafioBC/assets/72361692/7306755f-1b77-46d3-8910-90bc9ee4269e)


Já o projeto Web foi desenvolvido usando MVC.


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

Iniciando o processo para rodar o projeto, vá até a pasta da API (TesteBC.Api)
No arquivo appsettings.Development.json, ajuste a connection string para seu servidor de banco de dados.
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "defaultCon": "server=localhost;database=novoTesteBC;user=COLOQUEOUSUARIOAQUI;password=COLOQUEASENHAAQUI"
  }
}
```

Após salvar o arquivo, abra o prompt de comando e, após navegar até a pasta do projeto de infraestrutura (TesteBC.Infrastructure), digite:
```
dotnet ef --startup-project ../TesteBC.Api migrations add InfraInicial -c TesteBCDBContext
```
Aparecendo a mensagem de sucesso, navegue até a pasta do projeto de API com:
```
cd ..\TesteBC.Api
```
Após isso, execute a criação com:
```
dotnet ef database update
```
Agora navegue até a pasta do projeto API e rode-o com o seguinte comando:
```
dotnet run
```
A API pode ser acessada pelo endereço: <b>https://localhost:7092/swagger/index.html</b>

Após isso, navegue até a pasta do projeto Web e, abrindo um powershell na pasta, execute o seguinte comando:
```
dotnet run
```
Você pode acessá-lo pelo caminho: <b>https://localhost:7034/Lancamento/LancamentoLista</b>


Mas se quiser testar pelo projeto de testes, navegue até a pasta dele e execute o seguinte comando:
```
dotnet test
```
As seguintes mensagens devem ser apresentadas:
```
Iniciando execução de teste, espere...
1 arquivos de teste no total corresponderam ao padrão especificado.

Aprovado!  - Com falha:     0, Aprovado:    10, Ignorado:     0, Total:    10, Duração: 68 ms - TesteBC.Tests.dll (net6.0)
```

Lembrando que, para o teste da API + Projeto Web funcionar corretamente, ambos precisam ser iniciados. :)

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
