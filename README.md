# Design Patterns
Console project with design patterns samples

All content is fictitious for study purposes only

# Startup Project
- DesignPatternSamples.ConsoleAPP
- Patterns index is there
- Samples client is here

# Creational Patterns
 Ways create objects with flexibly and reuse incremented

## Factory Method
- Sample Name: RunFactoryMethodSample
- Lazy create by subclasses
- Sample
    - Factory Method: CreateSytemOperation();
      - Abstract
        -  PersonalComputerBase.CreateSytemOperation()
      - Concrete
        -  ApplePC.CreateSytemOperation()
        -  OfficePC.CreateSytemOperation()
        -  RedHatPC.CreateSytemOperation()

## Abstract Factory
- Sample Name: RunAbstractFactorySample
- Lazy create by subclasses
- To objects families
- Sample
  -  Object Families: (Police, Sport)
  - Abstract Factory
     - VehicleFactory
   - Concrete Factories
     - PoliceVehicleFactory
     - SportVehicleFactory

## Builder
- Sample Name: RunBuilderSample
- Way to assemble complex objects "products" by parts
- Can get different kind of "products" using the same Builder Interface, but in this case, Build() method need in concrete builders. With products have a common interface or abstract class Build() should be in builders interface.
- Sample    
  - Builders: DragonBuilder, WingBuilder, HeadBuild
    - Build Method: *Builder.Build()
  - Products: Dragon, Head, Wing
  - Director (Optional): DragonTrainer

## Prototype
- Sample Name: RunPrototypeSample
- Way to create copy of exists object, even without knowing concrete class or your private properties
- Can exists a prototype register to control all prototype objects when required
- Sample
  - Prototype Object:
    - prototype
  - Clones
    - deepClone: Made with DeepCopy
    - shallowClone: Made with ShallowCopy
  - Concrete
    - TrafficPenalty
      - .Initialize(): If client code needs config same state to clone.
      - .DeepCopy(): Implements DeepCopy
      - .ShallowCopy(): Implements ShallowCopy
    - Infringement
      - Clone: sample using IClonnable interface to make shallow copy
    - Abstract
      - IPenalty: Client code only known object interface and can make clones 

## Singleton
- Sample Name: RunSingletonSample
- Ways to make only one Instance of a class to be used by all application
- Some developers consider it an anti-pattern
- several ways to do this implementation
-  C# dependency injection makes its automatic to you
   -  only use ServiceCollection.AddSingleton()
- Sample
  - Singleton
    - FileServer
  - Get unique instance method
    - FileServer.GetInstance
  - Thread safe by static prop initialized
  
# Structural patterns
how to assemble objects and classes to generate larger structures while keeping the structures flexible and efficient

## Adapter
- Sample Name: RunAdapterSample
- acts as an adapter to allow incompatible interfaces communication, Adapter server as a wrapper to client code interface to convert request into a form that to incompatible interface can work
- Sample
  - Adaptee
    - QuarterConsolidade: Concrete adapter that implements ISale
  - Adapter
    - SaleProcessAdapter: Concrete adaptee interface that implements IQuarterConsolidade
  - Interfaces
    - ISale: Domain interface that client knows communicate
    - IQuarterConsolidade: Another Interface that client doesn’t know how communicate
  - Dtos
    - SaleDto: Client know how use
    - QuarterDto: Client don’t know how use
   
## Bridge
- Nome exemplo: RunBridgeSample
- Tem a finalidade de desacoplar uma abstração de sua implementação de modo que as duas possam variar de forma independente
- O padrão também permite que tenha somente uma implementação e uma abstração, onde se manteria útil quando precisasse alterar a implementação da abstração em tempo de execução. 
- Permite a criação de hierarquias independentes para abstração e implementação de forma que ao estender uma não necessite alterar a outra, respeitando o princípio aberto-fechado  
- Pode ser usado quando necessitamos estender a classe em mais de uma dimensão, nestes casos podemos extrair uma dessas dimensões para outra hierarquia e usar o bridge para estruturar.
  - No caso em exemplo, poderíamos estender "residence" e criar apartamento.
