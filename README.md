# Top Down Game 2D
This is a Unity project used to follow along with the Start Game Dev course

##

## Topics

### Tilemap
Used to create the scenario.

### Tilemap Collider 2D
Adding collider to an entire tilemap

### Coposite Collider 2D
The Composite Collider 2D component is a Collider that interacts with the 2D physics system. 
Unlike most Colliders, it does not define an inherent shape. 
Instead, it merges the shapes of any Box Collider 2D or Polygon Collider 2D that you set it up to use. 
The Composite Collider 2D uses the vertices (geometry) from any of these Colliders, and merges them together into new geometry controlled by the Composite Collider 2D itself.
It will automaticly add a RigidBody 2D

In this game, after adding composite collider 2D these properties ware changed:
* RigidBody Body Type: Static
* Tilemap Collider 2D Used By Composite: True

### Player Game Object
Creating an Empty Game Object and Adding a Sprite Renderer to it
in the Sprites, all of them will be checked as:
* Pixels Per unit: 16
* Filter Mode: Point (No filter)
* Compression: None
* Sprite Mode: Multiple  

Add Box Collider 2D without Trigger
RigidBody with Gravity Scale set to 0 or kinematic. This will be done in order to avoid the player to fall from the map, since it is a Top Down, we will not want it to happen.
Constraints Freeze Rotation: Z checked to avoid sprite being rotated in the scene.