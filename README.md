# UTD-SC01

Implemented requeriments:
--------


* Basic battlefield with camera control over keyboard or mouse
* Light "base"
* Nonpooling creeps spawn
* UI integration
* creeps using Unity Navigation System
* 2 types of turrets (with diferent mechanics)
* economy
* 2 types of creeps (with diferent specifications)
* waves and levels system with data files

Log
--------
**Arquitecture Definition**
* Use of SOLID and Singleton Patterns

**Basic greyboxing**
* Interface and implementation of Camera and Selector
* (Clean code allow to implement different solutions for different platforms)

**Singleton based on ScriptableObjects**
* (this allows to setup the singleton from a Json coming from server, and allowing to implement a Client-Side Prediction and Server Reconciliation pattern for online implementation)
* Singleton autoinjection
* Without dependeces

**Units implementation**
* Based on scriptableobjects data
* Interface Segregation (for implement differnt kinds of units)
* Enemy Units with Event based implementation

**Levels and Waves**
* Based on scriptableobjects data
* Easy to tune
* Easy to setup from server
* Client-Side Prediction and Server Reconciliation pattern
