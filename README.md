# GhComponentConfigurator
POC for an app to configure custom grasshopper components and automating boilerplate code generation to speed up development.

## Usage
https://user-images.githubusercontent.com/6257186/164010152-f9ab9876-993d-46c2-9930-7d33e3b9ca58.mp4

### Alternative UI with Custom GH Components
![GhComponentConfigurator_GHUI](https://user-images.githubusercontent.com/6257186/164966045-27b45d65-b05a-4051-8c54-12726985f639.png)

## Current Functionality
* Configure component attributes.
* Configure input and output parameters.
* Generates single component boilerplate.

## Future Functionality
* Extend template to include boilerplate DataAccess code to facilitate validation of inputs in ```SolveInstance()```.
* Ability to configure multiple components maintaining global variables across components.
* Ability to configure additional menu items.
* Ability to associate an icon to a component generating the appropriate resources and folder structures.

## UX/UI Design
A very quick and rough tongue-in-cheek design that references typical Grasshopper component styling :). 

The actual ambition for the UI is to create an actual GH component with very similar UX to a GhPython scripting component with variable inputs and outputs.That is, the user defines inputs and outputs by interacting directly with a component just like in Grasshopper; adding input and output parameters, setting their name, right click to set type and access, right clicking to set menu items, properties, and global attributes, etc. 

Finally, if designing a suite of components, it would be awesome to be able to wire them up in a dummy graph. The idea being that when one is designing a large multi-component plug-in, it is useful to visualise how all these components will be used together in typical workflows.

It is quite possible that the best solution is piggy-backing on Grasshopper's existing UI and creating a special template component that behaves as desired. This has the added benefit that they can be wired up to visually prototype how they work together or with other components. Generating their templates could be done on a component basis, or by selecting them and executing template generation from a plug-in.

## Contribute
If you want to colaborate reach out! Especially if you want to help designing the UI... It's a fun little project!

