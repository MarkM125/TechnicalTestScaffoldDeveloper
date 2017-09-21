# Coding Test - Cards

A card game is played with a deck of forty cards, containing each of the numbers from 1 to 10 exactly 4 times. The game is scored according to the following 2 rules:

* A point is given for each pair of cards with identical numerical values
* A point is given for any group of cards whose numerical values sum to 15

For example:

* The set of cards `8 8 8` is worth 3 points since there are 3 different pairs of cards with identical numerical values.
* The set `10 5 2 3` is worth 2 points since there are 2 groups of cards whose numerical values sum to 15.

## Notes

To complete this task, please fork this repository and complete the changes in your fork. Once you're happy, notify us that you're done and we can review your work.

A few other hints:

* Business logic is more important than a fancy UI for this test
* Think about architecture and application design
* Think about how you would test and validate this
* Try and impress us!

## Question 1

Adapt the supplied code to produce a program which:

* Inputs 5 numbers (each of which will be between 1 and 10 inclusive) indicating the numerical value of 5 different cards
* Outputs the number of points these 5 cards are worth

### Sample Run

```
Card 0: 3
Card 1: 3
Card 2: 3
Card 3: 2
Card 4: 10
Your score is: 6
```



*For the following parts, remember that you are allowed to use each number from 1 to 10 at most 4 times*



## Question 2

Give a set of five cards that score 0 points.

## Question 3

How many different sets of five cards are there where the sum of the values of all five cards is exactly 15?

**Note:** You should assume that order does not matter and cads are only different if they contain different values; e.g. `1 2 3 4 5` is the same as `5 4 3 2 1`


