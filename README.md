# Project Overview

## **Quick Description**

In slot gaming, a popular feature is the "Match Three Bonus" game. Here, players are presented with **several tokens** to choose from. Each time a player selects a token, the corresponding prize name is revealed. The game aims for the player to match **3 tokens of the same prize**. Once a player successfully matches three of a kind, they are awarded that prize, and **the bonus game concludes**.

## **Design Philosophy**

### **Data-Driven Approach**

- **Integration**: Data elements are injected and bound directly within the scene, including prefabs, scriptable objects, and other relevant assets.
- **Control Mechanism**: The system is designed to empower users by providing the tools necessary for creating dynamic game flows. Users dictate the application and manipulation of data, shaping the control logic within the game environment.

**Further Insights**: For a deeper dive into our approach compared to a code-driven strategy, see our detailed comparison [here](https://www.notion.so/4669ac4d359f442d834c02b4b74a7eb3?pvs=21).

### **Decision Rationale**

Despite mixed feelings about this design, it was chosen for its suitability in the following contexts:

1. **Event-Driven Simplicity**: Ideal for simple gambling games with minimal interactive elements.
2. **Reusable Components**: Facilitates easy modifications to game aesthetics and structure without altering core logic, enhancing adaptability across multiple games.

### **Model-View-View Model (MVVM)**

- **View Model**: Centralizes nearly all event logic, simplifying the flow control within the **View Model**.
- **View**: Reacts to data changes within the **View Model**, managing display elements without directly modifying the underlying data.
- **Model**: Acts as the primary repository for game data.

**Design Benefits**: This framework allows for significant flexibility, such as removing the view layer without impacting the logical operations of the model view, or vice versa.

## **Customization Capabilities**

- **Inspector Tools**: Modify game flow, sequence of events, and data variables using intuitive drag-and-drop interfaces and inspector inputs.
- **Dynamic Content Management**: Adjust token quantities and manage additional views through a scrollable interface, accommodating expansive game elements.

## **Additional Features**

- **Development Tools**:
    - **Test Window**: Accessible via `Window → TestGame`. For implementation, refer to `TestGameEditorWindow`.
    - **Custom Logging**: Utilize `LogHelper` for tailored debugging outputs.
    - **Component Inspectors**: Enhanced component management through `UnityEventInvokerEditor`.

https://github.com/viennguyentri747/Match3-Demo/assets/39218295/c44d9db7-d6df-45dd-8255-64d1b61edc30

## **Potential Improvements (haven't done yet)**

With more time, enhancements would focus on:

1. UI Optimization: Enhance compatibility across various resolutions.
2. Asset Management: Improve background UI integration and reduce asset footprints.
3. Highlight Management: Transition from static to dynamically generated highlights to conserve resources and improve visual effects.
4. Visual Enhancements: Implement shaders for more dynamic and visually appealing highlights.