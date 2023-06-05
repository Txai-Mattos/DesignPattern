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
    - IQuarterConsolidade: Another Interface that client doesn’t know how communicate
  - Dtos
    - SaleDto: Client know how use
    - QuarterDto: Client don’t know how use

## Bridge

- Nome do exemplo: RunBridgeSample
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

- Nome do exemplo: RunCompositeSample
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

- Nome do exemplo: RunDecoratorSample
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

- Nome do exemplo: RunFacadeSample
- Fornece uma interface simples para subsistemas, bibliotecas, frameworks para tornar mais fácil o seu uso.
  - O cliente não precisa mais saber quais classes, métodos e em qual ordem deve chama-los, basta utilizar a interface do "facade", reduzindo assim sua complexidade.
  - Como o cliente somente precisa depender do facade, facilita o reuso
- Útil para o uso de bibliotecas complexas
- Melhora o desacoplamento, pois encapsula as múltiplas dependências para classes de um subsistema em uma única classe
- O padrão facade permite a criação de "facades" adicionais para poluir a única "facade" com funcionalidades não relevantes
  - O cliente pode chamar a facade e/ou a facade adicional de forma independente
- Diminui impacto e complexidade para atualização/substituição do subsistema que está atrás do facade, bastando apenas alterar a implementação do facade
- Teremos no facade somente as funcionalidades do subsistema que o cliente realmente faz uso
- O facade pode conter os comportamentos padrões mais utilizados e somente o cliente que precisarem mais do que isso, necessitariam olhar além do facade
- O facade pode realizar processamento, antes ou depois de chamar os subsistemas para torna-los viáveis para os clientes
- Atenção
  - O facade pode acabar como uma classe deus acoplado a todas as classes de uma aplicação se não for bem estruturado
- Estrutura
  - IFacade: interface para uso dos clientes
  - FacadeConcreto: implementação dos IFacade que encapsula as dependência e funcionalidades do subsistema para uso do cliente
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
- O padrão usa de compartilhamento para suportar eficientemente grandes quantidades de objetos, mantendo baixo o uso de memória RAM
  - É um padrão somente focado para otimização do uso de memória RAM  
  - Retorna objetos em cache invés de criar novos
- Somente usar quando
  - A aplicação tem um grande número de objetos, gerando um custo alto de armazenamento &&
  - A maioria dos estados(campos) destes objetos podem se tornar extrínsecas
- Divide os campos do objeto que irá se tornar flyweight em dois tipos (intrínsecos e extrínsecos)
  - Intrínseco: São independentes do contexto no qual o objeto está inserido, são imutáveis, são armazenados no flyweight
  - Extrínseco: Variam com o contexto do flyweight, podem ser alterados e por isso não podem ser compartilhados por isso são retirados dos objetos flyweight
- O padrão sugeri para de armazenar dados extrínsecos dentro do objeto, invés disso, você deve passar esses dados para os métodos específicos que dependam deles deixando somente o intrínseco no objeto
  - Um objeto que guarda somente dados intrínsecos é chamado de flyweight
  - Dados extrínsecos são passados como parâmetros para os métodos do objeto flyweigth, se você usar contexto, basta enviar o contexto par ao método
- Aplicabilidade do padrão é definida pela facilidade de identificação extrínseco e sua remoção dos estados compartilhados
- Os clientes devem obter os flyweight das fabricas, evitando duplicidade deles
- Atenção
  - Usado para economizar RAM, entretanto, usa mais processamento para calcular ou obter os dados extrínsecos que não são mais armazenados nos objetos
- Estrutura
  - Flyweight: Interface que os flyweights usam para receber e atuar nos dados extrínsecos
  - ConcreteFlyweight: Implementa a interface "Flyweight" e armazena os estados intrínsecos se houver, deve ser compartilhado, todo estado que ele armazena deve ser intrínseco
  - UnsharedConcreteFlyweight: implementa a interface “Flyweight”, mas não são compartilhados a interface "Flyweight" permite compartilhamento, mas não o exige
  - FlyweightFactory: Cria e gerencia objetos flyweight e seu compartilhamento quando solicitado pelo cliente
