# Quest system
## Added by Stefan Dobrica and Mihnea Zamfir

To add a quest, simply call QuestManager.AddQuest(Quest q)

Quest constructor uses:
- List\<Goal\>
- List\<Reward\>
- string questTitle
- string questDesctiption

Goals can be of multiple types:
- KillGoal - KillGoal(int enemyId, int ammount)
- MoveGoal - MoveGoal(Vector3 poz)

Preferably the upcomming enemy system uses an enemyId

Rewards can be of multiple types:
- RewardExp - RewardExp(float ammount)
- RewardMoney - RewardMoney(float ammount)
- RewardItem - RewardItem(Item item)

Preferably the upcomming item system uses an Item class <br />
Preferably the upcomming exp system uses an AddExp function that takes a float as argument<br />
Preferably the upcomming money system uses an AddMoney function that takes a float as argument

Includes:
- Classes for Quests, Goals, Rewards
- Managers for Quests and UI
    - QuestManager.AddQuest adds a quest to the quest list and to the UI
    - QuestManager.Start includes a test for the above functionality
    - Quest text (goals and rewards) updates in real time
    - UiManager uses a prefab for the quest template that resizes according to text length
- Mock-up managers for Exp, Item, Money, Player and Enemy management

Dependencies:
- TextMeshPro
