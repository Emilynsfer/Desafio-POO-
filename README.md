# Sistema de Corretora Imobiliária

## 📋 Descrição

Sistema de gerenciamento para corretora imobiliária desenvolvido em C# que permite o controle completo de imóveis (casas e apartamentos), incluindo cadastro, aluguel e gestão de proprietários. O projeto implementa conceitos fundamentais de Programação Orientada a Objetos (POO) como herança, polimorfismo e encapsulamento.

## 🎯 Funcionalidades

- **Cadastro de Imóveis**: Registro de casas e apartamentos com informações completas
- **Gestão de Proprietários**: Cadastro com nome, telefone e CPF
- **Sistema de Aluguel**: Controle de status (alugado/disponível) dos imóveis
- **Cálculo de Valores**: Calculadora automática de valores de aluguel por período
- **Relatórios**: Listagem geral e específica de imóveis alugados
- **Interface Interativa**: Menu console intuitivo e fácil de usar

## 🏗️ Arquitetura do Sistema

### Classes Principais

#### `Imovel` (Classe Abstrata)
- **Propriedades**: Endereço, Número, Status de Aluguel, Proprietário
- **Métodos**: Getters/Setters, verificação de status, contato do proprietário
- **Método Abstrato**: `calcularAluguel(int dias)`

#### `Casa` (Herda de Imovel)
- **Diária**: R$ 200,00
- **Especialização**: Implementa cálculo específico para casas

#### `Apartamento` (Herda de Imovel)
- **Diária**: R$ 150,00
- **Especialização**: Implementa cálculo específico para apartamentos

#### `Proprietario`
- **Dados**: Nome, Telefone, CPF
- **Função**: Armazenar informações de contato

## 🚀 Como Executar

### Pré-requisitos
- .NET Framework ou .NET Core
- Visual Studio, VS Code ou qualquer IDE C#

### Execução
```bash
# Compilar o arquivo
csc desafio.cs

# Executar o programa
./desafio.exe
```

## 💻 Menu do Sistema

```
--- Corretora Imobiliária ---
1) Cadastrar imóvel (Casa / Apartamento)
2) Deletar imóvel
3) Listar imóveis
4) Alugar / Disponibilizar imóvel
5) Calcular valor total de aluguel (período)
6) Listar imóveis alugados
0) Sair
```

## 🎮 Como Usar

### 1. Cadastrar Imóvel
- Escolha o tipo (Casa ou Apartamento)
- Informe endereço e número
- Cadastre os dados do proprietário

### 2. Gerenciar Aluguéis
- Liste os imóveis disponíveis
- Altere o status de aluguel
- Calcule valores por período específico

### 3. Relatórios
- Visualize todos os imóveis cadastrados
- Consulte apenas imóveis alugados
- Veja informações de contato dos proprietários

## 📊 Exemplo de Uso

```csharp
// Exemplo de cadastro automático
var proprietario = new Proprietario 
{ 
    Nome = "João Silva", 
    Telefone = "(11) 99999-9999", 
    CPF = "123.456.789-00" 
};

var casa = new Casa();
casa.SetEndereco("Rua das Flores, 123");
casa.SetNumero(123);
casa.SetProprietario(proprietario);

// Cálculo de aluguel para 30 dias
int valor = casa.calcularAluguel(30); // R$ 6.000,00
```

## 🔧 Conceitos de POO Implementados

- **Herança**: Classes Casa e Apartamento herdam de Imovel
- **Polimorfismo**: Métodos `estaAlugado()` e `calcularAluguel()` com comportamentos específicos
- **Encapsulamento**: Propriedades protegidas com métodos de acesso
- **Abstração**: Classe Imovel define contrato para subclasses

## 📁 Estrutura do Projeto

```
desafio.cs
├── Classe Abstrata: Imovel
├── Classe Filha: Casa
├── Classe Filha: Apartamento
├── Classe: Proprietario
└── Classe Principal: Program
```

## ⚡ Características Técnicas

- **Linguagem**: C#
- **Paradigma**: Orientação a Objetos
- **Interface**: Console Application
- **Persistência**: Em memória (Lista)
- **Validações**: Entrada de dados e índices

## 🎯 Objetivos de Aprendizado

Este projeto demonstra:
- Implementação de herança e polimorfismo
- Uso de classes abstratas
- Encapsulamento de dados
- Interface de usuário em console
- Manipulação de coleções (List)
- Tratamento de exceções básico

## 📝 Melhorias Futuras

- [ ] Persistência em banco de dados
- [ ] Interface gráfica (WPF/WinForms)
- [ ] API REST
- [ ] Relatórios em PDF
- [ ] Sistema de autenticação
- [ ] Histórico de aluguéis

## 👨‍💻 Autor

Desenvolvido como projeto educacional para demonstração de conceitos de POO em C#.

---

**Nota**: Este é um projeto de estudo focado em conceitos fundamentais de Programação Orientada a Objetos.
