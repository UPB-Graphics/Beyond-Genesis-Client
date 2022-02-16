# Combat Skill: AOE Explosion
## Simion Cristian

Adds functionality for an AOE explosion spell with a wide box shape centered in front of the character. The starting animtion should be launched by an animation trigger while the spell itself is cast by an animation event. 
The event calls a function that implements basic functionality such as instantianting and destroying the particle object and checking each enemy collider (from a given layer mask) with a BoxOverlap. 

The combat logic can be handled in the collider check loop. The spell origin, particle prefab or the spell box size can be easily changed in the editor. A small scene is setup for quick preview. You can also zoom in and rotate the camera with the A and D keys. The spell can be cast with the E key.

### Example video
https://user-images.githubusercontent.com/46331290/154314680-e633b657-19ab-4e72-b5f6-1301172f4113.mp4


### Resources Used
Explosion particles from the official [Unity Particle Pack](https://assetstore.unity.com/packages/essentials/tutorial-projects/unity-particle-pack-127325)

Sample model and animation from [Mixamo](https://www.mixamo.com/) (Y Bot model with Idle and Standing 2H Magic Area Attack 02 animations) 
