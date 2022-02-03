# Design Patterns
Console project with design patterns samples

All content is fictitious for study purposes only

# Startup Project
- DesignPatternSamples.ConsoleAPP
- Patterns index are there
- Samples cliente is here

# Creational Patterns
Ways create objects with flexibily and reuse incremented

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
- To objects familys
- Sample
  -  Object Familys: (Police, Sport)
  - Abstract Factory
     - VehicleFactory
   - Concrete Factories
     - PoliceVehicleFactory
     - SportVehicleFactory

## Builder
- Sample Name: RunBuilderSample
- Way to assemble complex objects "products" by parts
- Can get different kind of "products" using the same Builder Interface, but in this case, Build() method need in concrets builders. With products have a common interface or abract class Build() should be in builders interface.
- Sample    
  - Builders: DragonBuilder, WingBuilder, HeadBuild
    - Build Method: *Builder.Build()
  - Products: Dragon, Head, Wing
  - Director(Optional): DragonTrainer

## Prototype
- Sample Name: RunPrototypeSample
- Way to create copy of exists object, even without knowing concrete class or yours private properties
- Can exists a prototype register to control all prototype objects when required
- Sample
  - Prototype Object:
    - prototype
  - Clones
    - deepClone: Made with DeepCopy
    - shallowClone: Made with ShallowCopy
  - Concrete
    - TrafficPenalty
      - .Initialize(): If client code need config same state to clone.
      - .DeepCopy(): Implements DeepCopy
      - .ShallowCopy(): Implements ShallowCopy
    - Infringement
      - Clone: sample using IClonnable interface to make shallow copy
    - Abstract
      - IPenalty: Cliente code only khown object interface and can make clones 

## Singleton
- Sample Name: RunSingletonSample
- Ways to make only one Instance of a class to be used by all application
- Some developers consider it an anti pattern
- several ways to do this implementation
-  C# dependency injection makes its automatic to you
   -  only use ServiceCollection.AddSingleton()
- Sample
  - Singleton
    - FileServer
  - Get unique instance method
    - FileServer.GetInstance
  - Thread safe by static prop intialized
  
# Structural patterns
how to assemble objects and classes to generate larger structures while keeping the structures flexible and efficient

## Adapter
- Sample Name: RunAdapterSample
- acts as an adapter to allow incompatible interfaces communication, Adapter server as a wrapper to client code interface to convert resquest into a form that to incompatible interface can work
- Sample
  - Adaptee
    - QuarterConsolidade: Concrete adapter that implements ISale
  - Adapter
    - SaleProcessAdapter: Concrete adaptee interface that implements IQuarterConsolidade
  - Interfaces
    - ISale: Domain interface that client khow comunicate
    - IQuarterConsolidade: Another Interface that client don't khow how comunicate
  - Dtos
    - SaleDto: Client khow how use
    - QuarterDto: Client dont khow how use
   
## Bridge
- Nome exemplo: RunBridgeSample
- Tem a finalidade de desacoplar uma abstração de sua implementação de modo que as duas possam variar de forma independente
- O padrão também permite que tenha somente uma implementação e uma abstração, onde se manteria útil quando precisasse alterar a implementação da abstração em tempo de execução. 
- Permite a criação de hierarquias idependentes para abstração e implementação de forma que ao estender uma não necessite alterar a outra, respeitando o princípio aberto-fechado  
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
- Sample Name: RunABridgeSample
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