- Exemplo:
  - Classes de Abstração (um dos lados da "ponte")
    - Residence: Abstração
    - House: Abstração refinada
  - Classes de implementação (outro lado da "ponte")
    - ISecurity: Interface das classes de implementação
    - GuardDog, MmaFighter: Implementações da interface ISecurity
    
## Composite
- Sample Name: RunCompositeSample
- Útil quando o modelo da aplicação deve poder ser representado em árvore, pois sua estrutura aparenta uma árvore de cabeça para baixo
- A principal intenção é permitir ao código cliente trabalhar com objetos simples e compostos utilizando da mesma interface, sem necessidade de saber o tipo do objeto e qual sua profundidade na hierarquia. Reduz a complexidade do código cliente.
- Facilita o princípio aberto/fechado
- Trabalha com recursividade.
- Se realizar o tratamento dos filhos na interface comum "Component", pode acabar quebrando o princípio da segregação de interface
- Os filhos, podes ter referência a classe pai para facilitar percorrer a árvore.
- Estrutura
  - Component: 
    - Interface de conhecimento do cliente, compartilhada por todos os objetos da árvore
    - Normalmente difícil de ser definido e acaba contendo muitos métodos e sendo mais genérico, para poder servir como interface única para composites e leafs.
  - Leaf: O objeto que não pode conter filhos
  - Composite: 
    - O objeto que pode conter filhos (leafs, composites) e pode ser utilizado como filho em outros composites
    - Passa a solicitação para os filhos podendo executar operações antes/depois do repasse de acordo com a necessidade.
- Exemplo:
  - Components
    - IComponent: Interface
    - HouseComponent: Abstração
  - Composites
    - Composite: Abstração
    - Room: Classe concreta
  - Leafs
    - Leaf: Abstração
    - Door: Classe concreta
    - Window: Classe concreta

## Decorator
- Sample Name: RunDecoratorSample
- Permite estender um objeto para adicionar para ele novas responsabilidades em tempo de execução, tornando-se uma alternativa a extensão de objetos via herança
- Usa agregação e recursividade
- Age como se fosse uma "pele" para o objeto
- Os decoradores podem agir antes e/ou depois da chamada para o objeto envolvido
- Não quebra a lógica do objeto original, os decoradores são adicionados a ele formando uma estrutura de camadas.
- Pode usar vários decoradores de vez o que aumenta as possibilidades
- Um decorador não consegue parar o fluxo, ele obrigatoriamente passará por todos os decoradores atribuído e o objeto envolvido
- O objeto que foi decorado não tem ciência disso, nem os métodos que o chamam
- Tem a abordagem use quando for necessário
  - O cliente que controla quando os comportamentos adicionais serão atribuídos
- Atenção
  - O objeto quando decorado não tem a mesma referência de memória do objeto sem decorar
  - Pode ser difícil implementar sem depender da ordem na pilha dos decoradores
- Estrutura
  - Component 
    - Interface comum ao objeto que será envolvido e o "Decorator" deve ser simples
  - ConcreteComponent: O objeto que implementa "Component" e pode ser decorado, necessário já ter um comportamento padrão
  - Decorator
    - Classe base para os decoradores implementa "Component"
    - Tem a agregação para o "Component" com a instância do "ConcreteComponent"
    - Encaminha todas as requisições para os métodos da agregação
  - ConcreteDecorator: Implementação dos decoradores executam os novos comportamentos antes e/ou depois repassam para o mesmo método na "Decorator"
- Exemplo
  - Components
    - IComponent: Interface implementada pelos objetos que podem ser estendidos pela abstração dos decoradores
    - Movie: Componente concreto
  - Decoradores
    - Decorator: Abstração
    - PostCreditDecorator: Decorador concreto
    - TrailerDecorator: Decorador concreto

## Facade
- Sample Name: RunFacadeSample