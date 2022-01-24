# DesignPatterns
Console project with design patterns samples

All content is fictitious for study purposes only

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