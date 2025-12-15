import random

def rollDice(faces):
    rollResult = random.randint(1, faces)
    return rollResult

def rollDiceGame():
    rollAgain = True 
    diceFaces = 6
    exitCode = "q"

    while rollAgain:
        userResponse = input("Ready to roll? Enter Q to Quit: Enter S to continue: ")

        if userResponse.lower() != exitCode:
            diceResult = rollDice(diceFaces)
            print("You have rolled a", diceResult)
        else:
            rollAgain = False

rollDiceGame()