- Exemplo
  - Flyweight: ILampType
  - ConcreteFlyweight: LedType
  - FlyweightFactory: LampTypeFactory
  - Context Objects:
    - Lamp: Tem os dados extrínsecos do flyweight
    - Shed: container dos lamps

## Proxy

- Nome do exemplo: RunProxySample
- Fornece um substituto ou espaço reservado para outro objeto controlar o acesso a esse objeto.  
  - Focado no controle de acesso a determinado objeto
- Controla o acesso ao objeto original permitindo fazer coisas antes e/ou depois de encaminhar o pedido ao objeto original sem necessitar altera-lo
  - A depender do comportamento pode nem passar a requisição ao objeto original (proxy de proteção)
  - Permite a adição de comportamentos sem alterar o objeto e a classe cliente.
- Permite adicionar comportamentos adicionais no objeto mesmo que não tenhamos acesso a classe dele (lib. terceiros).
- Atua como o objeto original para o cliente, podendo lidar com inicialização preguiçosa, cache de resultados, logs, controle de acesso, ..., de forma transparente ao cliente.
- O proxy não tem necessidade de conhecer a classe concreta do seu objeto se todas suas interações com ele é via a interface "ISubject" e não controlar a inicialização do objeto.
- Estrutura
  - Proxy: Implementa "ISubject", controla o acesso ao objeto real que ele representa
    - Aponta para o objeto real
    - Pode ter vários tipos
      - Proxy Proteção: Controla o acesso ao objeto real vendo se tem as permissões necessárias
      - Proxy Remoto: Usado para uma representação local de um objeto que está em um servidor remoto. Encapsula a requisição parâmetros para realizar a requisição ao objeto real que está em outro servidor
      - Proxy Virtual: Focado na inicialização preguiçosa do objeto, pode conter campos de maneira a adiar a inicialização do objeto
      - Smart Reference: um proxy para adição de comportamentos adicionais, dentre os usos mais comuns:  pode ser usado para caches, logs, bloqueio do recurso.
  - ISubject: Interface comum ao proxy e ao objeto real (ambos devem implementa-la), pode ser usada em qualquer lugar que o real objeto for usado
  - ConcreteSubject: Implementa "ISubject", o objeto real que será representado pelo proxy
- Exemplo
  - ConcreteSubject: Storage
  - ISubject: IStorage  
  - Proxy: StorageProxy - adicionando comportamentos de logs, checagem de bloqueio, controle de inicialização preguiçosa

# Behavioral Patterns

Se preocupam com o algoritmo e com a atribuição de responsabilidades entre os objetos

Descrevem padrões de objeto, classes e o padrão de comunicação entre eles

Podem ser de Classe (Template Method, Interpreter) e de Objeto (Os demais)

## Chain of Responsibility

- Nome do exemplo: RunChainOfResponsabilitySample
- Lida com uma corrente de handler, onde cada handler decide deve processar a requisição ou passa para o próximo handler na corrente
  - Passa um pedido sequencialmente ao longo de uma corrente dinâmica de potenciais destinatários até que um deles atua no pedido
  - Evitar o acoplamento do remetente de uma solicitação ao seu receptor, ao dá a mais de um objeto oportunidade de tratar a requisição através de uma corrente encadeando os receptores até que algum o trate  
- Encontrei duas metodologias para o mesmo padrão, eu acredito que ambas são validas
  1. Após um handler tratar a requisição ele deve encerrar a chain, fazendo com que só seja tratada por um handler
  2. Após ser tratado por um handler este pode ou não passar a requisição para o próximo nó da chain permitindo a mais de um handler tratar a mesma requisição
- Utilize o padrão quando é essencial executar diversos handlers em uma ordem específica
  - Você pode controlar a ordem de tratamento dos pedidos.
- Utilize o padrão quando o conjunto de handlers e suas requisições devem mudar durante a execução
  - A cadeia pode ser composta dinamicamente em tempo de execução com qualquer handler que siga uma interface de handler padrão
  - Usar quando o programa deve estar preparado para processar diferentes tipos de pedidos de várias maneiras, mas os exatos tipos de pedidos e suas sequências são desconhecidos de antemão.
