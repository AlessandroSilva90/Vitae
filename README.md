# PROVIDENTIA VITAE
### 📋 Sobre o Projeto

O PROVIDENTIA VITAE é um sistema modular desenvolvido para atender as necessidades do Hospital Santa Casa de Misericórdia de Sobral, substituindo o sistema legado atual.
🎯 Objetivos

    Modernização: Substituir sistema legado por tecnologia atual

    Performance: Oferecer maior fluidez e eficiência

    Usabilidade: Interface intuitiva e amigável ao usuário

    Modularidade: Arquitetura flexível para expansão futura

### 🏗️ Arquitetura e Tecnologias
🔧 Stacks

    Backend: C# com .NET Core

    ORM: Entity Framework

    Arquitetura: Híbrida (Camadas + API)

    Frontend: Sistema Web

    Banco de Dados: MySQL

### 📁 Estrutura do Projeto
    Core_Providentia_vitae/
├── Controllers/          # Camada de Apresentação (API)
├── Services/             # Camada de Serviços (Lógica de Negócio)
├── Models/               # Entidades de Domínio
├── Data/                 # Contexto e Configuração do Banco
├── DTOs/                 # Objetos de Transferência de Dados
└── Program.cs           # Configuração da Aplicação

### 🎪 Módulos do Sistema

O sistema opera em módulos independentes:

    🏥 Módulo RH - Gestão de funcionários e departamentos

    📦 Módulo Almoxarifado - Controle de estoque e insumos

    👨‍⚕️ Módulo Enfermagem - Controle de pacientes e procedimentos

    ...e mais módulos em desenvolvimento

### 🚀 Características Técnicas
✅ Arquitetura Híbrida

Combinação dos benefícios da Arquitetura em Camadas com API RESTful, proporcionando:

    Separação clara de responsabilidades

    Manutenibilidade do código

    Escalabilidade para novos módulos

    Testabilidade das funcionalidades

🔄 Padrões Implementados

    DTO Pattern - Segurança e otimização de dados

    Dependency Injection - Acoplamento reduzido

    Repository Pattern - Abstração do acesso a dados

    Service Layer - Centralização da lógica de negócio

### 📦 Estrutura de Desenvolvimento
Modelo por Módulos

Cada módulo segue a estrutura:
text

Modulo/
├── Controllers/
├── Services/
├── Models/
├── DTOs/
└── Repositories/

Convenções Adotadas

    Clean Code - Código limpo e legível

    SOLID Principles - Boas práticas de orientação a objetos

    RESTful APIs - Padrão para comunicação web

    Async/Await - Operações assíncronas para melhor performance
