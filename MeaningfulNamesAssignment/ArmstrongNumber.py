def isArmstrongNumber(number):
    digitSum = 0
    digitCount = 0

    tempNumber = number
    while tempNumber > 0:
        digitCount += 1
        tempNumber //= 10

    tempNumber = number
    while tempNumber > 0:
        digit = tempNumber % 10
        digitSum += digit ** digitCount
        tempNumber //= 10

    return digitSum

inputNumber = int(input("\nPlease enter the number to check for Armstrong: "))

if inputNumber == isArmstrongNumber(inputNumber):
    print(f"\n{inputNumber} is an Armstrong Number.\n")
else:
    print(f"\n{inputNumber} is not an Armstrong Number.\n")