- Pode ser usado com o composite ou herança fazendo o pai do item ser o próximo handler da corrente e usando para percorrer a hierarquia
- Atenção
  - Alguns pedidos podem acabar sem tratamento por não encontrar um receptor valido
- Estrutura
  - Handler: Abstração comum aos handlers concretos
    - Normalmente só tem o método executar, o método de vínculo com o próximo handler da Chain e sua referência.
  - ConcreteHandler: implementa a abstração handler
    - Contém o código real que irá ser processado
    - Trata as requisições pelo qual é responsável, passa ao próximo elo caso não consiga
- Exemplo
  - Handler
    - IHandler: Interface comum aos handlers concretos
    - Handler: Classe Abstrata comum aos handlers concretos, tem a referência ao próximo e implementação básica para os métodos do IHandler
  - ConcreteHandler
    - StartedHandler: Handler concreto
    - MiddleHandler: Handler concreto
    - FinishedHandler: Handler concreto

## Command

- Nome do exemplo: RunCommandSample
- O Command é um padrão de projeto comportamental que encapsula uma solicitação como um objeto, desta forma permitindo:
  - Parametrizar clientes com diferentes solicitações
  - Enfileirar: Colocar operações em fila, agendar sua execução ou executá-las remotamente
  - Registrar logs de solicitações
  - Meios para realizar o Desfazer/refazer das operações  
- O comando deve ser capaz ou, pré-configurado para obter os parâmetros por conta própria.
- Criasse uma nova classe comando para cada possível operação e liga ao remetente dependendo do comportamento desejado.
- Os comandos se tornam uma camada intermédia conveniente que reduz o acoplamento entre as camadas GUI e de lógica do negócio
- Um comando pode chamar o mesmo receiver mais de uma vez
- Usar quando
  - Você quer parametrizar objetos com operações
  - Você quer enfileirar as operações
  - Você quer implementar operações reversíveis
- Estrutura
  - Command: Interface para execução de uma operação, geralmente declara apenas um único método para executar do comando.
  - ConcreteCommand: Define um vínculo entre um objeto receiver e uma operação
    - Implementa o método do command delegando as respectivas operações no reciever
  - Invoker: Pede ao comando para realizar a operação
    - Pode está associado a mais de 1 comando
  - Receiver: Contém a lógica do negócio
    - Sabe como realizar as operações vinculadas ao pedido
    - Qualquer classe pode funcionar como um reciever
- Exemplo
  - Command: ICommand
  - ConcreteCommand: AlertCommand
  - Invoker: Invoker
  - Receiver: PromotionService

## Interpreter

- Nome do exemplo: RunInterpreterSample
- Dada uma linguagem, descreve como definir uma representação para a sua gramatica juntamente com um interpretador que usa a representação para interpretar sentenças dessa linguagem
- Deve ser usado quando tem uma linguagem simples para interpretar e for possível representar sentenças da linguagem como arvores sintáticas abstratas
- Para tirar melhor proveito:
  - A gramatica deve ser simples: para evitarmos gramaticas complexas que são difíceis de manter devido a grande hierarquia de classes necessária para interpretá-la
  - A eficiência é não deve ser uma preocupação crítica: os interpretadores mais eficientes normalmente não são implementados pela interpretação direta da arvore de analise sintática
- Torna fácil mudar e estender a gramatica
- Estrutura
  - AbstractExpression: define a interface para execução da operação de interpretação a todos os nós da arvore sintática abstrata
  - TerminalExpression: são os símbolos finais da gramatica não são compostos por outros AbstractExpression
    - Implementa a operação “Interpret” associada com símbolos de terminal na gramatica
    - Necessitada de uma instância para cada símbolo de terminal na sentença
  - NonterminalExpression: são compostos por outros AbstractExpression
    - Mantém variáveis de instância do tipo AbstractExpression (terminais ou outras non terminais) para cada um dos símbolos R1 a Rn.
    - Implementa uma operação “Interpret” para símbolos não terminais na gramática. “Interpret” normalmente chama a si mesmo recursivamente nas variáveis que representam R1 a Rn
  - Context: Contém informações que são globais ao interpretador
    - como a expressão a ser interpretada e a situação atual da interpretação
