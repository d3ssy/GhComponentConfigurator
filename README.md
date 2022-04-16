# GhComponentConfigurator
A UI for configuring custom grasshopper components and automating boilerplate code generation to speed up development.

## Usage
1. Launch configurator app.
2. Define high level component attributes such as Name, Category, etc.
3. Give your component a description.
4. Define input and output parameters.
5. Hit the green button to generate the boilerplate code.
6. Revel in the joy of knowing minutes of your life have been saved!

https://user-images.githubusercontent.com/6257186/163679628-163a9c1b-6a45-437c-a517-13e7b30f502b.mp4

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

The actual ambition for the UI is to create an actual GH component with very similar UX to a GhPython scripting component with variable inputs and outputs. 

That is, the user defines inputs and outputs by interacting directly with a component just like in Grasshopper; adding input and output parameters, setting their name, right click to set type and access, right clicking to set menu items, properties, and global attributes, etc. 

Finally, if designing a suite of components, it would be fantastic to be able to wire them up in a dummy graph. The idea being that when one is designing a large multi-component plug-in, it is useful to visualise how all these components will be used together in typical workflows.

It is quite possible that the best solution is piggy-backing on Grasshopper's existing UI and creating a special template component that behaves as desired. This has the added benefit that they can be wired up to visually prototype how they work together or with other components. Generating their templates could be done on a component basis, or by selecting them and executing template generation from a plug-in.

## Contribute
If you want to colaborate reach out! Especially if you want to help designing the UI... It's a fun little project!

