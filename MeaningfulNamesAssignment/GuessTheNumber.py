import random

def isValidGuess(userInput):
    if userInput.isdigit() and 1 <= int(userInput) <= 100:
        return True
    return False

def guessNumber():
    correctNumber = random.randint(1, 100)
    guessedCorrectly = False
    guessCount = 0

    guessedNumber = input("Guess a number between 1 and 100: ")

    while not guessedCorrectly:
        if not isValidGuess(guessedNumber):
            guessedNumber = input(
                "Invalid input. Please enter a number between 1 and 100: "
            )
            continue

        guessCount += 1
        guessedNumber = int(guessedNumber)

        if guessedNumber < correctNumber:
            guessedNumber = input("Too low. Guess again: ")
        elif guessedNumber > correctNumber:
            guessedNumber = input("Too high. Guess again: ")
        else:
            print("You guessed it in", guessCount, "guesses!")
            guessedCorrectly = True

guessNumber()