- Exemplo
  - AbstractExpression
    - IAbstractExpression: Interface como método “Interpret”
    - AbstractExpression: Abstração - Usada para centralizar alguns dados comuns a todos os nós
  - TerminalExpression:
    - HundredExpression: Traduz os símbolos da casa das centenas
    - OneExpression: Traduz os símbolos da casa das unidades
    - TenExpression: Traduz os símbolos da casa das dezenas
  - Context: Context
  
## Iterator

- Nome do exemplo: RunIteratorSample
- A ideia principal do padrão é extrair o comportamento de travessia de uma coleção para um objeto separado chamado um "iterator"
  - Permite percorrer os elementos de um objeto agregado sequencialmente sem expor sua representação subjacente (lista, pilha, árvore, etc.)
- Permite executar múltiplos percursos em paralelo na mesma coleção devido ao encapsulamento de todos os detalhes da travessia no objeto “iterator”
- O código cliente pode não ter acesso a coleção que está sendo percorrida
  - O código cliente não necessita ter acesso/ciência da coleção que está sendo percorrida basta usar o iterator
- Melhora a interface das listas pois extrai os métodos de percursos para o iterator
  - Não enche a interface da coleção com métodos para os variados percursos que podem ser usados nela
- A ideia chave desse padrão é retirar a reponsabilidade de acesso e percurso da lista e colocar no interater
- Existe mais de uma forma de implementação do iterator (internos, externos)
  - Externo: o controle do percurso fica no cliente, ele que chama os métodos de percursos do iterator (Pegar item atual, chamar o próximo, iniciar o percurso, ...)
  - Interno: a interface do iterator fica mais simples e o cliente pode chama só uma operação que consolida as supracitadas dentro iterator, com isso o cliente perde um pouco de controle sobre o percurso
- Usar quando
  - Quer acessar o conteúdo das coleções sem acopla-las no código cliente, protegendo a coleção das interações do cliente e escondendo sua complexidade
  - Quer ter suporte a múltiplos percursos
- Estrutura
  - Iterator: Interface que declara as operações necessárias para percorrer uma coleção: buscar o próximo elemento, pegar a posição atual, recomeçar a iteração, etc.
  - ConcreteIterator: Implementam algoritmos específicos para percorrer uma coleção
    - Responsável por monitorar todo o progresso da travessia por conta própria
    - Pode ter mais operações para ajudá-lo no percurso além das recorrentes (First, Next, IsDone, CurrentItem)
  - Aggregate: Interface das coleções
    - Descreve os métodos para obter os integradores
  - ConcreteAggregate: Retorna a instância do ConcreteIterator apropriada para a coleção
- Exemplo
  - Iterator: IIterator
  - ConcreteIterator: ImparIterator
  - Aggregate: IAggregate
  - ConcreteAggregate: FruitAggregate

## Mediator

- Nome do exemplo: RunMediatorSample
- Define um objeto (Mediator) que encapsula a forma como um conjunto de objetos interagem entre si
  - Faz com que todas as comunicações diretas entre os objetos sejam direcionadas para o mediator tornando-as indiretas
- Reduz o acoplamento entre objetos
  - Agora todos os objetos só necessitam conhecer o mediator e ele redireciona as chamadas para os "colleagues" apropriados
  - Melhora o reuso dos "colleagues" pois retira as dependências internas deles com outros objetos substituindo-os pelo mediator
- Diminui a quantidade de subclasses de "colleagues" quando a única finalidade delas é mudar o formato como tratam os outros objetos
  - Essa interação é movida para o mediator, bastando o "colleague" deve somente sinalizar ao mediator quando algo significante acontecer
- Pode usar o MediatR para implementar
- Atenção
  - A complexidade do Mediator aumenta proporcionalmente ao tamanho/complexidade do conjunto de objetos que ele encapsula e seu crescimento, ficar atento para não o tornar um "god object"
- Estrutura:
  - Colleague: São as classes de negócio conhecem o mediator por sua interface
    - Envia e recebe solicitação do mediator, não dever ter ciência dos outros Colleagues e somente falar com eles através do mediator
  - Mediator: Interface comum aos mediator normalmente só um método que recebe a notificação e quem o está notificando
  - ConcreteMediator: Implementam a interface Mediator
    - Encapsula as relações entre vários componentes
    - Implementa o comportamento cooperativo entre as classes "Colleagues", mantém referência a todos os objetos que gerencia
