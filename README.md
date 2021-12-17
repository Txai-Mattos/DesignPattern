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
  




