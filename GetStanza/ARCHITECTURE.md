# Stanza C# SDK Architecture
```sh
Root
├── Models
├── Providers
│   ├── Interfaces
│   └── Models
├── Services
│   └── Interfaces
├── Workers
└── gen
```

## Call Heirarchy
```sh
Root
├── Workers
└── Services
    └── Providers
```
Levels can only call down to the next level. Not up levels, across the same level, or multiple levels down.

## Root
Contains all classes a client of the SDK is expected to directly interact with.

## Models
Contains Business Models that operate as either DTOs (Data Transfer Objects) or objects that manage some sort of state. Used by the classes of the same directory level to satisfy their responsibilities.

## Interfaces
Define the contracts between classes and are the way that classes should be called (e.g. Root level classes call Services through the service's interface, Services call Providers through the provider's interface).

## Providers
Provide connections to external data (e.g. hub or disk access).

## Services
Contain business logic. **The core algorithms used by a codebase reside here.**

Services call out to Providers for data required to satisfy a responsibility. Root level classes should call Services to satisfy their responsibility, not the Providers directly.

## Workers
Contain classes that manage background threads. Should only be called by the Root level classes.

## gen
Contains generated code. Usually protobufs.