- Exemplo
  - Colleague: Colleague1, Colleague2, Colleague3
  - Mediator: IMediator
  - ConcreteMediator: ConcreteMediator

## Memento

- Nome do exemplo: RunMementoSample
- Permite capturar e externalizar o estado interno de um objeto sem feri seu encapsulamento (sem revelar os detalhes de sua implementação), permitindo ao objeto voltar a este estado caso necessário
- Armazena a cópia do estado de um objeto em outro objeto especial chamado memento
  - O conteúdo do memento só é acessível ao objeto que o construiu  
  - Os outros objetos (inclusive o cuidador) usam uma interface limitada com acesso somente aos metadados para identificação do memento, não tem acesso aos dados internos do estado armazenado
- Toda ação que mude o estado do objeto e deseje ser reversível, deve salvar o estado e no "memento" e armazena-lo em um cuidador que criar como um histórico para recuperação futura.
- O padrão delega a criação dos snapshots para o próprio objeto originador que decide o que colocará no memento.
  - Evita a exposição de informações que somente o originador deveria acessar
  - Simplifica o originador pois, remove dele a gestão dos snapshots das versões de seu estado
- Atenção
  - Se são salvos mementos com muita frequência pode ter um custo de RAM
  - O cuidador deve acompanhar o ciclo de vida do objeto originador para remover mementos obsoletos
- Estrutura
  - Memento: Armazena o estado interno do objeto originador, imutável
  - Originator: O objeto que pode ter seu estado restaurado
    - Cria o memento contendo um retrato do seu status atual quando for necessário
    - Consegue restaurar seu estado fazendo uso do memento
  - Caretaker: Responsável pela custódia dos mementos par quando forem necessários
    - Não pode acessar nem alterar os estados internos do memento
- Exemplo:
  - Memento: BillMemento
    - IMemento: interface simplificada do memento para não percibe que outras classes acessem o conteudo dele
  - Originator: Bill
  - Caretaker: MementoManager

## Observer

- Nome do exemplo: RunObserverSample
- Permite que um objeto notifique outros objetos sobre alterações em seu estado
  - Cria um mecanismo de assinatura para que a alteração de um objeto "subject" notifique múltiplos objetos dependentes que irão se atualizar automaticamente
  - Não limita a quantidade objetos de inscritos
- Fornece uma maneira de assinar e cancelar a assinatura dos objetos que implementam a interface de observer
  - Os subjects fornecem a interface para adicionar e remover assinantes a qualquer momento
- Os observadores têm a responsabilidade de tratar ou ignorar uma notificação, podem acompanhar mais de um subject ao mesmo tempo
- A notificação de mudança pode ser disparada pelo subject ou pelo ciente, vai depender do contexto
- Útil quando
  - Mudanças no estado de um objeto precisem mudar outros objetos e estes são desconhecidos ou mudam dinamicamente
  - Quando um observer precisar acompanhar um subject por um período definido de tempo
- Em ambientes de relacionamentos complexos entre Observers e Subjects pode ter uma classe Change Manager para diminuir o trabalho necessário para que um observador reflita as mudanças de um subject
  - Quando a alteração de vários subjects interdependentes reflitam no observer pode ser preferível que todos mudem seu estado e só aconteça uma notificação no final no lugar um a cada mudança intermediária
- Estrutura
  - Subject (Publisher): Interface para definição dos Subjects contém os métodos para gerenciamento da subscrição
  - ConcreteSubject: Implementa o Subject
    - Envia as notificações aos observadores e os conhece somente pela interface "Observer"
    - Permitem a inscrição de assinantes ou remoção dos atuais
    - Envia dado de contexto para correto tratamento do evento pelo observer
  - Observer (Subscriber): Interface do objeto assinante normalmente contém a definição do método que vai receber a notificação do subject, pode conter parâmetros para agregar contexto
  - ConcreteObserver: Implementa a interface Observer
    - Implementa a interface observer para deixar seus dados consistentes com as mudanças ocorridas nos subjects
