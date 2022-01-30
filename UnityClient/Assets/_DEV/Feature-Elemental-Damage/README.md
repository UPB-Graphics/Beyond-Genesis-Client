# Elemental Damage & Damage Popups

This feature implements a complete system for damage interactions as well as a simplist stat system for it to affect something.

The damage system is defined by multiple subsystems:

- Damage with this system is defined using a value and an elemental type.
- Elemental types are both classes aswell as enums for more versatility.
- Elemental damage is defined using a template (C# Generics) and is constructed using a `Damage Blueprint` (because a generic class cannot be serialized in the inspector)
- Resistances are also defined by the same elements, but the correlation between a specific type of damage and it's resistance needs to be implemented separately (in this case it is implemented in the `Stats` class), altohugh a warning is raised in the form of an assertion in case of resistance damage reduction misuse
- `Damage Blueprint` which was mentioned before is a builder pattern that creates damage based on it's defining properties (Element and Value)
- Elemental combinations are simple enum values which are registered on each element as a combination result when two of these elements meet on a `Damageable` entity (they do not serve any function to this moment, but this library can be further expanded to affect certain stats on a combination proc)
- `Damageable` entities are defined by the `ADamageable` abstract class, which defines the behaviour for elemental interaction, aswell as applying damage to a certain entity (in this particular example the stats are derived from it, thus defining a damageable entity)
- Damage numbers are spawned from a singleton manager which holds multiple `DamagePopup` objects and shows them when needed (they are also used for showing elemental combinations although it may not be the best solution yet)

The demo scene in which this system is presented also boasts the following features:
- UI for modifiying damage dealt between two players
- UI for showing and editing stats on the go during playtime (to further show the potenital of the damage reduction methods)
- Inspector UI modeled using the `PropertyDrawer` class that allows for easier modification of stats and other serializable fields
- A serializable dictionary that allows showing different dictionaries for choosing colors/icons/etc.