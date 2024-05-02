# Unity Version

_ 2022.3.4f1

# **Design**

## Data-Driven: inject/binding to scene (data)

_ Basically, the control is determined **based on the setup** of the scene/prefab/scriptable object/etc. This means the code **will provide the tools** or anything that can be used to create an impact on the game, and the data will **be the user** who decides **how he uses it** (control logic flow). 

_ Take a look at my notes below for further information if u are interested: 

[Code Driven/Based/Oriented vs Data Driven Design](https://www.notion.so/Code-Driven-Based-Oriented-vs-Data-Driven-Design-4669ac4d359f442d834c02b4b74a7eb3?pvs=21)

_ I don’t really like this design because there are as many problems with this approach as the number of benefits that it may bring, I chose it for 2 reasons:

1. This is a simple gambling game that is mostly **event-based** and has few interactions (game scene).
2. Gambling games tend to **change the visual, order, and basic things** without huge/specific changes on the game logic capabilities so you can **reuse the same code for multiple games**, just rebind the detail (like what goes first, what calls what …) in the scene as you go.

## **MVVM**

_ Each scene will have a “Control” that stores the ViewModel (the data processor) like in the MVVM. To clear the air, I don’t normally apply the “normal software design” into the game (or the need/urge to do so) but I think this is a good place to use its dependency separation (and that’s it). So basically the only thing that MVVM in all of this is about things like: MV can only change data (but don’t know about V), V can work on MV but V cannot work (change) on data.

_ 99% of the event (that leads the logic flow) is stored in ViewModel so that the flow is as straightforward as possible:

![image](https://github.com/viennguyentri747/Match3-Demo/assets/39218295/cd746f6f-0fb3-409d-8cab-d3a71b980350)

_ There is not much to say about the View, it works on the views like showing views when a data change event happens in the model view …

_ The model is the data holder

_ With this design you can: **Remove the view** and use other things to invoke the **model view** → Logic still runs normally to update the state (data). Or you can r**emove the model view** and use other things to **update the view**

# What you can do to customize the game (without touching the code)

- Change the flow (what calls what, what happened first …) by drag-n-drop, input through the inspector
- Change the number of tokens (data) to any value that you want, I also created the scroll view to handle more views just in case.

# Extra Features

_ Besides the features specified in the document I also added, most of them were created for better dev experience:

- Test Window: access this by Window → TestGame, in code search for `TestGameEditorWindow`

![image](https://github.com/viennguyentri747/Match3-Demo/assets/39218295/c44d9db7-d6df-45dd-8255-64d1b61edc30)

- Custom Log System: search for `LogHelper`
- Custom Inspector for some components: search for `UnityEventInvokerEditor`

# What I might do better (if I had more time)

1. Optimize UI so that it looks better on different resolutions.
2. Optimize assets: atlas the background UIs for the game scene, and optimize asset size.
3. Optimize “highlight”: currently, every highlight object is attached to the tokens on board, it should be dynamically spawned from the pool for those that need only (in calculated position) 
4. Use a shader to make the highlight look better, for now, it is just an image scaled by time.
5. Update custom Test Window to invoke parameter function (allow passing custom data)
6. Add a custom Window for (1) better scene reference tracking (a vi