- Exemplo
  - Subject: ISubject
  - ConcreteSubject: Pedido
  - Observer: IObserver
  - ConcreteObserver: Separation

## State

- Nome do exemplo: RunStateSample
- Permite que um objeto altere seu comportamento quando seu estado interno muda. O objeto aparecerá para alterar sua classe.
  - Altera o comportamento quando seu estado interno é alterado
- O Padrão extrai da classe comportamentos relacionados ao estado, os adiciona em classes separadas de estado e delega a essas classes as ações relacionadas quando solicitado
  - Tira os vários if/switch do código do objeto cuja finalidade é se comportar de maneiras diferentes a depender do estado movendo-os para seus estados específicos
- Melhora a elegibilidade e maneabilidade do código
  - Com os estados fora da classe contexto torna mais fácil descobri a intenção do código e estendê-lo
- Os estados devem ser finitos e em caso da criação de um novo será necessária a criação de uma nova classe
- O objeto que tem o estado é chamado de contexto, ele referência o estado por meio de interface comum todos os estados delegando as alterações que impactam estados para seu estado
- Tanto o Contexto como os objetos estados podem alterar o estado atual  
- Útil quando
  - Você tem um objeto que se comporta de maneira diferente dependendo do seu estado atual e/ou uma classe cheia de condicionais gigantes que alteram como a classe se comporta de acordo com os valores atuais dos campos da classe
- Quando tem código duplicado comum entre os estados pode criar uma abstração e deixar os valores comum como comportamento padrão
- Estrutura
  - Context: Mantem uma instância de ConcreteState que define o estado atual
    - É a interface de conhecimento do cliente
  - State: Define a interface para os estados com os métodos que interagem com o contexto
  - ConcreteState: Implementa o State
    - Cada subclasse implementa um comportamento para os métodos da interface a depender do estado que elas representem
    - Pode mudar o Estado do Contexto
- Exemplo
  - Context: Water, IContext
  - State: IState
  - ConcreteState: Solid ,Liquid, Gas

## Strategy

- Nome do exemplo: RunStrategySample
- Encapsula os possíveis algoritmos em uma classe strategy permitindo que variem independentes dos clientes que a utilizam
- O contexto delega para a instância da estratégia que está vinculado para executar o algoritmo
  - Este algoritmo pode ser substituído em tempo de execução através da substituição da instancia da estratégia
- Reduz a complexidade e os códigos duplicados
  - Remove da classe as condicionais relacionadas a algoritmos e criando suas classes especificas
  - Simplifica hierarquias onde a diferença entre as subclasses é como tratam determinado algoritmo
- Isola os detalhes na implementação do algoritmo para os objetos que o usa
- O contexto pode passar os dados necessários para a estratégia, passar a se mesmo e a estrague busca as informações ou a estratégia ter a referência para o contexto e a estratégia buscar as informações
  - Pode definir uma interface para a estratégia acessa-lo
- AS estratégias se tronam totalmente independentes entre si
- Estrutura
  - Context: Contem a referência a estratégia concreta
  - Strategy: Declara uma interface comum para todos os algoritmos, o contexto usa a interface para chamar o algoritmo na estratégia concreta
  - ConcreteStrategy: implementa o algoritmo usando a interface da estratégia
- Exemplo
  - Context: VacationService
  - Strategy: IStrategy
  - ConcreteStrategy: TimeInCompanyStrategy, FastToReturnStrategy, LongestOverdueStrategy

## Template Method

- Nome do exemplo: RunTemplateMethodSample
- Sugere criar um método na superclasse (template method) com um esqueleto para o algoritmo dividindo-o em uma série de etapas e permite as subclasses estender essas etapas.
  - Declara métodos que agem como etapas de um algoritmo
  - Permite que subclasses redefinam certas etapas de um algoritmo sem mudar a estrutura do mesmo
- Ajuda a reduzir a duplicação de código
- Coloca na superclasse os comportamentos invariantes dos métodos que forem possíveis e as subclasses só implantam o comportamento variável
- Pode usar hooks para os comportamentos opcionais
  - Normalmente métodos vazios na superclasse que podem ser sobrescritos pelas subclasses que necessitam estende-los
