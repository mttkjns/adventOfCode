with open('input.txt') as f:
    lines = [l.strip() for l in f.readlines()]

lines = [[int(x) for x in l] for l in lines]

def visible(x, list_):
    return False not in list(map(lambda y: y < x, list_))

def view_index(x, list_):
    for i, y in enumerate(list_, start=1):
        if x <= y:
            return i
    return len(list_)

visibles = 2 * len(lines) + 2 * len(lines[0]) - 4
scores = []
for i, s in enumerate(lines):
    if i == 0 or i == len(lines) - 1:
        continue
    for j, c in enumerate(s):
        if j == 0 or j == len(s) -1:
            continue
        if (
            visible(s[j], s[0:j]) or
            visible(s[j], s[j+1:]) or
            visible(s[j], [lines[r][j] for r in range(i)]) or
            visible(s[j], [lines[r][j] for r in range(i+1, len(lines))])
        ):
            visibles += 1

        scenic_score = (
            view_index(s[j], list(reversed(s[0:j]))) *
            view_index(s[j], s[j+1:]) *
            view_index(s[j], list(reversed([lines[r][j] for r in range(i)]))) *
            view_index(s[j], [lines[r][j] for r in range(i+1, len(lines))])
        )
        scores.append(scenic_score)

print(visibles)

print(max(scores))