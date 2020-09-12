<img src="https://www.ead.senac.br/arquivo/api/download/publico/1134" alt="drawing" width="400"/><br>
Análise e Desenvolvimento de Sistemas - Senac 2020
# CSharp - Avaliação Blockbuster (Locadora de Filmes)

- Classes.
- Camadas (MVC).
- Consulta LinQ.
- Conexão com o banco de dados SQL.
- Forms.

## Instruções# 

No indicador 3. Descreve as estruturas de POO, que tem como critério a Análise, o objetivo é consolidar a prática em Programação Orientada a Objetos, permitindo ao estudante aplicar as relações da vida real em objetos estruturas em uma linguagem de desenvolvimento orientado a objetos.

Para analisar o aprendizado, desenvolva um mini sistema de locação de filmes, estilo Blockbuster, que possui como entidades:

* Cliente
    - Identificador Único (ID)
    - Nome
    - Data de Nascimento
    - C.P.F.
    - Dias para Devolução
    
* Filme
    - Identificador Único (ID)
    - Nome
    - Data de Lançamento
    - Sinópse
    - Valor para Locação
    - Estoque
    
* Locação
    - Identificador Único (ID)
    - I.D. do Cliente
    - Data de Locação
    - Data de Devolução
    
* Filmes Locados
    - I.D. da Locação
    - I.D. do Filme

Cada arquivo fonte de objeto deverá conter as suas propriedades e deverá respeitar os relacionamentos existentes entre si:
* Cliente possui relacionamento 1-N com Locação
* Locação possui relacionamento 1-N com Filmes Locados
* Filmes possui relacionamento 1-N com Filmes Locados

Cada arquivo fonte de objeto deverá conter, minimamente:
* Cliente
    - Método com a Quantidade de Filmes locados
* Filme
    - Método com a Quantidade de locações realizadas
* Locação
    - Método com o Valor total da Locação
    - Método com a quantidade de filmes locados
    - A data de devolução deverá ser calculada com base na Data de Locação e a quantidade de dias para Devolução que o cliente tem disponível na locadora.

Deverá ser criado um arquivo principal para gerenciamento das informações dos objetos, onde deverão ser criados 10 filmes (a sua escolha) e 5 clientes. Cada cliente deverá fazer algumas locações de filmes e ao final deverá ser exibida a Quantidade de Filmes locados por cada cliente, a quantidade de Locações dos Filmes e o valor total de locação e a quantidade de filmes por Locação.

**O código fonte deverá ser trabalhando dentro do GitHub, sendo sincronizado e aberto PR ao final do desenvolvimento.**

# Interfaces
<img src="/img/produtos.jpg"/>
