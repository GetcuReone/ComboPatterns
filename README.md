# Welcome to the ComboPatterns!

[![NuGet version (ComboPatterns)](https://img.shields.io/nuget/v/ComboPatterns.svg?style=flat-square)](https://www.nuget.org/packages/ComboPatterns/)
[![Build status](https://dev.azure.com/GetcuReone-Studio/OpenSource-Projects/_apis/build/status/master-ComboPatterns?branchName=master)](https://dev.azure.com/GetcuReone-Studio/OpenSource-Projects/_build/latest?definitionId=8)
[![Azure DevOps tests](https://img.shields.io/azure-devops/tests/GetcuReone-Studio/OpenSource-Projects/8?label=Unit%20tests)](https://dev.azure.com/GetcuReone-Studio/OpenSource-Projects/_build/latest?definitionId=8)
[![GitHub](https://img.shields.io/github/license/GetcuReone/ComboPatterns)](https://github.com/GetcuReone/ComboPatterns/blob/master/LICENSE-2.0.txt)

This project is my implementation of pattern combinations that I worked with.
Over time, I will replenish the documentation. Implemented pattern combinations will be listed on this page.
For implementation, I used c # language.

## ComboPatterns
This library contains a set of interfaces that will be used later for Implementation. More [here][combo_patterns_wiki]

## ComboPatterns.Factory
This project contains an implementation of the interface IAbstractFactory. The interaction of most pattern implementations will be built on this interface. An implementation is class [FactoryBase][b_factory] with simply a method of creating objects.

The performance of the FactoryBase is tested by [tests][factory_tests].

## ComboPatterns.Facade
This project contains an implementation of the interface IFacade. More [here][facade_wiki]

## ComboPatterns.Adapter
This project contains an implementation of the interface IAdapter. More [here][adapter_wiki]

More information is available on the [wiki][home_wiki].

[combo_patterns_wiki]: https://github.com/GetcuReone/ComboPatterns/wiki/ComboPatterns "ComboPatterns wiki"
[b_factory]: https://github.com/GetcuReone/ComboPatterns/blob/master/ComboPatterns/Factory/ComboPatterns.Factory/FactoryBase.cs "FactoryBase"
[factory_tests]: https://github.com/GetcuReone/ComboPatterns/tree/master/ComboPatterns/Factory/ComboPatterns.FactoryTests "Tests for FactoryBase"
[facade_wiki]: https://github.com/GetcuReone/ComboPatterns/wiki/ComboPatterns.Facade "Facade wiki"
[adapter_wiki]: https://github.com/GetcuReone/ComboPatterns/wiki/ComboPatterns.Adapter "Adapter wiki"
[home_wiki]: https://github.com/GetcuReone/ComboPatterns/wiki/ "Home wiki"
