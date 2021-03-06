# Design Patterns

Console project with design patterns samples

All content is fictitious for study purposes only

# Startup Project

- DesignPatternSamples.ConsoleAPP
- Patterns index is there

# Index

| [Creational Patterns](#creational-patterns) | [Structural Pattern](#structural-patterns) |     [Behavioral Patterns](#behavioral-patterns)    |
| :-----------------------------------------: | :---------------------------------------: | :-------------------------------------------------: |
|    [Abstract Factory](#abstract-factory)    |            [Adapter](#adapter)            | [Chain of Responsibility](#chain-of-responsability) |
|             [Builder](#builder)             |             [Bridge](#bridge)             |                 [Command](#command)                 |
|      [Factory Method](#factory-method)      |          [Composite](#composite)          |             [Interpreter](#interpreter)             |
|           [Prototype](#prototype)           |          [Decorator](#decorator)          |                [Iterator](#iterator)                |
|           [Singleton](#singleton)           |             [Facade](#facade)             |                [Mediator](#mediator)                |
|                                             |          [Flyweight](#flyweight)          |                 [Memento](#memento)                 |
|                                             |              [Proxy](#proxy)              |           [Observer](#observer)                     |
|                                             |                                           |                [State](#state)                      |
|                                             |                                           |                   [Strategy](#strategy)             |
|                                             |                                           |                [Template Method](#template-method)  |
|                                             |                                           |         [Visitor](#visitor)                         |

# Creational Patterns

 Ways create objects with flexibly and reuse incremented

## Factory Method

- Sample Name: RunFactoryMethodSample
- Lazy create by subclasses
- Sample
  - Factory Method: CreateSytemOperation();
    - Abstract
      - PersonalComputerBase.CreateSytemOperation()
    - Concrete
      - ApplePC.CreateSytemOperation()
      - OfficePC.CreateSytemOperation()
      - RedHatPC.CreateSytemOperation()

## Abstract Factory

- Sample Name: RunAbstractFactorySample
- Lazy create by subclasses
- To objects families
- Sample
  - Object Families: (Police, Sport)
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
- C# dependency injection makes its automatic to you
  - only use ServiceCollection.AddSingleton()
- Sample
  - Singleton
    - FileServer
  - Get unique instance method
    - FileServer.GetInstance
  - Thread safe by static prop initialized
  
# Structural Patterns

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
    - IQuarterConsolidade: Another Interface that client doesn???t know how communicate
  - Dtos
    - SaleDto: Client know how use
    - QuarterDto: Client don???t know how use

## Bridge

- Nome do exemplo: RunBridgeSample
- Tem a finalidade de desacoplar uma abstra????o de sua implementa????o de modo que as duas possam variar de forma independente
- O padr??o tamb??m permite que tenha somente uma implementa????o e uma abstra????o, onde se manteria ??til quando precisasse alterar a implementa????o da abstra????o em tempo de execu????o.
- Permite a cria????o de hierarquias independentes para abstra????o e implementa????o de forma que ao estender uma n??o necessite alterar a outra, respeitando o princ??pio aberto-fechado  
- Pode ser usado quando necessitamos estender a classe em mais de uma dimens??o, nestes casos podemos extrair uma dessas dimens??es para outra hierarquia e usar o bridge para estruturar.
  - No caso em exemplo, poder??amos estender "residence" e criar apartamento.
- Exemplo:
  - Classes de Abstra????o (um dos lados da "ponte")
    - Residence: Abstra????o
    - House: Abstra????o refinada
  - Classes de implementa????o (outro lado da "ponte")
    - ISecurity: Interface das classes de implementa????o
    - GuardDog, MmaFighter: Implementa????es da interface ISecurity

## >Composite

- Nome do exemplo: RunCompositeSample
- ??til quando o modelo da aplica????o deve poder ser representado em ??rvore, pois sua estrutura aparenta uma ??rvore de cabe??a para baixo
- A principal inten????o ?? permitir ao c??digo cliente trabalhar com objetos simples e compostos utilizando da mesma interface, sem necessidade de saber o tipo do objeto e qual sua profundidade na hierarquia. Reduz a complexidade do c??digo cliente.
- Facilita o princ??pio aberto/fechado
- Trabalha com recursividade.
- Se realizar o tratamento dos filhos na interface comum "Component", pode acabar quebrando o princ??pio da segrega????o de interface
- Os filhos, podes ter refer??ncia a classe pai para facilitar percorrer a ??rvore.
- Estrutura
  - Component:
    - Interface de conhecimento do cliente, compartilhada por todos os objetos da ??rvore
    - Normalmente dif??cil de ser definido e acaba contendo muitos m??todos e sendo mais gen??rico, para poder servir como interface ??nica para composites e leafs.
  - Leaf: O objeto que n??o pode conter filhos
  - Composite:
    - O objeto que pode conter filhos (leafs, composites) e pode ser utilizado como filho em outros composites
    - Passa a solicita????o para os filhos podendo executar opera????es antes/depois do repasse de acordo com a necessidade.
- Exemplo:
  - Components
    - IComponent: Interface
    - HouseComponent: Abstra????o
  - Composites
    - Composite: Abstra????o
    - Room: Classe concreta
  - Leafs
    - Leaf: Abstra????o
    - Door: Classe concreta
    - Window: Classe concreta

## Decorator

- Nome do exemplo: RunDecoratorSample
- Permite estender um objeto para adicionar para ele novas responsabilidades em tempo de execu????o, tornando-se uma alternativa a extens??o de objetos via heran??a
- Usa agrega????o e recursividade
- Age como se fosse uma "pele" para o objeto
- Os decoradores podem agir antes e/ou depois da chamada para o objeto envolvido
- N??o quebra a l??gica do objeto original, os decoradores s??o adicionados a ele formando uma estrutura de camadas.
- Pode usar v??rios decoradores de vez o que aumenta as possibilidades
- Um decorador n??o consegue parar o fluxo, ele obrigatoriamente passar?? por todos os decoradores atribu??do e o objeto envolvido
- O objeto que foi decorado n??o tem ci??ncia disso, nem os m??todos que o chamam
- Tem a abordagem use quando for necess??rio
  - O cliente que controla quando os comportamentos adicionais ser??o atribu??dos
- Aten????o
  - O objeto quando decorado n??o tem a mesma refer??ncia de mem??ria do objeto sem decorar
  - Pode ser dif??cil implementar sem depender da ordem na pilha dos decoradores
- Estrutura
  - Component
    - Interface comum ao objeto que ser?? envolvido e o "Decorator" deve ser simples
  - ConcreteComponent: O objeto que implementa "Component" e pode ser decorado, necess??rio j?? ter um comportamento padr??o
  - Decorator
    - Classe base para os decoradores implementa "Component"
    - Tem a agrega????o para o "Component" com a inst??ncia do "ConcreteComponent"
    - Encaminha todas as requisi????es para os m??todos da agrega????o
  - ConcreteDecorator: Implementa????o dos decoradores executam os novos comportamentos antes e/ou depois repassam para o mesmo m??todo na "Decorator"
- Exemplo
  - Components
    - IComponent: Interface implementada pelos objetos que podem ser estendidos pela abstra????o dos decoradores
    - Movie: Componente concreto
  - Decoradores
    - Decorator: Abstra????o
    - PostCreditDecorator: Decorador concreto
    - TrailerDecorator: Decorador concreto

## Facade

- Nome do exemplo: RunFacadeSample
- Fornece uma interface simples para subsistemas, bibliotecas, frameworks para tornar mais f??cil o seu uso.
  - O cliente n??o precisa mais saber quais classes, m??todos e em qual ordem deve chama-los, basta utilizar a interface do "facade", reduzindo assim sua complexidade.
  - Como o cliente somente precisa depender do facade, facilita o reuso
- ??til para o uso de bibliotecas complexas
- Melhora o desacoplamento, pois encapsula as m??ltiplas depend??ncias para classes de um subsistema em uma ??nica classe
- O padr??o facade permite a cria????o de "facades" adicionais para poluir a ??nica "facade" com funcionalidades n??o relevantes
  - O cliente pode chamar a facade e/ou a facade adicional de forma independente
- Diminui impacto e complexidade para atualiza????o/substitui????o do subsistema que est?? atr??s do facade, bastando apenas alterar a implementa????o do facade
- Teremos no facade somente as funcionalidades do subsistema que o cliente realmente faz uso
- O facade pode conter os comportamentos padr??es mais utilizados e somente o cliente que precisarem mais do que isso, necessitariam olhar al??m do facade
- O facade pode realizar processamento, antes ou depois de chamar os subsistemas para torna-los vi??veis para os clientes
- Aten????o
  - O facade pode acabar como uma classe deus acoplado a todas as classes de uma aplica????o se n??o for bem estruturado
- Estrutura
  - IFacade: interface para uso dos clientes
  - FacadeConcreto: implementa????o dos IFacade que encapsula as depend??ncia e funcionalidades do subsistema para uso do cliente
  - Subsystem class Class:
    - Implementam a funcionalidade do subsistema
    - Se encarregam do trabalho passado para elas pelo facade
- Exemplo
  - Facade
    - IFacade: Interface
    - SalaryFacade: FacadeConcreto
  - Subsystems
    - HumanResources: Subsystem class
    - OfficerService: Subsystem class

## Flyweight

- Nome do exemplo: RunFlyweightSample
- O padr??o usa de compartilhamento para suportar eficientemente grandes quantidades de objetos, mantendo baixo o uso de mem??ria RAM
  - ?? um padr??o somente focado para otimiza????o do uso de mem??ria RAM  
  - Retorna objetos em cache inv??s de criar novos
- Somente usar quando
  - A aplica????o tem um grande n??mero de objetos, gerando um custo alto de armazenamento &&
  - A maioria dos estados(campos) destes objetos podem se tornar extr??nsecas
- Divide os campos do objeto que ir?? se tornar flyweight em dois tipos (intr??nsecos e extr??nsecos)
  - Intr??nseco: S??o independentes do contexto no qual o objeto est?? inserido, s??o imut??veis, s??o armazenados no flyweight
  - Extr??nseco: Variam com o contexto do flyweight, podem ser alterados e por isso n??o podem ser compartilhados por isso s??o retirados dos objetos flyweight
- O padr??o sugeri para de armazenar dados extr??nsecos dentro do objeto, inv??s disso, voc?? deve passar esses dados para os m??todos espec??ficos que dependam deles deixando somente o intr??nseco no objeto
  - Um objeto que guarda somente dados intr??nsecos ?? chamado de flyweight
  - Dados extr??nsecos s??o passados como par??metros para os m??todos do objeto flyweigth, se voc?? usar contexto, basta enviar o contexto par ao m??todo
- Aplicabilidade do padr??o ?? definida pela facilidade de identifica????o extr??nseco e sua remo????o dos estados compartilhados
- Os clientes devem obter os flyweight das fabricas, evitando duplicidade deles
- Aten????o
  - Usado para economizar RAM, entretanto, usa mais processamento para calcular ou obter os dados extr??nsecos que n??o s??o mais armazenados nos objetos
- Estrutura
  - Flyweight: Interface que os flyweights usam para receber e atuar nos dados extr??nsecos
  - ConcreteFlyweight: Implementa a interface "Flyweight" e armazena os estados intr??nsecos se houver, deve ser compartilhado, todo estado que ele armazena deve ser intr??nseco
  - UnsharedConcreteFlyweight: implementa a interface ???Flyweight???, mas n??o s??o compartilhados a interface "Flyweight" permite compartilhamento, mas n??o o exige
  - FlyweightFactory: Cria e gerencia objetos flyweight e seu compartilhamento quando solicitado pelo cliente
- Exemplo
  - Flyweight: ILampType
  - ConcreteFlyweight: LedType
  - FlyweightFactory: LampTypeFactory
  - Context Objects:
    - Lamp: Tem os dados extr??nsecos do flyweight
    - Shed: container dos lamps

## Proxy

- Nome do exemplo: RunProxySample
- Fornece um substituto ou espa??o reservado para outro objeto controlar o acesso a esse objeto.  
  - Focado no controle de acesso a determinado objeto
- Controla o acesso ao objeto original permitindo fazer coisas antes e/ou depois de encaminhar o pedido ao objeto original sem necessitar altera-lo
  - A depender do comportamento pode nem passar a requisi????o ao objeto original (proxy de prote????o)
  - Permite a adi????o de comportamentos sem alterar o objeto e a classe cliente.
- Permite adicionar comportamentos adicionais no objeto mesmo que n??o tenhamos acesso a classe dele (lib. terceiros).
- Atua como o objeto original para o cliente, podendo lidar com inicializa????o pregui??osa, cache de resultados, logs, controle de acesso, ..., de forma transparente ao cliente.
- O proxy n??o tem necessidade de conhecer a classe concreta do seu objeto se todas suas intera????es com ele ?? via a interface "ISubject" e n??o controlar a inicializa????o do objeto.
- Estrutura
  - Proxy: Implementa "ISubject", controla o acesso ao objeto real que ele representa
    - Aponta para o objeto real
    - Pode ter v??rios tipos
      - Proxy Prote????o: Controla o acesso ao objeto real vendo se tem as permiss??es necess??rias
      - Proxy Remoto: Usado para uma representa????o local de um objeto que est?? em um servidor remoto. Encapsula a requisi????o par??metros para realizar a requisi????o ao objeto real que est?? em outro servidor
      - Proxy Virtual: Focado na inicializa????o pregui??osa do objeto, pode conter campos de maneira a adiar a inicializa????o do objeto
      - Smart Reference: um proxy para adi????o de comportamentos adicionais, dentre os usos mais comuns:  pode ser usado para caches, logs, bloqueio do recurso.
  - ISubject: Interface comum ao proxy e ao objeto real (ambos devem implementa-la), pode ser usada em qualquer lugar que o real objeto for usado
  - ConcreteSubject: Implementa "ISubject", o objeto real que ser?? representado pelo proxy
- Exemplo
  - ConcreteSubject: Storage
  - ISubject: IStorage  
  - Proxy: StorageProxy - adicionando comportamentos de logs, checagem de bloqueio, controle de inicializa????o pregui??osa

# Behavioral Patterns

Se preocupam com o algoritmo e com a atribui????o de responsabilidades entre os objetos

Descrevem padr??es de objeto, classes e o padr??o de comunica????o entre eles

Podem ser de Classe (Template Method, Interpreter) e de Objeto (Os demais)

## Chain of Responsibility

- Nome do exemplo: RunChainOfResponsabilitySample
- Lida com uma corrente de handler, onde cada handler decide deve processar a requisi????o ou passa para o pr??ximo handler na corrente
  - Passa um pedido sequencialmente ao longo de uma corrente din??mica de potenciais destinat??rios at?? que um deles atua no pedido
  - Evitar o acoplamento do remetente de uma solicita????o ao seu receptor, ao d?? a mais de um objeto oportunidade de tratar a requisi????o atrav??s de uma corrente encadeando os receptores at?? que algum o trate  
- Encontrei duas metodologias para o mesmo padr??o, eu acredito que ambas s??o validas
  1. Ap??s um handler tratar a requisi????o ele deve encerrar a chain, fazendo com que s?? seja tratada por um handler
  2. Ap??s ser tratado por um handler este pode ou n??o passar a requisi????o para o pr??ximo n?? da chain permitindo a mais de um handler tratar a mesma requisi????o
- Utilize o padr??o quando ?? essencial executar diversos handlers em uma ordem espec??fica
  - Voc?? pode controlar a ordem de tratamento dos pedidos.
- Utilize o padr??o quando o conjunto de handlers e suas requisi????es devem mudar durante a execu????o
  - A cadeia pode ser composta dinamicamente em tempo de execu????o com qualquer handler que siga uma interface de handler padr??o
  - Usar quando o programa deve estar preparado para processar diferentes tipos de pedidos de v??rias maneiras, mas os exatos tipos de pedidos e suas sequ??ncias s??o desconhecidos de antem??o.
- Pode ser usado com o composite ou heran??a fazendo o pai do item ser o pr??ximo handler da corrente e usando para percorrer a hierarquia
- Aten????o
  - Alguns pedidos podem acabar sem tratamento por n??o encontrar um receptor valido
- Estrutura
  - Handler: Abstra????o comum aos handlers concretos
    - Normalmente s?? tem o m??todo executar, o m??todo de v??nculo com o pr??ximo handler da Chain e sua refer??ncia.
  - ConcreteHandler: implementa a abstra????o handler
    - Cont??m o c??digo real que ir?? ser processado
    - Trata as requisi????es pelo qual ?? respons??vel, passa ao pr??ximo elo caso n??o consiga
- Exemplo
  - Handler
    - IHandler: Interface comum aos handlers concretos
    - Handler: Classe Abstrata comum aos handlers concretos, tem a refer??ncia ao pr??ximo e implementa????o b??sica para os m??todos do IHandler
  - ConcreteHandler
    - StartedHandler: Handler concreto
    - MiddleHandler: Handler concreto
    - FinishedHandler: Handler concreto

## Command

- Nome do exemplo: RunCommandSample
- O Command ?? um padr??o de projeto comportamental que encapsula uma solicita????o como um objeto, desta forma permitindo:
  - Parametrizar clientes com diferentes solicita????es
  - Enfileirar: Colocar opera????es em fila, agendar sua execu????o ou execut??-las remotamente
  - Registrar logs de solicita????es
  - Meios para realizar o Desfazer/refazer das opera????es  
- O comando deve ser capaz ou, pr??-configurado para obter os par??metros por conta pr??pria.
- Criasse uma nova classe comando para cada poss??vel opera????o e liga ao remetente dependendo do comportamento desejado.
- Os comandos se tornam uma camada interm??dia conveniente que reduz o acoplamento entre as camadas GUI e de l??gica do neg??cio
- Um comando pode chamar o mesmo receiver mais de uma vez
- Usar quando
  - Voc?? quer parametrizar objetos com opera????es
  - Voc?? quer enfileirar as opera????es
  - Voc?? quer implementar opera????es revers??veis
- Estrutura
  - Command: Interface para execu????o de uma opera????o, geralmente declara apenas um ??nico m??todo para executar do comando.
  - ConcreteCommand: Define um v??nculo entre um objeto receiver e uma opera????o
    - Implementa o m??todo do command delegando as respectivas opera????es no reciever
  - Invoker: Pede ao comando para realizar a opera????o
    - Pode est?? associado a mais de 1 comando
  - Receiver: Cont??m a l??gica do neg??cio
    - Sabe como realizar as opera????es vinculadas ao pedido
    - Qualquer classe pode funcionar como um reciever
- Exemplo
  - Command: ICommand
  - ConcreteCommand: AlertCommand
  - Invoker: Invoker
  - Receiver: PromotionService

## Interpreter

- Nome do exemplo: RunInterpreterSample
- Dada uma linguagem, descreve como definir uma representa????o para a sua gramatica juntamente com um interpretador que usa a representa????o para interpretar senten??as dessa linguagem
- Deve ser usado quando tem uma linguagem simples para interpretar e for poss??vel representar senten??as da linguagem como arvores sint??ticas abstratas
- Para tirar melhor proveito:
  - A gramatica deve ser simples: para evitarmos gramaticas complexas que s??o dif??ceis de manter devido a grande hierarquia de classes necess??ria para interpret??-la
  - A efici??ncia ?? n??o deve ser uma preocupa????o cr??tica: os interpretadores mais eficientes normalmente n??o s??o implementados pela interpreta????o direta da arvore de analise sint??tica
- Torna f??cil mudar e estender a gramatica
- Estrutura
  - AbstractExpression: define a interface para execu????o da opera????o de interpreta????o a todos os n??s da arvore sint??tica abstrata
  - TerminalExpression: s??o os s??mbolos finais da gramatica n??o s??o compostos por outros AbstractExpression
    - Implementa a opera????o ???Interpret??? associada com s??mbolos de terminal na gramatica
    - Necessitada de uma inst??ncia para cada s??mbolo de terminal na senten??a
  - NonterminalExpression: s??o compostos por outros AbstractExpression
    - Mant??m vari??veis de inst??ncia do tipo AbstractExpression (terminais ou outras non terminais) para cada um dos s??mbolos R1 a Rn.
    - Implementa uma opera????o ???Interpret??? para s??mbolos n??o terminais na gram??tica. ???Interpret??? normalmente chama a si mesmo recursivamente nas vari??veis que representam R1 a Rn
  - Context: Cont??m informa????es que s??o globais ao interpretador
    - como a express??o a ser interpretada e a situa????o atual da interpreta????o
- Exemplo
  - AbstractExpression
    - IAbstractExpression: Interface como m??todo ???Interpret???
    - AbstractExpression: Abstra????o - Usada para centralizar alguns dados comuns a todos os n??s
  - TerminalExpression:
    - HundredExpression: Traduz os s??mbolos da casa das centenas
    - OneExpression: Traduz os s??mbolos da casa das unidades
    - TenExpression: Traduz os s??mbolos da casa das dezenas
  - Context: Context
  
## Iterator

- Nome do exemplo: RunIteratorSample
- A ideia principal do padr??o ?? extrair o comportamento de travessia de uma cole????o para um objeto separado chamado um "iterator"
  - Permite percorrer os elementos de um objeto agregado sequencialmente sem expor sua representa????o subjacente (lista, pilha, ??rvore, etc.)
- Permite executar m??ltiplos percursos em paralelo na mesma cole????o devido ao encapsulamento de todos os detalhes da travessia no objeto ???iterator???
- O c??digo cliente pode n??o ter acesso a cole????o que est?? sendo percorrida
  - O c??digo cliente n??o necessita ter acesso/ci??ncia da cole????o que est?? sendo percorrida basta usar o iterator
- Melhora a interface das listas pois extrai os m??todos de percursos para o iterator
  - N??o enche a interface da cole????o com m??todos para os variados percursos que podem ser usados nela
- A ideia chave desse padr??o ?? retirar a reponsabilidade de acesso e percurso da lista e colocar no interater
- Existe mais de uma forma de implementa????o do iterator (internos, externos)
  - Externo: o controle do percurso fica no cliente, ele que chama os m??todos de percursos do iterator (Pegar item atual, chamar o pr??ximo, iniciar o percurso, ...)
  - Interno: a interface do iterator fica mais simples e o cliente pode chama s?? uma opera????o que consolida as supracitadas dentro iterator, com isso o cliente perde um pouco de controle sobre o percurso
- Usar quando
  - Quer acessar o conte??do das cole????es sem acopla-las no c??digo cliente, protegendo a cole????o das intera????es do cliente e escondendo sua complexidade
  - Quer ter suporte a m??ltiplos percursos
- Estrutura
  - Iterator: Interface que declara as opera????es necess??rias para percorrer uma cole????o: buscar o pr??ximo elemento, pegar a posi????o atual, recome??ar a itera????o, etc.
  - ConcreteIterator: Implementam algoritmos espec??ficos para percorrer uma cole????o
    - Respons??vel por monitorar todo o progresso da travessia por conta pr??pria
    - Pode ter mais opera????es para ajud??-lo no percurso al??m das recorrentes (First, Next, IsDone, CurrentItem)
  - Aggregate: Interface das cole????es
    - Descreve os m??todos para obter os integradores
  - ConcreteAggregate: Retorna a inst??ncia do ConcreteIterator apropriada para a cole????o
- Exemplo
  - Iterator: IIterator
  - ConcreteIterator: ImparIterator
  - Aggregate: IAggregate
  - ConcreteAggregate: FruitAggregate

## Mediator

- Nome do exemplo: RunMediatorSample
- Define um objeto (Mediator) que encapsula a forma como um conjunto de objetos interagem entre si
  - Faz com que todas as comunica????es diretas entre os objetos sejam direcionadas para o mediator tornando-as indiretas
- Reduz o acoplamento entre objetos
  - Agora todos os objetos s?? necessitam conhecer o mediator e ele redireciona as chamadas para os "colleagues" apropriados
  - Melhora o reuso dos "colleagues" pois retira as depend??ncias internas deles com outros objetos substituindo-os pelo mediator
- Diminui a quantidade de subclasses de "colleagues" quando a ??nica finalidade delas ?? mudar o formato como tratam os outros objetos
  - Essa intera????o ?? movida para o mediator, bastando o "colleague" deve somente sinalizar ao mediator quando algo significante acontecer
- Pode usar o MediatR para implementar
- Aten????o
  - A complexidade do Mediator aumenta proporcionalmente ao tamanho/complexidade do conjunto de objetos que ele encapsula e seu crescimento, ficar atento para n??o o tornar um "god object"
- Estrutura:
  - Colleague: S??o as classes de neg??cio conhecem o mediator por sua interface
    - Envia e recebe solicita????o do mediator, n??o dever ter ci??ncia dos outros Colleagues e somente falar com eles atrav??s do mediator
  - Mediator: Interface comum aos mediator normalmente s?? um m??todo que recebe a notifica????o e quem o est?? notificando
  - ConcreteMediator: Implementam a interface Mediator
    - Encapsula as rela????es entre v??rios componentes
    - Implementa o comportamento cooperativo entre as classes "Colleagues", mant??m refer??ncia a todos os objetos que gerencia
- Exemplo
  - Colleague: Colleague1, Colleague2, Colleague3
  - Mediator: IMediator
  - ConcreteMediator: ConcreteMediator

## Memento

- Nome do exemplo: RunMementoSample
- Permite capturar e externalizar o estado interno de um objeto sem feri seu encapsulamento (sem revelar os detalhes de sua implementa????o), permitindo ao objeto voltar a este estado caso necess??rio
- Armazena a c??pia do estado de um objeto em outro objeto especial chamado memento
  - O conte??do do memento s?? ?? acess??vel ao objeto que o construiu  
  - Os outros objetos (inclusive o cuidador) usam uma interface limitada com acesso somente aos metadados para identifica????o do memento, n??o tem acesso aos dados internos do estado armazenado
- Toda a????o que mude o estado do objeto e deseje ser revers??vel, deve salvar o estado e no "memento" e armazena-lo em um cuidador que criar como um hist??rico para recupera????o futura.
- O padr??o delega a cria????o dos snapshots para o pr??prio objeto originador que decide o que colocar?? no memento.
  - Evita a exposi????o de informa????es que somente o originador deveria acessar
  - Simplifica o originador pois, remove dele a gest??o dos snapshots das vers??es de seu estado
- Aten????o
  - Se s??o salvos mementos com muita frequ??ncia pode ter um custo de RAM
  - O cuidador deve acompanhar o ciclo de vida do objeto originador para remover mementos obsoletos
- Estrutura
  - Memento: Armazena o estado interno do objeto originador, imut??vel
  - Originator: O objeto que pode ter seu estado restaurado
    - Cria o memento contendo um retrato do seu status atual quando for necess??rio
    - Consegue restaurar seu estado fazendo uso do memento
  - Caretaker: Respons??vel pela cust??dia dos mementos par quando forem necess??rios
    - N??o pode acessar nem alterar os estados internos do memento
- Exemplo:
  - Memento: BillMemento
    - IMemento: interface simplificada do memento para n??o percibe que outras classes acessem o conteudo dele
  - Originator: Bill
  - Caretaker: MementoManager

## Observer

- Nome do exemplo: RunObserverSample
- Permite que um objeto notifique outros objetos sobre altera????es em seu estado
  - Cria um mecanismo de assinatura para que a altera????o de um objeto "subject" notifique m??ltiplos objetos dependentes que ir??o se atualizar automaticamente
  - N??o limita a quantidade objetos de inscritos
- Fornece uma maneira de assinar e cancelar a assinatura dos objetos que implementam a interface de observer
  - Os subjects fornecem a interface para adicionar e remover assinantes a qualquer momento
- Os observadores t??m a responsabilidade de tratar ou ignorar uma notifica????o, podem acompanhar mais de um subject ao mesmo tempo
- A notifica????o de mudan??a pode ser disparada pelo subject ou pelo ciente, vai depender do contexto
- ??til quando
  - Mudan??as no estado de um objeto precisem mudar outros objetos e estes s??o desconhecidos ou mudam dinamicamente
  - Quando um observer precisar acompanhar um subject por um per??odo definido de tempo
- Em ambientes de relacionamentos complexos entre Observers e Subjects pode ter uma classe Change Manager para diminuir o trabalho necess??rio para que um observador reflita as mudan??as de um subject
  - Quando a altera????o de v??rios subjects interdependentes reflitam no observer pode ser prefer??vel que todos mudem seu estado e s?? aconte??a uma notifica????o no final no lugar um a cada mudan??a intermedi??ria
- Estrutura
  - Subject (Publisher): Interface para defini????o dos Subjects cont??m os m??todos para gerenciamento da subscri????o
  - ConcreteSubject: Implementa o Subject
    - Envia as notifica????es aos observadores e os conhece somente pela interface "Observer"
    - Permitem a inscri????o de assinantes ou remo????o dos atuais
    - Envia dado de contexto para correto tratamento do evento pelo observer
  - Observer (Subscriber): Interface do objeto assinante normalmente cont??m a defini????o do m??todo que vai receber a notifica????o do subject, pode conter par??metros para agregar contexto
  - ConcreteObserver: Implementa a interface Observer
    - Implementa a interface observer para deixar seus dados consistentes com as mudan??as ocorridas nos subjects
- Exemplo
  - Subject: ISubject
  - ConcreteSubject: Pedido
  - Observer: IObserver
  - ConcreteObserver: Separation

## State

- Nome do exemplo: RunStateSample
- Permite que um objeto altere seu comportamento quando seu estado interno muda. O objeto aparecer?? para alterar sua classe.
  - Altera o comportamento quando seu estado interno ?? alterado
- O Padr??o extrai da classe comportamentos relacionados ao estado, os adiciona em classes separadas de estado e delega a essas classes as a????es relacionadas quando solicitado
  - Tira os v??rios if/switch do c??digo do objeto cuja finalidade ?? se comportar de maneiras diferentes a depender do estado movendo-os para seus estados espec??ficos
- Melhora a elegibilidade e maneabilidade do c??digo
  - Com os estados fora da classe contexto torna mais f??cil descobri a inten????o do c??digo e estend??-lo
- Os estados devem ser finitos e em caso da cria????o de um novo ser?? necess??ria a cria????o de uma nova classe
- O objeto que tem o estado ?? chamado de contexto, ele refer??ncia o estado por meio de interface comum todos os estados delegando as altera????es que impactam estados para seu estado
- Tanto o Contexto como os objetos estados podem alterar o estado atual  
- ??til quando
  - Voc?? tem um objeto que se comporta de maneira diferente dependendo do seu estado atual e/ou uma classe cheia de condicionais gigantes que alteram como a classe se comporta de acordo com os valores atuais dos campos da classe
- Quando tem c??digo duplicado comum entre os estados pode criar uma abstra????o e deixar os valores comum como comportamento padr??o
- Estrutura
  - Context: Mantem uma inst??ncia de ConcreteState que define o estado atual
    - ?? a interface de conhecimento do cliente
  - State: Define a interface para os estados com os m??todos que interagem com o contexto
  - ConcreteState: Implementa o State
    - Cada subclasse implementa um comportamento para os m??todos da interface a depender do estado que elas representem
    - Pode mudar o Estado do Contexto
- Exemplo
  - Context: Water, IContext
  - State: IState
  - ConcreteState: Solid ,Liquid, Gas

## Strategy

- Nome do exemplo: RunStrategySample
- Encapsula os poss??veis algoritmos em uma classe strategy permitindo que variem independentes dos clientes que a utilizam
- O contexto delega para a inst??ncia da estrat??gia que est?? vinculado para executar o algoritmo
  - Este algoritmo pode ser substitu??do em tempo de execu????o atrav??s da substitui????o da instancia da estrat??gia
- Reduz a complexidade e os c??digos duplicados
  - Remove da classe as condicionais relacionadas a algoritmos e criando suas classes especificas
  - Simplifica hierarquias onde a diferen??a entre as subclasses ?? como tratam determinado algoritmo
- Isola os detalhes na implementa????o do algoritmo para os objetos que o usa
- O contexto pode passar os dados necess??rios para a estrat??gia, passar a se mesmo e a estrague busca as informa????es ou a estrat??gia ter a refer??ncia para o contexto e a estrat??gia buscar as informa????es
  - Pode definir uma interface para a estrat??gia acessa-lo
- AS estrat??gias se tronam totalmente independentes entre si
- Estrutura
  - Context: Contem a refer??ncia a estrat??gia concreta
  - Strategy: Declara uma interface comum para todos os algoritmos, o contexto usa a interface para chamar o algoritmo na estrat??gia concreta
  - ConcreteStrategy: implementa o algoritmo usando a interface da estrat??gia
- Exemplo
  - Context: VacationService
  - Strategy: IStrategy
  - ConcreteStrategy: TimeInCompanyStrategy, FastToReturnStrategy, LongestOverdueStrategy

## Template Method

- Nome do exemplo: RunTemplateMethodSample
- Sugere criar um m??todo na superclasse (template method) com um esqueleto para o algoritmo dividindo-o em uma s??rie de etapas e permite as subclasses estender essas etapas.
  - Declara m??todos que agem como etapas de um algoritmo
  - Permite que subclasses redefinam certas etapas de um algoritmo sem mudar a estrutura do mesmo
- Ajuda a reduzir a duplica????o de c??digo
- Coloca na superclasse os comportamentos invariantes dos m??todos que forem poss??veis e as subclasses s?? implantam o comportamento vari??vel
- Pode usar hooks para os comportamentos opcionais
  - Normalmente m??todos vazios na superclasse que podem ser sobrescritos pelas subclasses que necessitam estende-los
- Template Method pode ter
  - Opera????es concretas e concretas de abstracts: m??todos concretos virtuais ou n??o, chamados ou implementados na superclasse
  - Opera????es primitivas: m??todos abstratos devem ser sobrescritos
  - Hooks: m??todos opcionais vazios na superclasse, mas podem ser sobrescrito nas subclasses
- Aten????o:
  - Se tiver muitas etapas pode ser dif??cil manter o c??digo
  - ?? uma extens??o de comportamento est??tica pois est?? vinculada a heran??a e n??o pode ser mudado em tempo de execu????o
- Estrutura
  - AbstractClass: Define a estrutura do algoritmo dentro do template m??todo, seu esqueleto
    - Define os m??todos que comp??em o template m??todo (primitivos, concretos, hooks)
    - Cont??m a implementa????o dos comportamentos que s??o invariantes
  - ConcreteClass: Implementa as etapas (primitivas, hooks, virtuais) para ficar consistente com a sua tratativa especifica para o algoritmo
- Exemplo
  - AbstractClass: AbstractClass
  - ConcreteClass: Concrete1, Concrete2

## Visitor

- Nome do exemplo: RunVisitorSample
- Permite definir uma nova opera????o para uma hierarquia de classe sem mudar o c??digo existente dessas classes
  - Permite separar algoritmos dos objetos nos quais eles operam
  - Representa uma opera????o a ser executada nos elementos de uma estrutura de objetos
- Cada elemento decide qual m??todo do visitor ir?? usar
  - Os m??todos do visitor conhecem as classes concretas dos elementos e s??o especializados para trabalhar com eles, cada classe concreta de elemento chama o m??todo especifico para lidar com ele
- Ajuda a manter o c??digo das classes dos elementos limpos de comportamentos auxiliares
  - Esses comportamentos s??o movidos para os visitors, deixando a classe original independente das opera????es que se aplicam a ela
- O visitor pode manter o m??todo vazio para elementos que julgar que n??o faz sentido ter o comportamento
- Usa o double dispatch pois o m??todo a ser executado depende a inst??ncia do elemento e do visitor
- Valido quando for necess??rio executar uma opera????o em todos os elementos de uma estrutura de objetos mesmo que sejam de classes diferentes
- Visitor torna f??cil a adi????o de novas opera????es na estrutura
  - Podemos estender a hierarquia elemento simplesmente adicionado mais um concrete vistor inv??s de alterar toda as v??rias classes do elemento
- Valido quando voc?? n??o quer poluir o elemento com novas implementa????es distintas e n??o relacionadas  
- Cada Visitor concrete define opera????es diferentes para a mesma estrutura, cada um com sua finalidade especifica
  - Mantem as opera????es relacionadas juntas na mesma classe visitor
- Permite criar duas estruturas hier??rquicas uma para os elementos e outra para os visitor
- Deve aplicar o concrete visitor e todos os elementos da estrutura
- ?? necess??rio um Visitor abstrato para cada estrutura de dados
- Aten????o:
  - Se as classes da estrutura de elementos mudam com frequ??ncia e complicado manter o visitor
    - Tem que atualizar todos os visitantes quando uma nova classe da estrutura ?? adicionada
    - Pensar antes de usar qual a altera????o mais prov??vel do algoritmo aplicado a estrutura ou das classes que a comp??em
- Estrutura:
  - Element: Interface que declara um m??todo para ???aceitar??? visitantes atrav??s da interface deles
  - ConcreteElement: implementar element
    - Direciona a chamada para o m??todo do visitante apropriado que corresponde com a atual classe elemento,passando a si mesmo como par??metro.
  - Visitor: Interface que declara o conjunto de m??todos visitantes para cada elemento da estrutura de objetos,esses m??todos devem receber os objetos concretos da estrutura
  - ConcreteVisitor: implementa o comportamento para cada concrete element seguindo sua interface
    - Pode armazenar estado local para ser acumulado ?? medida que percorre a estrutura, e pode ser usado comocontexto nas chamadas
  - ObjectStructure: A estrutura de objetos podendo ser ???composite??? ou cole????es
    - Pode enumerar seus objetos
    - Pode ter interfaces de alto n??vel para uso dos visitor
- Exemplo:
  - Element: IElement
  - ConcreteElement: ConcreteEl1, ConcreteEl2, ConcreteEl3
  - Visitor: IVisitor
  - ConcreteVisitor: ConcreteVisitor1, ConcreteVisitor2
  - ObjectStructure: objectStructure
