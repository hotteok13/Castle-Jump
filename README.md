# Game Overview
It is a game where you move through each city safely and without accidents to the destination. \
The difficulty level is set according to each city, and you can get rewards by clearing the quests.

***Optimization overview***
 - The canvas was divided and managed.
 - Implemented object pooling as a queue.

***SDK Used***
 - Newtonsoft JSON

***Game Function***
 - I set it to be able to control the volume.
 - Using json, data was stored and managed.
 - The camera did not move, but used a method of moving the map.
 - We have created additional quests using the dictionary.
 - We used the method of loading an object with AssetDatabase.LoadAssetAtPath().
 - Colliders are judged based on the material name of the collider.
 - It is designed to iteratively move the map using an algorithm that recycles three maps.
 - The left and right movement of the car is designed to look natural using linear interpolation.

***Design Pattern***
 - Singleton
 - Component
 
***Resolution***
 - Free Aspect
