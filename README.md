# GhComponentConfigurator
POC for an app to configure custom grasshopper components and automating boilerplate code generation to speed up development.

## Usage
### External App and UI
https://user-images.githubusercontent.com/6257186/164010152-f9ab9876-993d-46c2-9930-7d33e3b9ca58.mp4

### Alternative Implementation : Custom GH Components
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

The ambition for the UI is to create a variable parameter GH component with custom UI controls to set all necessary properties on the component and parameters.That is, the user defines inputs and outputs by interacting directly with a component just like in Grasshopper; adding input and output parameters, setting their name, right clicking to set type and access, etc. 

Turn Grasshopper into a design tool for custom component development.

## Contribute
If you want to colaborate reach out! Especially if you want to help designing the custom component UI.

