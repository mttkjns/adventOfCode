#function to generate total score
def round_outcome(opponent, user):
    total_score = 0
    if opponent == 'A':
        if user == 'X':
            total_score = total_score + x + draw
            return total_score
        elif user == 'Y':
            total_score = total_score + y + win
            return total_score
        elif user == 'Z':
            total_score = total_score + z 
            return total_score
    elif opponent == 'B':
        if user == 'X':
            total_score = total_score + x 
            return total_score
        elif user == 'Y':
            total_score = total_score + y + draw
            return total_score
        elif user == 'Z':
            total_score = total_score + z + win
            return total_score
    elif opponent == 'C':
        if user == 'X':
            total_score = total_score + x + win
            return total_score
        elif user == 'Y':
            total_score = total_score + y 
            return total_score
        elif user == 'Z':
            total_score = total_score + z + draw
            return total_score

#input file and defining score variables
file_to_use = '.\day2_input.txt'
x = 1 #ROCK VALUE
y = 2 #PAPER VALUE
z = 3 #SCISSORS VALUE
win = 6
draw = 3
final_score = 0
winCount = 0


#opening file and creating an iterable
with open(file_to_use, 'r') as file:
    contents = file.readlines()

#iterating through contents of the file line by line and assinging values to variable for function above
for line in contents:
    round_score = round_outcome(line[0], line[2])
    if round_score > 6 :
        winCount = winCount + 1
    final_score = final_score + round_score

#printing final score
print(final_score)
print(winCount)