- Template Method pode ter
  - Operações concretas e concretas de abstracts: métodos concretos virtuais ou não, chamados ou implementados na superclasse
  - Operações primitivas: métodos abstratos devem ser sobrescritos
  - Hooks: métodos opcionais vazios na superclasse, mas podem ser sobrescrito nas subclasses
- Atenção:
  - Se tiver muitas etapas pode ser difícil manter o código
  - É uma extensão de comportamento estática pois está vinculada a herança e não pode ser mudado em tempo de execução
- Estrutura
  - AbstractClass: Define a estrutura do algoritmo dentro do template método, seu esqueleto
    - Define os métodos que compõem o template método (primitivos, concretos, hooks)
    - Contém a implementação dos comportamentos que são invariantes
  - ConcreteClass: Implementa as etapas (primitivas, hooks, virtuais) para ficar consistente com a sua tratativa especifica para o algoritmo
- Exemplo
  - AbstractClass: AbstractClass
  - ConcreteClass: Concrete1, Concrete2

## Visitor

- Nome do exemplo: RunVisitorSample
- Permite definir uma nova operação para uma hierarquia de classe sem mudar o código existente dessas classes
  - Permite separar algoritmos dos objetos nos quais eles operam
  - Representa uma operação a ser executada nos elementos de uma estrutura de objetos
- Cada elemento decide qual método do visitor irá usar
  - Os métodos do visitor conhecem as classes concretas dos elementos e são especializados para trabalhar com eles, cada classe concreta de elemento chama o método especifico para lidar com ele
- Ajuda a manter o código das classes dos elementos limpos de comportamentos auxiliares
  - Esses comportamentos são movidos para os visitors, deixando a classe original independente das operações que se aplicam a ela
- O visitor pode manter o método vazio para elementos que julgar que não faz sentido ter o comportamento
- Usa o double dispatch pois o método a ser executado depende a instância do elemento e do visitor
- Valido quando for necessário executar uma operação em todos os elementos de uma estrutura de objetos mesmo que sejam de classes diferentes
- Visitor torna fácil a adição de novas operações na estrutura
  - Podemos estender a hierarquia elemento simplesmente adicionado mais um concrete vistor invés de alterar toda as várias classes do elemento
- Valido quando você não quer poluir o elemento com novas implementações distintas e não relacionadas  
- Cada Visitor concrete define operações diferentes para a mesma estrutura, cada um com sua finalidade especifica
  - Mantem as operações relacionadas juntas na mesma classe visitor
- Permite criar duas estruturas hierárquicas uma para os elementos e outra para os visitor
- Deve aplicar o concrete visitor e todos os elementos da estrutura
- é necessário um Visitor abstrato para cada estrutura de dados
- Atenção:
  - Se as classes da estrutura de elementos mudam com frequência e complicado manter o visitor
    - Tem que atualizar todos os visitantes quando uma nova classe da estrutura é adicionada
    - Pensar antes de usar qual a alteração mais provável do algoritmo aplicado a estrutura ou das classes que a compõem
- Estrutura:
  - Element: Interface que declara um método para “aceitar” visitantes através da interface deles
  - ConcreteElement: implementar element
    - Direciona a chamada para o método do visitante apropriado que corresponde com a atual classe elemento,passando a si mesmo como parâmetro.
  - Visitor: Interface que declara o conjunto de métodos visitantes para cada elemento da estrutura de objetos,esses métodos devem receber os objetos concretos da estrutura
  - ConcreteVisitor: implementa o comportamento para cada concrete element seguindo sua interface
    - Pode armazenar estado local para ser acumulado à medida que percorre a estrutura, e pode ser usado comocontexto nas chamadas
  - ObjectStructure: A estrutura de objetos podendo ser “composite” ou coleções
    - Pode enumerar seus objetos
    - Pode ter interfaces de alto nível para uso dos visitor
- Exemplo:
  - Element: IElement
  - ConcreteElement: ConcreteEl1, ConcreteEl2, ConcreteEl3
  - Visitor: IVisitor
  - ConcreteVisitor: ConcreteVisitor1, ConcreteVisitor2
  - ObjectStructure: objectStructure
